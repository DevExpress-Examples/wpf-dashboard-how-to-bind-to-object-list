using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDashboard_ObjectDataSource
{
    public class Data
    {
        public string SalesPerson { get; set; }
        public int Quantity { get; set; }
        static Random rnd = new Random();
        public static List<Data> CreateData()
        {
            List<Data> data = new List<Data>();
            string[] salesPersons = { "Andrew Fuller", "Michael Suyama", "Robert King", "Nancy Davolio",
                "Margaret Peacock", "Laura Callahan", "Steven Buchanan", "Janet Leverling" };

            for (int i = 0; i < 100; i++)
            {
                Data record = new Data();
                //int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
                record.SalesPerson = salesPersons[rnd.Next(0, salesPersons.Length)];
                record.Quantity = rnd.Next(0, 100);
                data.Add(record);
            }
            return data;
        }
    }
}
