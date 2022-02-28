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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace grid.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private List<Product> products;

        private ushort skip = 0;
        private int take = 20;

        public ProductPage()
        {
            InitializeComponent();

            products = MainWindow.ent.Product.ToList();
            ProductList.ItemsSource = products.Take(take);

        }

        private void NavListView_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "LeftBtn":
                    if (products.Count >= skip)
                    {
                        if (skip - 20 >= 0)
                        {
                            if (skip >= 0)
                            {
                                if (skip != 0)
                                {
                                    skip -= 20;
                                }
                                ProductList.ItemsSource = products.Skip(skip).Take(take).ToList();
                            }
                            else
                            {
                                MessageBox.Show("Выход за рамки");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выход за рамки");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выход за рамки");
                    }
                    break;
                case "FirstBtn":

                    break;
                case "SecondBtn":

                    break;
                case "ThirdBtn":

                case "RightBtn":
                    if (products.Count - take >= skip)
                    {

                        ProductList.ItemsSource = products.Skip(skip).Take(take).ToList();
                        if (products.Count > skip)
                        {
                            skip += 20;
                        }
                        else
                        {
                            MessageBox.Show("Выход за рамки");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выход за рамки");
                    }
                    break;
            }
        }

        private void TextBoxSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            FilterSettings();
        }

        private void ContentBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            Product product = ProductList.SelectedItem as Product;

            switch (button.Name)
            {
                case "AddBtn":
                    NavigationService.Navigate(new AddEditProductPage(new Product(), false));
                    break;
                case "UpdateBtn":
                    if (product != null)
                    {
                        if (ProductList.SelectedItems.Count == 1)
                        {
                            NavigationService.Navigate(new AddEditProductPage(product, true));
                        }
                        else if (ProductList.SelectedItems.Count > 1)
                        {
                            var res = MessageBox.Show("Хотите изменить цену выбранных продуктов?", "Да или нет", MessageBoxButton.YesNo);
                            if (res == MessageBoxResult.Yes)
                            {
                                List<Product> pr = new List<Product>();

                                foreach (Product item in ProductList.SelectedItems)
                                {
                                    pr.Add(item);
                                }

                                NavigationService.Navigate(new EditCostProducts(pr));
                            }
                        }
                    }
                    break;
                case "DeleteBtn":
                    if (product != null)
                    {
                        var result = MessageBox.Show("Вы уверены?", "Да или нет", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            List<HistoryAgentSales> agentSales = MainWindow.ent.HistoryAgentSales.Where(c => c.Request_Product.IdProduct == product.Id).ToList();
                            List<Production> productions = MainWindow.ent.Production.Where(c => c.IdProduct == product.Id).ToList();

                            if (agentSales.Count == 0 && productions.Count == 0)
                            {
                                MainWindow.ent.Product.Remove(product);
                                MainWindow.ent.SaveChanges();
                                ProductList.ItemsSource = products.Take(take);
                            }
                            else
                            {
                                MessageBox.Show("Продукт не может быть удален так как задействован в других местах");
                            }
                        }
                    }
                    break;
            }
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortComboBox.SelectedIndex != -1)
            {
                if (UpRb.IsChecked == true)
                {
                    if (SortComboBox.SelectedIndex == 0)
                    {
                        ProductList.ItemsSource = products.OrderByDescending(i => i.Workshop).Take(take);
                    }
                    if (SortComboBox.SelectedIndex == 1)
                    {
                        ProductList.ItemsSource = products.OrderByDescending(i => i.MinCostForAgent).Take(take);
                    }
                    if (SortComboBox.SelectedIndex == 2)
                    {
                        ProductList.ItemsSource = products.OrderByDescending(i => i.Name).Take(take);
                    }
                }
                else if (DownRb.IsChecked == true)
                {
                    if (SortComboBox.SelectedIndex == 0)
                    {
                        ProductList.ItemsSource = products.OrderBy(i => i.Workshop).Take(take);
                    }
                    if (SortComboBox.SelectedIndex == 1)
                    {
                        ProductList.ItemsSource = products.OrderBy(i => i.MinCostForAgent).Take(take);
                    }
                    if (SortComboBox.SelectedIndex == 2)
                    {
                        ProductList.ItemsSource = products.OrderBy(i => i.Name).Take(take);
                    }
                }
            }
        }

        private void FiltrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterSettings();
        }

        private void FilterSettings()
        {
            if (TextBoxSearch.Text.Length != 0 && FiltrComboBox.SelectedIndex > 0)
            {
                ProductList.ItemsSource = MainWindow.ent.Product.Where(c => (c.Name.Contains(TextBoxSearch.Text) || c.Description.Contains(TextBoxSearch.Text)) && c.ProductType.Id == FiltrComboBox.SelectedIndex).ToList();
            }
            else if (TextBoxSearch.Text.Length == 0 && FiltrComboBox.SelectedIndex > 0)
            {
                ProductList.ItemsSource = MainWindow.ent.Product.Where(c => c.ProductType.Id == FiltrComboBox.SelectedIndex).ToList();
            }
            else if (TextBoxSearch.Text.Length != 0 && (FiltrComboBox.SelectedIndex == -1 || FiltrComboBox.SelectedIndex == 0))
            {
                ProductList.ItemsSource = MainWindow.ent.Product.Where(c => c.Name.Contains(TextBoxSearch.Text) || c.Description.Contains(TextBoxSearch.Text)).ToList();
            }
            else
            {
                ProductList.ItemsSource = products.Take(take);
            }
        }
    }
}
