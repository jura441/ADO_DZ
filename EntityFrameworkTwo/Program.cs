using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddFruits(new fandv(53, "name53", "fruits", "orange", 339));
           GetAllFruits();
           Console.ReadLine();
        }

        static void AddFruits(fandv item)
        {
            using (FuitsandVegetablesEntities fandvEntities = new FuitsandVegetablesEntities())
            {
                fandv exist = fandvEntities.fandv.Where((x) => x.Id == item.Id && x.Name == item.Name).FirstOrDefault();
                if (exist == null)
                {
                    fandvEntities.fandv.Add(item);
                    fandvEntities.SaveChanges();
                }
            }
        }

        static void GetAllFruits()
        {
            using (FuitsandVegetablesEntities fandventities = new FuitsandVegetablesEntities())
            {
                List<fandv> list = fandventities.fandv.ToList();
                foreach (fandv item in list)
                {
                    if (item.Type == "fruits")
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
        static void MyTransaction()
        {
            using (FuitsandVegetablesEntities fandvEntities = new FuitsandVegetablesEntities())

            {
                using (System.Data.Entity.DbContextTransaction tran =fandvEntities.Database.BeginTransaction())
                try
                    {
                    fandv fav = new fandv(54, "name54", "fruits", "green", 152);
                    fandvEntities.fandv.Add(fav);
                    fandvEntities.fandv.Remove(fav);
                    fandvEntities.SaveChanges();
                    tran.Commit();
                    }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
                
            }
        }
    }
}
