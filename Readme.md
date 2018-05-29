This example demonstrates how to bind a dashboard to a List<Data> object.

The dashboard is created at runtime and assigned to the [DashboardControl.DashboardSource](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.DashboardSource) property within the _Window_Loaded_ event handler. The data source is initialized and assigned within the [DashboardControl.AsyncDataLoading](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.AsyncDataLoading) event to the [e.DataSourceName]](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DataLoadingEventArgs.DataSourceName) property. 

Use the [DashboardControl.ReloadData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.ReloadData) method to refresh the data.

>![NOTE]
>To handle security risks when loading an object data source, specify the DevExpress.DashboardWpf.DashboardControl.ObjectDataSourceLoadingBehavior property.

![](~/images/wpf-dashboard-how-to-bind-to-object-list.png)