using Microsoft.EntityFrameworkCore;
using RealEstate.Models;
using RealEstateGUI.Repositories;
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
using WPF;

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataContext _dataContext;
        ObservableCollection<Seller> sellers = new();
        public SellerRepository repository { get; set; }
        public MainWindow()
        {
            _dataContext = new();
            repository = new (_dataContext);
            sellers = new ObservableCollection<Seller>(repository.GetAll());
            InitializeComponent();
            lbSellers.ItemsSource = sellers;
        }

        private void LoadAds(object sender, RoutedEventArgs e)
        {
           lblCount.Content = _dataContext
                .realestates
                .Include(a => a.seller)
                .Where(a => a.seller == lbSellers.SelectedItem)
                .Count()
                .ToString();
        }
    }
}
