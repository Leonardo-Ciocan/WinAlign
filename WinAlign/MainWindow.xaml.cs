using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinAlign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void dropped(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                var target = files[0];
                var uriSource = new Uri(target, UriKind.Absolute);
                var bt = new BitmapImage(uriSource);
                this.Width = bt.Width;
                this.Height = bt.Height;
                image.Source = bt;
            }

        }

        private void wheelMoved(object sender, MouseWheelEventArgs e)
        {
            this.Opacity = Math.Min(0.1, this.Opacity + e.Delta);
        }
    }
}
