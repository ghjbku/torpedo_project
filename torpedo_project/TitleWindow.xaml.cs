using System;
using System.IO;
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
        private string path;
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
                path = Environment.CurrentDirectory + "\\" + player_name_box.Text + ".xml";
                MainWindow main = new MainWindow(player_name_box.Text,!vs_ai_RadioB.IsChecked.Value,path);
                this.Visibility = Visibility.Hidden;
                main.Show();
            }
        }

        private void player_name_box_MouseEnter(object sender, MouseEventArgs e)
        {
            player_name_box.Background = Brushes.White;
        }

        private void ClickHighScore(object sender, RoutedEventArgs e)
        {
            if (player_name_box.Text.Equals(""))
            {
                player_name_box.Background = Brushes.Red;
                return;
            }
            else
            {
                path = Environment.CurrentDirectory + "\\" + player_name_box.Text + ".xml";

                if (!File.Exists(path))
                {
                    error_message.Content = player_name_box.Text + ".xml not found!";
                }
                else
                {
                    PlayerEntity player = GameObjects.XmlHelper.FromXmlFile<GameObjects.Player>(path);

                    if (player.Equals(null))
                    {
                        error_message.Content = path;
                    }
                    else { CreateHSWindowAndLoadIt(player, "ai", player.won); }
                }
            }

        }

        private void CreateHSWindowAndLoadIt(PlayerEntity player, string player2, bool win)
        {
            string wintext;
            if (win)
            {
                wintext = "Player won";
            }
            else wintext = "AI won";

            HighscoresWindow hs = new HighscoresWindow(wintext, player.PlayerName, player2, player.DestroyedShips.Count.ToString(), player.RemainingShips.Count.ToString(), player.PlayerHits.Count.ToString(), player.EnemyHits.Count.ToString(), player.RoundsNo.ToString());
            this.Visibility = Visibility.Hidden;
            hs.Show();
        }
    }
}
