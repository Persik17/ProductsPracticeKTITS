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
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        public bool localIsEdit;
        public Product localProd;
        public AddEditProductPage(Product product, bool isEdit)
        {
            InitializeComponent();

            localProd = product;
            localIsEdit = isEdit;

            DataContext = localProd;

            TypeProductComboBox.ItemsSource = MainWindow.ent.ProductType.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.Content is ProductPage)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.Navigate(new ProductPage());
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TypeProductComboBox.SelectedIndex != -1)
            {
                if (!string.IsNullOrEmpty(MinCostProductTextBox.Text) && Convert.ToDecimal(MinCostProductTextBox.Text.Replace(".", ",")) < 0)
                {
                    List<Product> article = MainWindow.ent.Product.Where(c => c.ArticleNumber == ArticleProductTextBox.Text).ToList();

                    if (localIsEdit)
                    {
                        if (article.Count > 1)
                        {
                            localProd.Name = NameProductTextBox.Text;
                            localProd.Description = DescriptionProductTextBox.Text;
                            localProd.ArticleNumber = ArticleProductTextBox.Text;
                            localProd.IdProductType = (TypeProductComboBox.SelectedItem as ProductType).Id;
                            localProd.MinCostForAgent = Convert.ToDecimal(MinCostProductTextBox.Text.Replace(".", ","));
                            localProd.Workshop = Convert.ToInt32(WorkshopProductTextBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("такой артикул уже существует");
                        }
                    }
                    else
                    {
                        if (article.Count == 0)
                        {
                            localProd.Name = NameProductTextBox.Text;
                            localProd.Description = DescriptionProductTextBox.Text;
                            localProd.ArticleNumber = ArticleProductTextBox.Text;
                            localProd.IdProductType = (TypeProductComboBox.SelectedItem as ProductType).Id;
                            localProd.MinCostForAgent = Convert.ToDecimal(MinCostProductTextBox.Text.Replace(".", ","));
                            localProd.Workshop = Convert.ToInt32(WorkshopProductTextBox.Text);

                            MainWindow.ent.Product.Add(localProd);
                        }
                        else
                        {
                            MessageBox.Show("Такой артикул уже существует");
                        }
                    }
                    MainWindow.ent.SaveChanges();
                    NavigationService.Navigate(new ProductPage());

                }
                else
                {
                    MessageBox.Show("Цена не может быть отрицательной");
                }
            }
            else
            {
                MessageBox.Show("Тип не заполнен");
            }
        }

        private void AddMaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TypeProductComboBox.SelectedIndex != -1)
            {
                if (!string.IsNullOrEmpty(MinCostProductTextBox.Text) && Convert.ToDecimal(MinCostProductTextBox.Text.Replace(".", ",")) > 0)
                {
                        if (!localIsEdit)
                        {
                            MainWindow.ent.SaveChanges();
                        }
                        NavigationService.Navigate(new AddMaterialPage(localProd));
                }
                else
                {
                    MessageBox.Show("Цена не может быть отрицательной");
                }
            }
            else
            {
                MessageBox.Show("Тип не заполнен");
            }
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddImagePage(localProd));
        }

        private void CountPeopleForProductionProductTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890.,".IndexOf(e.Text) < 0;
        }
    }
}
