using DevExpress.DashboardCommon;
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

namespace WpfDashboard_ObjectDataSource
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dashboardControl.ObjectDataSourceLoadingBehavior = DevExpress.DataAccess.DocumentLoadingBehavior.LoadAsIs;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = CreateDashboard();
            dashboardControl.Dashboard = dashboard;
        }
        private void dashboardControl_AsyncDataLoading(object sender, DataLoadingEventArgs e)
        {
            if (e.DataSourceName == "MyDataSource")
                e.Data = Data.CreateData();
        }

        private Dashboard CreateDashboard()
        {
            Dashboard dashboard = new Dashboard();
            DashboardObjectDataSource objectDataSource = new DashboardObjectDataSource("MyDataSource");
            objectDataSource.DataSource = typeof(Data);
            objectDataSource.DataMember = "CreateData";
            dashboard.DataSources.Add(objectDataSource);

            // Creates a Pie dashboard item that displays a percentage of quantity summary for top 3 sales persons.
            PieDashboardItem pies = new PieDashboardItem();
            pies.DataSource = dashboard.DataSources[0];
            Dimension salesPersonArgument = new Dimension("SalesPerson");
            Measure quantity = new Measure("Quantity");
            pies.Arguments.Add(salesPersonArgument);
            salesPersonArgument.TopNOptions.Enabled = true;
            salesPersonArgument.TopNOptions.Count = 3;
            salesPersonArgument.TopNOptions.Measure = quantity;
            pies.LabelPosition = PointLabelPosition.Inside;
            pies.Values.Add(quantity);

            // Creates a Grid dashboard item that displays sales persons and quantities.
            GridDashboardItem grid = new GridDashboardItem();
            grid.DataSource = dashboard.DataSources[0];
            grid.Columns.Add(new GridDimensionColumn(new Dimension("SalesPerson")));
            grid.Columns.Add(new GridMeasureColumn(new Measure("Quantity")));

            dashboard.Items.AddRange(pies, grid);
            return dashboard;
        }

        private void simpleButton_Click(object sender, RoutedEventArgs e)
        {
            dashboardControl.ReloadData();
        }
    }
}
