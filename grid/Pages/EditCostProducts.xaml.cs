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
    /// Логика взаимодействия для EditCostProducts.xaml
    /// </summary>
    public partial class EditCostProducts : Page
    {
        List<Product> localPr;
        public EditCostProducts(List<Product> products)
        {
            InitializeComponent();

            localPr = products;

            CostTextBox.Text = MainWindow.ent.Product.ToList().Average(c => Convert.ToDecimal(c.MinCostForAgent.ToString().Replace(".",","))).ToString();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal cost = Convert.ToDecimal(CostTextBox.Text.Replace(".", ","));
                if (cost > 0)
                {
                    foreach (Product item in localPr)
                    {
                        item.MinCostForAgent = Convert.ToDecimal(CostTextBox.Text.Replace(".", ","));
                    }

                    MainWindow.ent.SaveChanges();
                    NavigationService.Navigate(new ProductPage());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректные данные");
            }
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
    }
}
