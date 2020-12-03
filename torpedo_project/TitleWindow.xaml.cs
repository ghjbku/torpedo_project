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
using System.Windows.Shapes;

namespace torpedo_project
{
    /// <summary>
    /// Interaction logic for TitleWindow.xaml
    /// </summary>
    public partial class TitleWindow : Window
    {
        public TitleWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (player_name_box.Text.Equals(""))
            {
                player_name_box.Background = Brushes.Red;
            }
            else { 
                MainWindow main = new MainWindow(player_name_box.Text);
                this.Visibility = Visibility.Hidden;
                main.Show();
            }
        }

        private void player_name_box_KeyDown(object sender, KeyEventArgs e)
        {
            player_name_box.Background = Brushes.White;
        }
    }
}
