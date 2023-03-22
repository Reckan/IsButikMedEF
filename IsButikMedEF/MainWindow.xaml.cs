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

        private void BtnOpretIs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Func.OpretIs(TbxNavn.Text, double.Parse(TbxPris.Text), TbxBeskrivelse.Text);

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
                Func.Bestil((Vare)CbxIs.SelectedItem, int.Parse(TbxAntal.Text), TbxBemærkninger.Text);
                TbxAntal.Text = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i oprettelse af bestilling");
            }
        }
    }
}
