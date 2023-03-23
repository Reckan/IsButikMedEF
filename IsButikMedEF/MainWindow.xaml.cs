using DataClass;
using FuncLayer;
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
        public Func Func { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Func;
        }

        private void NyValgtVare(Vare vare)
        {
            if (vare != null)
            {
                Func.ValgtVare = vare;
            }
            else
            {
                Func.ValgtVare = null;
            }
        }

        private void BtnGemIs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Func.ValgtVareIRidiger == null)
                {
                    Func.OpretIs(TbxNavn.Text, double.Parse(TbxPris.Text), TbxBeskrivelse.Text);
                }
                else
                {
                    Func.RedigerVare(Func.ValgtVareIRidiger, TbxNavn.Text, double.Parse(TbxPris.Text), TbxBeskrivelse.Text);
                }
                VareTab.UpdateLayout();
                TbxNavn.Text = "";
                TbxPris.Text = "";
                TbxBeskrivelse.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i oprettelse af vare");
            }
        }

        private void CbxIs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NyValgtVare((Vare)CbxIs.SelectedItem);
        }

        private void BtnBestil_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Func.ValgtBestillingIRediger == null)
                {
                    Func.Bestil((Vare)CbxIs.SelectedItem, int.Parse(TbxAntal.Text), TbxBemærkninger.Text);
                }
                else
                {
                    Func.RedigerBestilling(Func.ValgtBestillingIRediger, (Vare)CbxIs.SelectedItem, int.Parse(TbxAntal.Text), TbxBemærkninger.Text);
                    // Change later
                    //DgBestillinger.Items.Refresh();
                }
                TbxAntal.Text = "1";
                TbxBemærkninger.Text = "";
                CbxIs.SelectedItem = null;
                VareTab.UpdateLayout();
                // Change later
                //DgVarer.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i oprettelse af bestilling");
            }
        }

        private void BtnSletVare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DgVarer.SelectedItem == null)
                {
                    throw new ArgumentNullException("Kan ikke slette en vare der ikke er valgt");
                }
                Func.SletValgtVare((Vare)DgVarer.SelectedItem);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Fejl ved slet");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl ved slet");
            }
        }

        private void BtnRediger_Click(object sender, RoutedEventArgs e)
        {
            Func.ValgtVareIRidiger = DgVarer.SelectedItem as Vare;

            TbxNavn.Text = (Func.ValgtVareIRidiger != null) ? Func.ValgtVareIRidiger.Navn : "";
            TbxPris.Text = Func.ValgtVareIRidiger?.Pris.ToString();
            TbxBeskrivelse.Text = Func.ValgtVareIRidiger?.Beskrivelse;
        }

        private void BtnRedigerBestilling_Click(object sender, RoutedEventArgs e)
        {
            Func.ValgtBestillingIRediger = DgBestillinger.SelectedItem as Bestilling;

            foreach (object v in CbxIs.Items)
            {
                Vare? vare = v as Vare;
                if (vare.Id == Func.ValgtBestillingIRediger.Vare.Id)
                {
                    CbxIs.SelectedItem = v;
                    break;
                }
            }

            TbxAntal.Text = Func.ValgtBestillingIRediger?.Antal.ToString();
            TbxBemærkninger.Text = Func.ValgtBestillingIRediger?.Bemærkninger;
        }

        private void BtnSletBestilling_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DgBestillinger.SelectedItem == null)
                {
                    throw new ArgumentNullException("Kan ikke slette en vare der ikke er valgt");
                }
                Func.SletValgtBestilling((Bestilling)DgBestillinger.SelectedItem);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Fejl ved slet");
            }
        }
    }
}
