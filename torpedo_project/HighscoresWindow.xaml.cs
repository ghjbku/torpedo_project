using System;
using System.Windows;

namespace torpedo_project
{
    /// <summary>
    /// Interaction logic for HighscoresWindow.xaml
    /// </summary>
    public partial class HighscoresWindow : Window
    {
        public HighscoresWindow()
        {
            InitializeComponent();
        }
        //constructor for loading the hs
        public HighscoresWindow(string wintext, string Name, string Name2, string Destroyed, string Remaining, string PlayerHits, string EnemyHits, string RoundsNo) {
            InitializeComponent();
            name.Content = Name + " VS " + Name2;
            winText.Content = wintext;
            destroyed.Content += Destroyed;
            remaining.Content += Remaining;
            pHits.Content += PlayerHits;
            eHits.Content += EnemyHits;
            rounds.Content += RoundsNo;
        }

        //constructor for game ending and saving
        public HighscoresWindow(string wintext,PlayerEntity player,string Name,string Name2,string Destroyed, string Remaining, string PlayerHits,string EnemyHits, string RoundsNo,string path) {
            InitializeComponent();
            name.Content = Name+" VS "+Name2;
            winText.Content = wintext;
            destroyed.Content += Destroyed;
            remaining.Content += Remaining;
            pHits.Content += PlayerHits;
            eHits.Content += EnemyHits;
            rounds.Content += RoundsNo;
            SaveDataToXml(player,path);
        }

        private void SaveDataToXml(PlayerEntity player,string path) {
            GameObjects.XmlHelper.ToXmlFile(player, path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TitleWindow tw = new TitleWindow();
            this.Visibility = Visibility.Hidden;
            tw.Show();
        }
    }
}
