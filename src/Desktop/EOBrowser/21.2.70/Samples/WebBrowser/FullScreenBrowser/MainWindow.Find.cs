using EO.WebBrowser;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FullScreenBrowser
{
    public partial class MainWindow
    {
        //Find Related Functions/Handlers
        private FindSession m_FindSession;

        private void Find_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (panFind.Visibility == Visibility.Visible)
            {
                StopFind();
            }
            else
            {
                panFind.Visibility = Visibility.Visible;
                txtFind.Focus();
            }
        }

        private void txtFind_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Find(true);
        }

        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            StopFind(false);
        }

        private void btnFindPrevious_Click(object sender, RoutedEventArgs e)
        {
            Find(false);
        }

        private void btnFindNext_Click(object sender, RoutedEventArgs e)
        {
            Find(true);
        }

        private void btnFindClose_Click(object sender, RoutedEventArgs e)
        {
            StopFind();
        }

        private void Find(bool forward)
        {
            string txtToFind = txtFind.Text.Trim();
            if (txtToFind == string.Empty)
                return;

            if (m_FindSession == null)
            {
                m_FindSession = m_CurPage.WebView.StartFindSession(txtToFind, false);
                m_FindSession.Updated += FindSession_Updated;
            }
            else if (forward)
                m_FindSession.Next();
            else
                m_FindSession.Previous();
        }

        private void FindSession_Updated(object sender, EventArgs e)
        {
            UpdateFindUI();
        }

        private void StopFind(bool hideFindPanel = true)
        {
            if (hideFindPanel)
                panFind.Visibility = Visibility.Collapsed;
            if (m_FindSession != null)
            {
                m_FindSession.Stop();
                m_FindSession.Updated -= FindSession_Updated;
                m_FindSession = null;
            }
            UpdateFindUI();
        }

        private void UpdateFindUI()
        {
            string txtToFind = txtFind.Text.Trim();
            if (txtToFind == string.Empty)
            {
                btnFindPrevious.IsEnabled = false;
                btnFindNext.IsEnabled = false;
                lbFindCount.Content = string.Empty;
            }
            else if (m_FindSession == null)
            {
                btnFindPrevious.IsEnabled = false;
                btnFindNext.IsEnabled = true;
                lbFindCount.Content = string.Empty;
            }
            else
            {
                btnFindPrevious.IsEnabled = m_FindSession.MatchCount > 0;
                btnFindNext.IsEnabled = m_FindSession.MatchCount > 0;
                lbFindCount.Content = string.Format("{0}/{1}", m_FindSession.CurrentMatchIndex + 1, m_FindSession.MatchCount);
            }
        }
    }
}
