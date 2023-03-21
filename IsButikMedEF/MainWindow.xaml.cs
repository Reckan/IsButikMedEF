using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IsButikMedEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Model Model { get; set; } = new();
        public ObservableCollection<Vare> VareList
        {
            get
            {
                return Model.Varer.Local.ToObservableCollection();
            }
        }
        public ObservableCollection<Bestilling> BestillingsList
        {
            get
            {
                return Model.Bestillinger.Local.ToObservableCollection();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Model = new Model();
            Model.Varer.Load();
            Model.Bestillinger.Load();
            DataContext = this;
        }

        private void BtnOpretIs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Vare vare = new()
                {
                    Navn = TbxNavn.Text,
                    Beskrivelse = TbxBeskrivelse.Text,
                    Pris = double.Parse(TbxPris.Text),

                };
                VareList.Add(vare);
                Model.SaveChanges();
                TbxNavn.Text = "";
                TbxPris.Text = "1";
                TbxBeskrivelse.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i oprettelse af vare");
            }
        }

        private void CbxIs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnBestil_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bestilling bestilling = new()
                {
                    Antal = int.Parse(TbxAntal.Text),
                    Bemærkninger = TbxBemærkninger.Text,
                    Vare = CbxIs.SelectedItem as Vare,

                };
                Model.Bestillinger.Add(bestilling);
                Model.SaveChanges();
                TbxAntal.Text = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i oprettelse af bestilling");
            }
        }
    }
}
