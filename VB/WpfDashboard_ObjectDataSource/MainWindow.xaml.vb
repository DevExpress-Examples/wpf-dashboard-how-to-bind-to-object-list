Imports DevExpress.DashboardCommon
Imports System.Windows

Namespace WpfDashboard_ObjectDataSource

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim dashboard As Dashboard = CreateDashboard()
            Me.dashboardControl.Dashboard = dashboard
        End Sub

        Private Sub dashboardControl_AsyncDataLoading(ByVal sender As Object, ByVal e As DataLoadingEventArgs)
            If Equals(e.DataSourceName, "MyDataSource") Then e.Data = Data.CreateData()
        End Sub

        Private Function CreateDashboard() As Dashboard
            Dim dashboard As Dashboard = New Dashboard()
            Dim objectDataSource As DashboardObjectDataSource = New DashboardObjectDataSource("MyDataSource")
            objectDataSource.DataSource = GetType(Data)
            objectDataSource.DataMember = "CreateData"
            dashboard.DataSources.Add(objectDataSource)
            ' Creates a Pie dashboard item that displays a percentage of quantity summary for top 3 sales persons.
            Dim pies As PieDashboardItem = New PieDashboardItem()
            pies.DataSource = dashboard.DataSources(0)
            Dim salesPersonArgument As Dimension = New Dimension("SalesPerson")
            Dim quantity As Measure = New Measure("Quantity")
            pies.Arguments.Add(salesPersonArgument)
            salesPersonArgument.TopNOptions.Enabled = True
            salesPersonArgument.TopNOptions.Count = 3
            salesPersonArgument.TopNOptions.Measure = quantity
            pies.LabelPosition = PointLabelPosition.Inside
            pies.Values.Add(quantity)
            ' Creates a Grid dashboard item that displays sales persons and quantities.
            Dim grid As GridDashboardItem = New GridDashboardItem()
            grid.DataSource = dashboard.DataSources(0)
            grid.Columns.Add(New GridDimensionColumn(New Dimension("SalesPerson")))
            grid.Columns.Add(New GridMeasureColumn(New Measure("Quantity")))
            dashboard.Items.AddRange(pies, grid)
            Return dashboard
        End Function

        Private Sub simpleButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.dashboardControl.ReloadData()
        End Sub
    End Class
End Namespace
