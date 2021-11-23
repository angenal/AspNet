#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2017 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using ShareX.HelpersLib;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShareX.ScreenCaptureLib
{
    public static class RegionCaptureTasks
    {
        public static Image GetRegionImage(RegionCaptureOptions options)
        {
            RegionCaptureOptions newOptions = GetRegionCaptureOptions(options);
            newOptions.ShowHotkeys = false;

            using (RegionCaptureForm form = new RegionCaptureForm(RegionCaptureMode.Default, newOptions))
            {
                form.Prepare();
                form.ShowDialog();

                return form.GetResultImage();
            }
        }

        public static bool GetRectangleRegion(out Rectangle rect, RegionCaptureOptions options)
        {
            RegionCaptureOptions newOptions = GetRegionCaptureOptions(options);
            newOptions.ShowHotkeys = false;

            using (RegionCaptureForm form = new RegionCaptureForm(RegionCaptureMode.Default, newOptions))
            {
                form.Prepare();
                form.ShowDialog();

                if (form.Result == RegionResult.Region)
                {
                    if (form.ShapeManager.IsCurrentShapeValid)
                    {
                        rect = CaptureHelpers.ClientToScreen(form.ShapeManager.CurrentRectangle);
                        return true;
                    }
                }
                else if (form.Result == RegionResult.Fullscreen)
                {
                    rect = CaptureHelpers.GetScreenBounds();
                    return true;
                }
                else if (form.Result == RegionResult.Monitor)
                {
                    Screen[] screens = Screen.AllScreens;

                    if (form.MonitorIndex < screens.Length)
                    {
                        Screen screen = screens[form.MonitorIndex];
                        rect = screen.Bounds;
                        return true;
                    }
                }
                else if (form.Result == RegionResult.ActiveMonitor)
                {
                    rect = CaptureHelpers.GetActiveScreenBounds();
                    return true;
                }
            }

            rect = Rectangle.Empty;
            return false;
        }

        public static PointInfo GetPointInfo(RegionCaptureOptions options)
        {
            RegionCaptureOptions newOptions = GetRegionCaptureOptions(options);
            newOptions.DetectWindows = false;
            newOptions.ShowHotkeys = false;
            newOptions.UseDimming = false;

            using (RegionCaptureForm form = new RegionCaptureForm(RegionCaptureMode.ScreenColorPicker, newOptions))
            {
                form.Prepare();
                form.ShowDialog();

                if (form.Result == RegionResult.Region)
                {
                    PointInfo pointInfo = new PointInfo();
                    pointInfo.Position = form.CurrentPosition;
                    pointInfo.Color = form.CurrentColor;
                    return pointInfo;
                }
            }

            return null;
        }

        public static SimpleWindowInfo GetWindowInfo(RegionCaptureOptions options)
        {
            RegionCaptureOptions newOptions = GetRegionCaptureOptions(options);
            newOptions.UseDimming = false;
            newOptions.ShowMagnifier = false;
            newOptions.ShowHotkeys = false;

            using (RegionCaptureForm form = new RegionCaptureForm(RegionCaptureMode.OneClick, newOptions))
            {
                form.Prepare();
                form.ShowDialog();

                if (form.Result == RegionResult.Region)
                {
                    return form.SelectedWindow;
                }
            }

            return null;
        }

        public static void ShowScreenRuler(RegionCaptureOptions options)
        {
            RegionCaptureOptions newOptions = GetRegionCaptureOptions(options);
            newOptions.QuickCrop = false;
            newOptions.ShowHotkeys = false;

            using (RegionCaptureForm form = new RegionCaptureForm(RegionCaptureMode.Ruler, newOptions))
            {
                form.Prepare();
                form.ShowDialog();
            }
        }

        public static Image AnnotateImage(Image img, string filePath, RegionCaptureOptions options,
            Action<Image, string> saveImageRequested,
            Action<Image, string> saveImageAsRequested,
            Action<Image> copyImageRequested,
            Action<Image> uploadImageRequested,
            Action<Image> printImageRequested,
            bool taskMode = false)
        {
            RegionCaptureMode mode = taskMode ? RegionCaptureMode.TaskEditor : RegionCaptureMode.Editor;

            using (RegionCaptureForm form = new RegionCaptureForm(mode, options))
            {
                form.ImageFilePath = filePath;
                form.Prepare(img);
                form.ShowDialog();

                switch (form.Result)
                {
                    case RegionResult.Close: // Esc
                    case RegionResult.AnnotateCancelTask:
                        return null;
                    case RegionResult.Region: // Enter
                    case RegionResult.AnnotateRunAfterCaptureTasks:
                        return form.GetResultImage();
                    case RegionResult.Fullscreen: // Space or right click
                    case RegionResult.AnnotateContinueTask:
                        return (Image)form.Canvas.Clone();
                    case RegionResult.AnnotateSaveImage:
                        using (Image resultSaveImage = form.GetResultImage())
                        {
                            saveImageRequested(resultSaveImage, form.ImageFilePath);
                        }
                        break;
                    case RegionResult.AnnotateSaveImageAs:
                        using (Image resultSaveImageAs = form.GetResultImage())
                        {
                            saveImageAsRequested(resultSaveImageAs, form.ImageFilePath);
                        }
                        break;
                    case RegionResult.AnnotateCopyImage:
                        using (Image resultCopyImage = form.GetResultImage())
                        {
                            copyImageRequested(resultCopyImage);
                        }
                        break;
                    case RegionResult.AnnotateUploadImage:
                        Image resultUploadImage = form.GetResultImage();
                        uploadImageRequested(resultUploadImage);
                        break;
                    case RegionResult.AnnotatePrintImage:
                        using (Image resultPrintImage = form.GetResultImage())
                        {
                            printImageRequested(resultPrintImage);
                        }
                        break;
                }
            }

            return null;
        }

        public static Image ApplyRegionPathToImage(Image img, GraphicsPath gp)
        {
            if (img != null && gp != null)
            {
                Rectangle regionArea = Rectangle.Round(gp.GetBounds());
                Rectangle screenRectangle = CaptureHelpers.GetScreenBounds0Based();
                regionArea = Rectangle.Intersect(regionArea, screenRectangle);

                if (regionArea.IsValid())
                {
                    using (Bitmap bmp = img.CreateEmptyBitmap())
                    using (Graphics g = Graphics.FromImage(bmp))
                    using (TextureBrush brush = new TextureBrush(img))
                    {
                        g.PixelOffsetMode = PixelOffsetMode.Half;
                        g.SmoothingMode = SmoothingMode.HighQuality;

                        g.FillPath(brush, gp);

                        return ImageHelpers.CropBitmap(bmp, regionArea);
                    }
                }
            }

            return null;
        }

        private static RegionCaptureOptions GetRegionCaptureOptions(RegionCaptureOptions options)
        {
            if (options == null)
            {
                return new RegionCaptureOptions();
            }
            return new RegionCaptureOptions
            {
                SnapSizes = options.SnapSizes,
                ShowMagnifier = options.ShowMagnifier,
                UseSquareMagnifier = options.UseSquareMagnifier,
                MagnifierPixelCount = options.MagnifierPixelCount,
                MagnifierPixelSize = options.MagnifierPixelSize,
                ShowCrosshair = options.ShowCrosshair,
                AnnotationOptions = options.AnnotationOptions
            };
        }

        public static Image GetRegionImage_X(RegionCaptureOptions options, out string flag)
        {
            RegionCaptureOptions regionCaptureOptions = GetRegionCaptureOptions(options);
            regionCaptureOptions.ShowHotkeys = false;
            Image resultImage;
            using (RegionCaptureForm regionCaptureForm = new RegionCaptureForm(RegionCaptureMode.Default, regionCaptureOptions))
            {
                regionCaptureForm.Image_get = true;
                regionCaptureForm.Prepare();
                regionCaptureForm.ShowDialog();
                flag = regionCaptureForm.Mode_flag;
                resultImage = regionCaptureForm.GetResultImage();
            }
            return resultImage;
        }

        public static Image GetRegionImage_M(RegionCaptureOptions options, out string flag, out Point flag_location)
        {
            RegionCaptureOptions regionCaptureOptions = GetRegionCaptureOptions(options);
            regionCaptureOptions.ShowHotkeys = false;
            Image resultImage;
            using (RegionCaptureForm regionCaptureForm = new RegionCaptureForm(RegionCaptureMode.Default, regionCaptureOptions))
            {
                regionCaptureForm.Image_get = true;
                regionCaptureForm.Prepare();
                regionCaptureForm.ShowDialog();
                flag = regionCaptureForm.Mode_flag;
                resultImage = regionCaptureForm.GetResultImage();
                flag_location = regionCaptureForm.Point_flag;
            }
            return resultImage;
        }

        public static Image GetRegionImage_Mo(RegionCaptureOptions options, out string flag, out Point flag_location, out Rectangle[] rectangle_flag)
        {
            RegionCaptureOptions regionCaptureOptions = GetRegionCaptureOptions(options);
            regionCaptureOptions.ShowHotkeys = false;
            Image resultImage;
            using (RegionCaptureForm regionCaptureForm = new RegionCaptureForm(RegionCaptureMode.Default, regionCaptureOptions))
            {
                regionCaptureForm.Image_get = true;
                regionCaptureForm.Prepare();
                regionCaptureForm.ShowDialog();
                flag = regionCaptureForm.Mode_flag;
                resultImage = regionCaptureForm.GetResultImage();
                flag_location = regionCaptureForm.Point_flag;
                rectangle_flag = regionCaptureForm.Rectangle_flag;
            }
            return resultImage;
        }

        public static bool speedget_image = true;
    }
}
