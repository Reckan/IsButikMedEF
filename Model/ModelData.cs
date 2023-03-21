using DataClass;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ModelNS
{
    public class ModelData : DbContext
    {
        public DbSet<Vare> Varer { get; set; }
        private DbSet<Bestilling> Bestillinger { get; set; }

        public ObservableCollection<Bestilling> BestillingsList
        {
            get
            {
                if (Bestillinger.Local.Count == 0)
                {
                    Bestillinger.Load();
                }
                return Bestillinger.Local.ToObservableCollection();
            }
        }

        //public ReadOnlyObservableCollection<Bestilling> tt
        //{
        //    get
        //    {
        //        return BestillingsList as ReadOnlyObservableCollection<Bestilling>;
        //    }
        //}

        public ModelData() 
        {
        }

        public void AddBestilling(Bestilling bestilling)
        {
            BestillingsList.Add(bestilling);
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IsButikMedEF; Trusted_Connection = True; ");
        }
    }
}