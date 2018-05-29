This example demonstrates how to bind a dashboard to a List<Data> object.

The dashboard is created at runtime and assigned to the [DashboardControl.DashboardSource](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.DashboardSource) property within the _Window_Loaded_ event handler. The data source is initialized and assigned within the [DashboardControl.AsyncDataLoading](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.AsyncDataLoading) event to the [e.DataSourceName](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DataLoadingEventArgs.DataSourceName) property. 

Use the [DashboardControl.ReloadData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.ReloadData) method to refresh the data.

>To handle security risks when loading an object data source, specify the [DashboardControl.ObjectDataSourceLoadingBehavior](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.ObjectDataSourceLoadingBehavior) property.

![](https://github.com/BrianDX/wpf-dashboard-how-to-bind-to-object-list/blob/18.1.3%2B/images/wpf-dashboard-how-to-bind-to-object-list.png)