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

namespace grid
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DemoEnt ent = new DemoEnt();
        private List<Product> products;

        public MainWindow()
        {
            InitializeComponent();
            ProductList.ItemsSource = ent.Product.ToList();
            products = ent.Product.ToList();
        }

        private void NavListView_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            
            switch(button.Name)
            {
                case "LeftBtn":
                    break;
                case "FirstBtn":
                    break;
                case "SecondBtn":
                    break;
                case "ThirdBtn":
                    break;
                case "RightBth":
                    break;
            }
        }
    }
}
