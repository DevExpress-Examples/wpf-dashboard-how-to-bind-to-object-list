Imports DevExpress.DashboardCommon
Imports System.Windows

Namespace WpfDashboard_ObjectDataSource
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim dashboard As Dashboard = CreateDashboard()
            dashboardControl.Dashboard = dashboard
        End Sub
        Private Sub dashboardControl_AsyncDataLoading(ByVal sender As Object, ByVal e As DataLoadingEventArgs)
            If e.DataSourceName = "MyDataSource" Then
                e.Data = Data.CreateData()
            End If
        End Sub

        Private Function CreateDashboard() As Dashboard
            Dim dashboard As New Dashboard()
            Dim objectDataSource As New DashboardObjectDataSource("MyDataSource")
            objectDataSource.DataSource = GetType(Data)
            objectDataSource.DataMember = "CreateData"
            dashboard.DataSources.Add(objectDataSource)

            ' Creates a Pie dashboard item that displays a percentage of quantity summary for top 3 sales persons.
            Dim pies As New PieDashboardItem()
            pies.DataSource = dashboard.DataSources(0)
            Dim salesPersonArgument As New Dimension("SalesPerson")
            Dim quantity As New Measure("Quantity")
            pies.Arguments.Add(salesPersonArgument)
            salesPersonArgument.TopNOptions.Enabled = True
            salesPersonArgument.TopNOptions.Count = 3
            salesPersonArgument.TopNOptions.Measure = quantity
            pies.LabelPosition = PointLabelPosition.Inside
            pies.Values.Add(quantity)

            ' Creates a Grid dashboard item that displays sales persons and quantities.
            Dim grid As New GridDashboardItem()
            grid.DataSource = dashboard.DataSources(0)
            grid.Columns.Add(New GridDimensionColumn(New Dimension("SalesPerson")))
            grid.Columns.Add(New GridMeasureColumn(New Measure("Quantity")))

            dashboard.Items.AddRange(pies, grid)
            Return dashboard
        End Function

        Private Sub simpleButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            dashboardControl.ReloadData()
        End Sub
    End Class
End Namespace
