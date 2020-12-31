using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
                MainWindow main = new MainWindow(player_name_box.Text,!vs_ai_RadioB.IsChecked.Value);
                this.Visibility = Visibility.Hidden;
                main.Show();
            }
        }

        private void player_name_box_MouseEnter(object sender, MouseEventArgs e)
        {
            player_name_box.Background = Brushes.White;
        }
    }
}
