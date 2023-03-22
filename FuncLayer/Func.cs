using DataClass;
using Microsoft.EntityFrameworkCore;
using ModelNS;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FuncLayer
{
    public class Func : INotifyPropertyChanged
    {
        public ModelData Model { get; set; } = new();

        public ReadOnlyObservableCollection<Vare> VareList
        {
            get
            {
                return Model.VareList;
            }
        }
        public ReadOnlyObservableCollection<Bestilling> BestillingsList
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
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(ValgtVare)));
                }
            }
        }

        private Bestilling? _ValgtBestilling;
        public Bestilling? ValgtBestilling
        {
            get
            {
                return _ValgtBestilling;
            }
            set
            {
                _ValgtBestilling = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(ValgtBestilling)));
                }
            }
        }
        private void RaisePropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OpretIs(string navn, double pris, string beskrivelse = "")
        {
            Vare vare = new()
            {
                Navn = navn,
                Beskrivelse = beskrivelse,
                Pris = pris,
            };
            Model.AddVare(vare);
        }
        public void Bestil(Vare vare, int antal, string bemærkning)
        {
            Bestilling bestilling = new()
            {
                Antal = antal,
                Bemærkninger = bemærkning,
                Vare = vare,
            };

            Model.AddBestilling(bestilling);
            PropertyChanged(vare.Bestillinger, new PropertyChangedEventArgs(nameof(vare.Bestillinger.Count)));
            RaisePropertyChanged(nameof(VareList));
        }
    }
}