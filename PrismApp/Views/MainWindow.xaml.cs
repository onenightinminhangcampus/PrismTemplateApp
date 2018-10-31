using System;
using System.Data;
using System.Windows;
using Prism.Regions;
using PrismApp.Common;
using PrismApp.Infrastructure;
namespace PrismApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            if (regionManager != null)
            {
                regionManager.RegisterViewWithRegion(RegionNames.DataRegion, typeof(DataView));
                regionManager.RegisterViewWithRegion(RegionNames.ChartRegion, typeof(ChartView));
                regionManager.RegisterViewWithRegion(RegionNames.ControlRegion, typeof(ControlView));

            }
        }




    }
}
