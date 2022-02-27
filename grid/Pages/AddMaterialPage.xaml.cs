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
    /// Логика взаимодействия для AddMaterialPage.xaml
    /// </summary>
    public partial class AddMaterialPage : Page
    {
        Product localProduct;

        public AddMaterialPage(Product product)
        {
            InitializeComponent();


            localProduct = product;

            MaterialComboBox.ItemsSource = MainWindow.ent.Material.ToList();
            MaterialList.ItemsSource = MainWindow.ent.Production.Where(c => c.IdProduct == localProduct.Id).ToList();
        }

        private void AddMaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialComboBox.SelectedIndex != -1)
            {
                Production production = new Production();

                production.IdProduct = localProduct.Id;
                production.IdMaterial = (MaterialComboBox.SelectedItem as Material).Id;
                production.Count = Convert.ToInt32(CountTextBox.Text);

                MainWindow.ent.Production.Add(production);
                MainWindow.ent.SaveChanges();

                MaterialList.ItemsSource = MainWindow.ent.Production.Where(c => c.IdProduct == localProduct.Id).ToList();
            }
        }

        private void RemoveMaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            Production material = MaterialList.SelectedItem as Production;

            if (material != null)
            {
                var result = MessageBox.Show("Вы уверены?", "Да или нет", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MainWindow.ent.Production.Remove(material);
                    MainWindow.ent.SaveChanges();

                    MaterialList.ItemsSource = MainWindow.ent.Production.Where(c => c.IdProduct == localProduct.Id).ToList();
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage(localProduct, true));
        }
    }
}
