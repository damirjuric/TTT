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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public static class Counters
    {
        public static int i = 1;
        public static int brojac(int x)
        {
            i = i + x;
            return i;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_00(object sender, RoutedEventArgs e)
        {
            Button obj = (Button) sender;
            if (obj.Content == "X" || obj.Content=="O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0) obj.Content = "X";
            else obj.Content = "O";
        }

        private void Button_Click_01(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0) obj.Content = "X";
            else obj.Content = "O";
        }

        private void Button_Click_02(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0) obj.Content = "X";
            else obj.Content = "O";
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0) obj.Content = "X";
            else obj.Content = "O";
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0) obj.Content = "X";
            else obj.Content = "O";
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0) obj.Content = "X";
            else obj.Content = "O";
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0) obj.Content = "X";
            else obj.Content = "O";
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0) obj.Content = "X";
            else obj.Content = "O";
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0) obj.Content = "X";
            else obj.Content = "O";
        }
    }
}
