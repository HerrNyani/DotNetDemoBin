using System;
using System.Windows;

namespace DotNetDemoBin.Wpf.PeriodicPropertyBindingUpdateWithBehaviorDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public DateTime NowDateTime => DateTime.Now;
    }
}
