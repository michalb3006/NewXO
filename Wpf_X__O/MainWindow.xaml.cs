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

namespace Wpf_X__O
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
        static int counterLine = 0;
        public string[,] mat { get; set; } =  new string[3, 3];

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int row = (int)b.GetValue(Grid.RowProperty);
            int col = (int)b.GetValue(Grid.ColumnProperty);
            if (counterLine % 2 == 0)
            {
                b.Background = new SolidColorBrush(Colors.Black);
                mat[row, col] = "Black";
            }
            else
            {
                b.Background = new SolidColorBrush(Colors.White);
                mat[row, col] = "White";
            }
            counterLine++;
            if (counterLine >= 5)
                if (CheckWin(mat, row, col) == true)
                { MessageBox.Show("the player with color " + mat[row, col] + " win !!");
                    this.Close();
                }
            if(counterLine==9)
                MessageBox.Show("no one win");

        }


        private bool CheckWin(string [,]mat,int row,int col)
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                if (mat[row, i] != mat[row, col])
                    counter++;
            }
            if (counter == 0)
                return true;
            counter = 0;
            for (int i = 0; i < 3; i++)
            {
                if (mat[i, col] != mat[row, col])
                    counter++;
            }
            if (counter == 0)
                return true;
            counter = 0;

            for (int i = 0; i < 3; i++)
            {
                if (mat[i, i] != mat[row, col])
                    counter++;
            }
            if (counter == 0)
                return true;
            counter = 0;

            for (int i = 2; i >=0; i--)
            {
                if (mat[i, i] != mat[row, col])
                    counter++;
            }
            if (counter == 0)
                return true;
            return false;
        }
    }
 }
