using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using furniture_store.Database;

namespace furniture_store.Windows
{
    /// <summary>
    /// Логика взаимодействия для Store.xaml
    /// </summary>
    public partial class Store : Window
    {
        private List<Products> _products = RequestsDB.GetAllProducts();
        private bool OrderDescending = false;
        private bool OrderAscending = false;



        public Store()
        {
            InitializeComponent();
            ProductsListView.ItemsSource = _products;
        }

        private void BtnDescending_Click(object sender, RoutedEventArgs e)
        {
            OrderDescending = true;
            OrderAscending = false;
            SortData();
        }

        private void BtnDrop_Click(object sender, RoutedEventArgs e)
        {
            OrderDescending = false;
            OrderAscending = false;
            SortData();
        }

        private void BtnAscending_Click(object sender, RoutedEventArgs e)
        {
            OrderDescending = false;
            OrderAscending = true;
            SortData();
        }

        private void SortData()
        {
            if(OrderAscending)
            {
                ProductsListView.ItemsSource = _products.OrderBy(product => product.price);
            }
            else if(OrderDescending)
            {
                ProductsListView.ItemsSource = _products.OrderByDescending(product => product.price);
            }
            else
            {
                ProductsListView.ItemsSource = _products;
            }
        }

        private void CmbBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedIndex = CmbBoxType.SelectedIndex;
            if(SelectedIndex == 0)
            {
                _products = RequestsDB.GetAllProducts();
            }
            else if(SelectedIndex == 1)
            {
                _products = RequestsDB.GetProductsWithDiscound(0, 10);
            }
            else if (SelectedIndex == 2)
            {
                _products = RequestsDB.GetProductsWithDiscound(10, 15);
            }
            else if (SelectedIndex == 3)
            {
                _products = RequestsDB.GetProductsWithDiscound(15, 100);
            }
            SortData();
        }
    }
}
