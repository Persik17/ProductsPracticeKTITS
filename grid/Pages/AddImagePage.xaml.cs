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
    /// Логика взаимодействия для AddImagePage.xaml
    /// </summary>
    public partial class AddImagePage : Page
    {
        Product localProduct;
        public AddImagePage(Product product)
        {
            InitializeComponent();

            localProduct = product;

            ImageList.ItemsSource = MainWindow.ent.Image.ToList();
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            Image image = ImageList.SelectedItem as Image;

            if (image != null)
            {
                localProduct.Image = image.Id;

                MainWindow.ent.SaveChanges();

                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Картинка не выбрана");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage(localProduct, true));
        }
    }
}
