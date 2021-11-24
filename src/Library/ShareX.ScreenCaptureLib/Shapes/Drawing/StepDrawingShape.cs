﻿#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2018 ShareX Team

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
using System.Drawing.Text;

namespace ShareX.ScreenCaptureLib
{
    public class StepDrawingShape : EllipseDrawingShape
    {
        private const int DefaultSize = 30;

        public override ShapeType ShapeType { get; } = ShapeType.DrawingStep;

        public int FontSize { get; set; }
        public int Number { get; set; }
        public bool UseLetters { get; set; }

        public StepDrawingShape()
        {
            Rectangle = new Rectangle(0, 0, DefaultSize, DefaultSize);
        }

        public override void ShowNodes()
        {
        }

        public override void OnCreating()
        {
            Manager.IsMoving = true;
            Point pos = InputManager.ClientMousePosition;
            Rectangle = new Rectangle(new Point(pos.X - (Rectangle.Width / 2), pos.Y - (Rectangle.Height / 2)), Rectangle.Size);
        }

        public override void OnConfigLoad()
        {
            BorderColor = AnnotationOptions.StepBorderColor;
            BorderSize = AnnotationOptions.StepBorderSize;
            FillColor = AnnotationOptions.StepFillColor;
            Shadow = AnnotationOptions.Shadow;
            ShadowColor = AnnotationOptions.ShadowColor;
            ShadowOffset = AnnotationOptions.ShadowOffset;
            FontSize = AnnotationOptions.StepFontSize;
            UseLetters = AnnotationOptions.StepUseLetters;
        }

        public override void OnConfigSave()
        {
            AnnotationOptions.StepBorderColor = BorderColor;
            AnnotationOptions.StepBorderSize = BorderSize;
            AnnotationOptions.StepFillColor = FillColor;
            AnnotationOptions.Shadow = Shadow;
            AnnotationOptions.ShadowColor = ShadowColor;
            AnnotationOptions.ShadowOffset = ShadowOffset;
            AnnotationOptions.StepFontSize = FontSize;
            AnnotationOptions.StepUseLetters = UseLetters;
        }

        public override void OnDraw(Graphics g)
        {
            DrawNumber(g);
        }

        protected void DrawNumber(Graphics g)
        {
            string text = UseLetters ? Helpers.NumberToLetters(Number) : Number.ToString();

            using (Font font = new Font(FontFamily.GenericSansSerif, FontSize, FontStyle.Bold))
            {
                Size textSize = g.MeasureString(text, font).ToSize();
                int maxSize = Math.Max(textSize.Width, textSize.Height);
                int padding = 3;

                Point center = Rectangle.Center();
                Rectangle = new Rectangle(center.X - (maxSize / 2) - padding, center.Y - (maxSize / 2) - padding, maxSize + (padding * 2), maxSize + (padding * 2));

                DrawEllipse(g);

                if (Shadow)
                {
                    DrawNumber(g, text, font, ShadowColor, Rectangle.LocationOffset(ShadowOffset));
                }

                DrawNumber(g, text, font, BorderColor, Rectangle);
            }
        }

        protected void DrawNumber(Graphics g, string text, Font font, Color textColor, Rectangle rect)
        {
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            using (Brush textBrush = new SolidBrush(textColor))
            {
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                rect = rect.LocationOffset(0, 1);
                g.DrawString(text, font, textBrush, rect, sf);
                g.TextRenderingHint = TextRenderingHint.SystemDefault;
            }
        }

        public override void Resize(int x, int y, bool fromBottomRight)
        {
            Move(x, y);
        }
    }
}