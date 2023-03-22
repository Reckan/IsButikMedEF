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
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(ValgtVare)));
                }
            }
        }
        private Vare? _ValgtVareIRidiger;
        public Vare? ValgtVareIRidiger
        {
            get
            {
                return _ValgtVareIRidiger;
            }
            set
            {
                _ValgtVareIRidiger = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(ValgtVareIRidiger)));
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
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(ValgtBestilling)));
                }
            }
        }
        private Bestilling? _ValgtBestillingIRediger;
        public Bestilling? ValgtBestilligeIRediger
        {
            get
            {
                return _ValgtBestillingIRediger;
            }
            set
            {
                _ValgtBestillingIRediger = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(ValgtBestilligeIRediger)));
                }
            }
        }
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
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
            ValidateVare(vare);
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

            ValidateBestilling(bestilling);
            Model.AddBestilling(bestilling);
            PropertyChanged(vare.Bestillinger, new PropertyChangedEventArgs(nameof(vare.Bestillinger.Count)));
            RaisePropertyChanged(nameof(VareList));
        }
        public void SletValgtVare(Vare vare)
        {
            Model.RemoveVare(vare);
        }
        public void SletValgtBestilling(Bestilling bestilling)
        {
            Model.RemoveBestilling(bestilling);
        }
        public void RedigerVare(Vare vare, Vare vareInfo)
        {
            Model.RemoveVare(vareInfo);
            RaisePropertyChanged(nameof(VareList));
        }
        public void RedigerBestilling(Bestilling bestilling, Bestilling bestillingsInfo)
        {
            Model.RemoveBestilling(bestillingsInfo);
            RaisePropertyChanged(nameof(BestillingsList));
        }
        private void ValidateVare(Vare vareInfo)
        {
            if (vareInfo.Navn == "")
            {
                throw new Exception("Vare skal have et Produkt Navn");
            }
            if (vareInfo.Pris < 1)
            {
                throw new Exception("Vare kan ikke koste mindre end 1");
            }
            if (vareInfo.Beskrivelse == "")
            {
                throw new Exception("Vare skal Indeholde en Beskrivelse");
            }
            foreach (Vare vare1 in VareList)
            {
                if (vareInfo.Navn == vare1.Navn)
                {
                    throw new Exception("Denne vare findes allerde");
                }
            }
        }
        private void ValidateBestilling(Bestilling bestillingsInfo)
        {
            if(bestillingsInfo.Vare == null)
            {
                throw new ArgumentNullException("Skal Vælge en Vare");
            }
            if(bestillingsInfo.Antal < 1)
            {
                throw new Exception("Kan ikke bestille Mindrere end 1 vare");
            }
        }
    }
}