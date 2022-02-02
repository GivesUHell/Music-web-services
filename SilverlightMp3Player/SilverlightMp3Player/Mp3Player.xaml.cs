using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace SilverlightMp3Player
{
    public partial class Mp3Player : UserControl
    {
        private Boolean isPlaying = false;
        private Boolean isOpened = false;
        private Boolean mediaOpened = false;

        private Boolean isMouseDown = false;

        private String Title;
        private Uri uri;

        private Boolean FirstPlay = true;
        private Storyboard _timer = new Storyboard();

        public Mp3Player()
        {
            InitializeComponent();
            _timer.Duration = TimeSpan.FromMilliseconds(0.1);
            _timer.Completed += new EventHandler(_timer_Completed);
            Media.DownloadProgressChanged += new RoutedEventHandler(Media_DownloadProgressChanged);
            Media.MediaOpened += new RoutedEventHandler(Media_MediaOpened);
            Media.CurrentStateChanged += new RoutedEventHandler(Media_CurrentStateChanged);
        }

        void Media_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (Media.CurrentState != MediaElementState.Playing)
            {
                TitleDisplay.Text = "Buffering ...";
            }
            else
            {
                TitleDisplay.Text = this.Title;
            }
        }

        void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            this.mediaOpened = true;
            if (this.isOpened == true)
            {
                this.MediaPlay();
            }
        }

        private void Media_DownloadProgressChanged(Object sender, RoutedEventArgs e)
        {
            MediaElement me = (MediaElement)sender;
            DownloadProgressBar.Value = me.DownloadProgress;
        }

        void _timer_Completed(object sender, EventArgs e)
        {
            if (Media.CurrentState == MediaElementState.Playing)
            {
                SongProgressBar.Value = (1 / Media.NaturalDuration.TimeSpan.TotalSeconds) * Media.Position.TotalSeconds;
                TimeDisplay.Text = string.Format("{0:00}:{1:00}", Media.Position.Minutes, Media.Position.Seconds);
            }
            _timer.Begin();
        }

        public void SetData(String uriString, String title)
        {
            this.uri = new Uri(uriString);
            this.Title = title;
        }

        private void PlayPauseButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.uri != null)
            {
                if (this.isPlaying == false)
                {
                    if (this.isOpened == false)
                    {
                        this.OpenPlayerAnim();
                        if (this.FirstPlay == true)
                        {
                            Media.Source = this.uri;
                            this.FirstPlay = false;
                        }
                        if (this.mediaOpened == true)
                        {
                            this.MediaPlay();
                        }
                    }
                    else
                    {
                        this.ClosePlayerAnim();
                        this.MediaPause();
                    }
                }
                else
                {
                    this.ClosePlayerAnim();
                    this.MediaPause();
                }
            }
        }

        private void OpenPlayerAnim()
        {
            TitleDisplay.Text = "Buffering ...";
            this.isOpened = true;
            VolumeControl.Visibility = Visibility.Visible;
            TextLeft.Visibility = Visibility.Collapsed;
            OpenPlayer.Begin();
        }

        private void ClosePlayerAnim()
        {
            this.isOpened = false;
            VolumeControl.Visibility = Visibility.Collapsed;
            TextLeft.Visibility = Visibility.Visible;
            ClosePlayer.Begin();
        }

        private void MediaPlay()
        {
            TitleDisplay.Text = this.Title;
            Media.Play();
            _timer.Begin();
            PlayPauseButton.Text = ";";
            this.isPlaying = true;
        }

        private void MediaPause()
        {
            Media.Pause();
            _timer.Stop();
            PlayPauseButton.Text = "4";
            this.isPlaying = false;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border b = (Border)sender;
            b.Background = new SolidColorBrush(Colors.Orange);
            PlayPauseButton.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border b = (Border)sender;
            b.Background = new SolidColorBrush(Colors.Gray);
            PlayPauseButton.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void ProgressBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border b = (Border)sender;
            Point p = e.GetPosition(b);
            Double pourcentPosition = p.X / b.ActualWidth * 100;
            if (pourcentPosition >= DownloadProgressBar.Value * 100)
            {
                pourcentPosition = DownloadProgressBar.Value * 100;
            }
            Media.Position = TimeSpan.FromSeconds(Media.NaturalDuration.TimeSpan.TotalSeconds / 100 * pourcentPosition);
        }

        private void VolumeControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid g = (Grid)sender;
            g.CaptureMouse();
            this.isMouseDown = true;
            VolumeLevel.Background = new SolidColorBrush(Colors.Orange);
        }

        private void VolumeControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isMouseDown == true)
            {
                Grid g = (Grid)sender;
                if(e.GetPosition(g).X > 0 && e.GetPosition(g).X < g.ActualWidth){
                    VolumeLevel.Width = e.GetPosition(g).X;
                }else if(e.GetPosition(g).X <=0){
                    VolumeLevel.Width = 0;
                }else if(e.GetPosition(g).X >= g.ActualWidth){
                    VolumeLevel.Width = g.ActualWidth;
                }
                Media.Volume = 1 / g.ActualWidth * VolumeLevel.Width;
            }
        }

        private void VolumeControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid g = (Grid)sender;
            g.ReleaseMouseCapture();
            this.isMouseDown = false;
            VolumeLevel.Background = new SolidColorBrush(Colors.Black);
        }

        private void VolumeControl_MouseEnter(object sender, MouseEventArgs e)
        {
            VolumeLevel.Background = new SolidColorBrush(Colors.Orange);
        }

        private void VolumeControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.isMouseDown == false)
            {
                VolumeLevel.Background = new SolidColorBrush(Colors.Black);
            }
        }
    }
}