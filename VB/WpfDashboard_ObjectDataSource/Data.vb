Imports System
Imports System.Collections.Generic

Namespace WpfDashboard_ObjectDataSource

    Public Class Data

        Public Property SalesPerson As String

        Public Property Quantity As Integer

        Private Shared rnd As Random = New Random()

        Public Shared Function CreateData() As List(Of Data)
            Dim data As List(Of Data) = New List(Of Data)()
            Dim salesPersons As String() = {"Andrew Fuller", "Michael Suyama", "Robert King", "Nancy Davolio", "Margaret Peacock", "Laura Callahan", "Steven Buchanan", "Janet Leverling"}
            For i As Integer = 0 To 100 - 1
                Dim record As Data = New Data()
                'int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
                record.SalesPerson = salesPersons(rnd.Next(0, salesPersons.Length))
                record.Quantity = rnd.Next(0, 100)
                data.Add(record)
            Next

            Return data
        End Function
    End Class
End Namespace
