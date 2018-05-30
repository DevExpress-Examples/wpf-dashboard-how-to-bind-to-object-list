Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace WpfDashboard_ObjectDataSource
    Public Class Data
        Public Property SalesPerson() As String
        Public Property Quantity() As Integer
        Private Shared rnd As New Random()
        Public Shared Function CreateData() As List(Of Data)

            Dim data_Renamed As New List(Of Data)()
            Dim salesPersons() As String = { "Andrew Fuller", "Michael Suyama", "Robert King", "Nancy Davolio", "Margaret Peacock", "Laura Callahan", "Steven Buchanan", "Janet Leverling" }

            For i As Integer = 0 To 99
                Dim record As New Data()
                'int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
                record.SalesPerson = salesPersons(rnd.Next(0, salesPersons.Length))
                record.Quantity = rnd.Next(0, 100)
                data_Renamed.Add(record)
            Next i
            Return data_Renamed
        End Function
    End Class
End Namespace
