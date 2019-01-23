# How to Bind a Dashboard to a List<Data> Object.

This example demonstrates how to bind a dashboard to a List<Data> object.

The dashboard is created at runtime and assigned to the [DashboardControl.DashboardSource](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.DashboardSource) property within the _Window_Loaded_ event handler. The data are loaded within the [DashboardControl.AsyncDataLoading](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.AsyncDataLoading) event by assgning a System.Collections.Generic.List&lt;Data&gt; object to the [e.Data](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DataLoadingEventArgs.Data) property. 

The [DashboardControl.ReloadData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.ReloadData) method is called to refresh the data.

![](https://github.com/BrianDX/wpf-dashboard-how-to-bind-to-object-list/blob/18.1.3%2B/images/wpf-dashboard-how-to-bind-to-object-list.png)
