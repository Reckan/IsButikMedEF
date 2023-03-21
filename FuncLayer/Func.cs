using DataClass;
using Microsoft.EntityFrameworkCore;
using ModelNS;
using System.Collections.ObjectModel;

namespace FuncLayer
{
    public class Func
    {
        public ModelData Model { get; set; } = new();

        public ObservableCollection<Vare> VareList
        {
            get
            {
                if (Model.Varer.Local.Count == 0)
                {
                    Model.Varer.Load();
                }
                return Model.Varer.Local.ToObservableCollection();
            }
        }
        public ObservableCollection<Bestilling> BestillingsList
        {
            get
            {                
                return Model.BestillingsList;
            }
        }
        private Vare? _ValgtVare;
        public Vare? ValgtVare
        {
            get
            {
                return _ValgtVare;
            }
            set
            {
                _ValgtVare = value;
                if(value != null)
                {

                }
            }
        }


        public void OpretIs(Vare vare)
        {
            Model.SaveChanges();
        }
        public void Bestil(Bestilling bestilling)
        {
            Model.AddBestilling(bestilling);
        }
    }
}