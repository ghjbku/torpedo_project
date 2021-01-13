using System;
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
                MainWindow main = new MainWindow(player_name_box.Text,!vs_ai_RadioB.IsChecked.Value, Environment.CurrentDirectory + "\\" + player_name_box.Text + ".xml");
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
            try { new System.IO.StreamReader(Environment.CurrentDirectory + "\\" + player_name_box.Text + ".xml").Close(); }
            catch (Exception ex)
            {
            if(ex.Message.Equals(null)){
                    PlayerEntity player = GameObjects.XmlHelper.FromXmlFile<GameObjects.Player>(Environment.CurrentDirectory + "\\" + player_name_box.Text + ".xml");

                    if (player.Equals(null))
                    {
                        error_message.Content = Environment.CurrentDirectory + "\\" + player_name_box.Text + ".xml";
                    }
                    else { CreateHSWindowAndLoadIt(player, "ai", "idk"); }
                }
            else {
                    error_message.Content = player_name_box.Text+".xml not found!";
                }
            }
        }

        private void CreateHSWindowAndLoadIt(PlayerEntity player, string player2, string wintext)
        {
            HighscoresWindow hs = new HighscoresWindow(wintext, player.PlayerName, player2, player.DestroyedShips.Count.ToString(), player.RemainingShips.Count.ToString(), player.PlayerHits.Count.ToString(), player.EnemyHits.Count.ToString(), player.RoundsNo.ToString());
            this.Visibility = Visibility.Hidden;
            hs.Show();
        }
    }
}
