using StripsClientWPFReeksView.Models;
using StripsClientWPFReeksView.Services;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
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

namespace StripsClientWPFReeksView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StripServiceClient stripService;
        private string path;
        private SortDirection sortDirection = SortDirection.Ascending;
        
        public MainWindow()
        {
            InitializeComponent();
            stripService = new StripServiceClient("http://localhost:5044");
        }
        private async void GetReeksButton_Click(object sender, RoutedEventArgs e)
        {
            int reeksId;
            if (int.TryParse(ReeksIdTextBox.Text, out reeksId))
            {
                var reeks = await stripService.GetReeksById(reeksId);
                if (reeks != null || reeks.Strips != null)
                {
                    NaamTextBox.Text = reeks.Naam;
                    AantalTextBox.Text = reeks.Aantal.ToString();
                    
                    var sortedStrips = sortDirection == SortDirection.Ascending
                        ? reeks.Strips.OrderBy(strip => strip.Nr).ToList()
                        : reeks.Strips.OrderByDescending(strip => strip.Nr).ToList();

                    StripsDataGrid.ItemsSource = sortedStrips;
                    
                    sortDirection = sortDirection == SortDirection.Ascending
                        ? SortDirection.Descending
                        : SortDirection.Ascending;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Invalid ID", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
