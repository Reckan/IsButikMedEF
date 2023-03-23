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
        public Bestilling? ValgtBestillingIRediger
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
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(ValgtBestillingIRediger)));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

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
            //PropertyChanged(vare.Bestillinger, new PropertyChangedEventArgs(nameof(vare.Bestillinger.Count)));
            RaisePropertyChanged(nameof(VareList));
        }
        public void SletValgtVare(Vare vare)
        {
            CheckIfDeletable(vare);
            Model.RemoveVare(vare);
        }
        public void SletValgtBestilling(Bestilling bestilling)
        {
            Model.RemoveBestilling(bestilling);
        }
        public void RedigerVare(Vare vare, string navn, double pris, string beskrivelse)
        {
            vare.Navn = navn;
            vare.Pris = pris;
            vare.Beskrivelse = beskrivelse;
            Model.Update();
            RaisePropertyChanged(nameof(VareList));
            RaisePropertyChanged(nameof(BestillingsList));
        }
        public void RedigerBestilling(Bestilling bestilling, Vare vare, int antal, string bemærkning)
        {
            bestilling.Vare = vare;
            bestilling.Antal = antal;
            bestilling.Bemærkninger = bemærkning;
            Model.Update();
            RaisePropertyChanged(nameof(BestillingsList));
            RaisePropertyChanged(nameof(VareList));
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
            if (bestillingsInfo.Vare == null)
            {
                throw new ArgumentNullException("Skal Vælge en Vare");
            }
            if (bestillingsInfo.Antal < 1)
            {
                throw new Exception("Kan ikke bestille Mindrere end 1 vare");
            }
        }
        private void CheckIfDeletable(Vare vare)
        {
            foreach (Bestilling bestilling in BestillingsList)
            {
                if (bestilling.Vare.Id == vare.Id)
                {
                    throw new Exception("Kan ikke slette en Vare men en eller flere aktiv Bestillinger");
                }
            }
        }
    }
}