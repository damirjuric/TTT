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
    public static class Array
    {
        public static int[] val = new int[9];
        public static void fill()
        {
            for (int j = 0; j < 9; j++)
                val[j] = 0;
        }
        public static void done(int y, int z)
        {
            val[y] = z;
            if ((val[0] == val[1] && val[0] == val[2] && val[0] == 2) || (val[0] == val[3] && val[0] == val[6] && val[0] == 2) || (val[4] == val[0] && val[0] == val[8] && val[0] == 2) || (val[1] == val[4] && val[1] == val[7] && val[1] == 2) || (val[2] == val[5] && val[2] == val[8] && val[2] == 2) || (val[3] == val[4] && val[3] == val[5] && val[3] == 2) || (val[6] == val[4] && val[6] == val[2] && val[6] == 2) || (val[6] == val[7] && val[6] == val[8] && val[6] == 2))
            {
                MessageBox.Show("Pobijedio je X");
                Application.Current.Shutdown();
            }
            if ((val[0] == val[1] && val[0] == val[2] && val[0] == 1) || (val[0] == val[3] && val[0] == val[6] && val[0] == 1) || (val[4] == val[0] && val[0] == val[8] && val[0] == 1) || (val[1] == val[4] && val[1] == val[7] && val[1] == 1) || (val[2] == val[5] && val[2] == val[8] && val[2] == 1) || (val[3] == val[4] && val[3] == val[5] && val[3] == 1) || (val[6] == val[4] && val[6] == val[2] && val[6] == 1) || (val[6] == val[7] && val[6] == val[8] && val[6] == 1))
            {
                MessageBox.Show("Pobijedio je O");
                Application.Current.Shutdown();
            }
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
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0)
            {
                obj.Content = "X";
                Array.done(0, 2);
            }
            else
            {
                obj.Content = "O";
                Array.done(0, 1);
            }

        }

        private void Button_Click_01(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0)
            {
                obj.Content = "X";
                Array.done(1, 2);
            }
            else
            {
                obj.Content = "O";
                Array.done(1, 1);
            }

        }

        private void Button_Click_02(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0)
            {
                obj.Content = "X";
                Array.done(2, 2);
            }
            else
            {
                obj.Content = "O";
                Array.done(2, 1);
            }

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0)
            {
                obj.Content = "X";
                Array.done(3, 2);
            }
            else
            {
                obj.Content = "O";
                Array.done(3, 1);
            }

        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0)
            {
                obj.Content = "X";
                Array.done(4, 2);
            }
            else
            {
                obj.Content = "O";
                Array.done(4, 1);
            }

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0)
            {
                obj.Content = "X";
                Array.done(5, 2);
            }
            else
            {
                obj.Content = "O";
                Array.done(5, 1);
            }

        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0)
            {
                obj.Content = "X";
                Array.done(6, 2);
            }
            else
            {
                obj.Content = "O";
                Array.done(6, 1);
            }

        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0)
            {
                obj.Content = "X";
                Array.done(7, 2);
            }
            else
            {
                obj.Content = "O";
                Array.done(7, 1);
            }

        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            Button obj = (Button)sender;
            if (obj.Content == "X" || obj.Content == "O")
            {
                MessageBox.Show("Polje je popunjeno!");
            }
            else if (Counters.brojac(1) % 2 == 0)
            {
                obj.Content = "X";
                Array.done(8, 2);
            }
            else
            {
                obj.Content = "O";
                Array.done(8, 1);
            }

        }

    }
}
