using DataClass;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ModelNS
{
    public class ModelData : DbContext
    {
        public DbSet<Vare> Varer { get; set; }
        private DbSet<Bestilling> Bestillinger { get; set; }

        private ObservableCollection<Bestilling> Bestillings
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
        private ObservableCollection<Vare> VarerList
        {
            get
            {
                if (Varer.Local.Count == 0)
                {
                    Varer.Load();
                }
                return Varer.Local.ToObservableCollection();
            }
        }
        private readonly ReadOnlyObservableCollection<Bestilling> _BestillingsList;
        public ReadOnlyObservableCollection<Bestilling> BestillingsList
        {
            get
            {
                return _BestillingsList;
            }
        }
        private readonly ReadOnlyObservableCollection<Vare> _VareList;
        public ReadOnlyObservableCollection<Vare> VareList
        {
            get
            {
                return _VareList;
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
            _BestillingsList = new ReadOnlyObservableCollection<Bestilling>(Bestillings);
            _VareList = new ReadOnlyObservableCollection<Vare>(VarerList);
        }

        public void AddBestilling(Bestilling bestilling)
        {
            Bestillinger.Add(bestilling);
            SaveChanges();
        }

        public void AddVare(Vare vare)
        {
            Varer.Add(vare);
            SaveChanges();
        }

        public void RemoveVare(Vare vare)
        {
            Varer.Remove(vare);
            SaveChanges();
        }

        public void RemoveBestilling(Bestilling bestilling)
        {
            Bestillinger.Remove(bestilling);
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IsButikMedEF; Trusted_Connection = True; ");
        }
    }
}