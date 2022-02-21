using grid.Pages;
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

        ushort skip = 0;
        int take = 20;

        public MainWindow()
        {
            InitializeComponent();

            products = ent.Product.ToList();
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

        private void endbtn_Click(object sender, RoutedEventArgs e)
        {
            ProductList.ItemsSource = products.Take(take);
        }

        private void TextBoxSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (TextBoxSearch.Text.Length != 0)
            {
                ProductList.ItemsSource = ent.Product.Where(c => c.Name.Contains(TextBoxSearch.Text) || c.Description.Contains(TextBoxSearch.Text)).ToList();
            }
            else
            {
                ProductList.ItemsSource = products.Take(take);
            }
        }
    }
}
