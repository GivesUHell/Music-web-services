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

namespace SilverlightMp3Player
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Mp3Player mp3p = new Mp3Player();
            mp3p.SetData("http://www.weblastout.com/download/download.php?f=Thriller%20%28Stern*%20Remix%29.mp3", "Thriller (Stern* remix)");
            LayoutRoot.Children.Add(mp3p);
        }
    }
}
