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

namespace wpf234
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rgbChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColor(Convert.ToByte(sliPiros.Value), Convert.ToByte(sliZold.Value), Convert.ToByte(sliKek.Value));
        }

        public void UpdateColor(byte red, byte green, byte blue)
        {
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(red,green,blue));
            lblkek.Content = Math.Round(sliKek.Value);
            lblpiros.Content = Math.Round(sliPiros.Value);
            lblzold.Content = Math.Round(sliZold.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string color = $"{Math.Round(sliPiros.Value)};{Math.Round(sliZold.Value)};{Math.Round(sliKek.Value)}";

            if (ListBox.Items.Contains(color))
            {
                MessageBox.Show("Ez a szín már fel lett véve");
            }
            else
            {
            ListBox.Items.Add(color);
            }
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex>=0)
            {
            ListBox.Items.Remove(ListBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva szín a listában.");
            }
        }

        private void btnUrites_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            sliKek.Value = 0;
            sliPiros.Value = 0;
            sliZold.Value = 0;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string[] szoveg = ListBox.SelectedItem.ToString().Split(";");
            sliPiros.Value = Convert.ToInt16(szoveg[0]);
            sliZold.Value = Convert.ToInt16(szoveg[1]);
            sliKek.Value = Convert.ToInt16(szoveg[2]);

            UpdateColor(Convert.ToByte(szoveg[0]), Convert.ToByte(szoveg[1]), Convert.ToByte(szoveg[2]));
        }
    }
}
