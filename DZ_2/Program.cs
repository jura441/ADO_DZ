using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DZ_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataSet setCounter = new DataSet();
                DataSet setProduct = new DataSet();
                SqlDataAdapter adapterCounter = new SqlDataAdapter("SELECT * FROM Counter;", "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Initial Catalog = Storage;");
                SqlDataAdapter adapterProduct = new SqlDataAdapter("SELECT * FROM Counter;", "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Initial Catalog = Storage;");
                adapterCounter.Fill(setCounter);
                adapterProduct.Fill(setProduct);
                SqlCommandBuilder builderCounter = new SqlCommandBuilder(adapterCounter);
                SqlCommandBuilder builderProduct = new SqlCommandBuilder(adapterProduct);

                adapterCounter.InsertCommand = builderCounter.GetInsertCommand();
                adapterCounter.DeleteCommand = builderCounter.GetDeleteCommand();
                adapterCounter.UpdateCommand = builderCounter.GetUpdateCommand();

                adapterProduct.InsertCommand = builderProduct.GetInsertCommand();
                adapterProduct.DeleteCommand = builderProduct.GetDeleteCommand();
                adapterProduct.UpdateCommand = builderProduct.GetUpdateCommand();

                
                //DataRow dr = setCounter.Tables[0].NewRow();
                //dr.SetField(0, 2);
                //dr.SetField(1, "Много пластика");
                //dr.SetField(2, 40);
                //dr.SetField(3, DateTime.Now);

                //setCounter.Tables[0].Rows.Add(dr);
                //adapterCounter.Update(setCounter);

                //for (int i = 4; i < 100; i++)
                //{
                //    setCounter.Tables[0].Rows.Add(i, "Много пластика", 40,DateTime.Now);
                //}
                //adapterCounter.Update(setCounter);
                int maxcount = 0;
                int mincount = Int32.MaxValue;
                string counterName = "";
                string counterName2 = "";
                foreach (DataRow dr in setCounter.Tables[0].Rows)
                {
                    if (dr.Field<int>("Count") > maxcount)
                     {
                            maxcount = dr.Field<int>("Count");
                        counterName = dr.Field<string>("CounterName");
                     }
                    if (dr.Field<int>("Count") < mincount)
                    {
                        mincount = dr.Field<int>("Count");
                        counterName2 = dr.Field<string>("CounterName");
                    }
                }
                Console.WriteLine (counterName + " : " + maxcount + "tovarov");

                DataViewManager dvm = new DataViewManager(setCounter);
                DataView dv = dvm.CreateDataView(setCounter.Tables[0]);
                dv.RowFilter = " Count = MAX (Count)";
                Console.WriteLine (dv.Count);
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
            Console.ReadLine(); 
        }
    }
}