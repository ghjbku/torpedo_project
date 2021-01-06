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
        public HighscoresWindow(string wintext,string Name,string Name2,string Destroyed, string Remaining, string PlayerHits,string EnemyHits, string RoundsNo) {
            InitializeComponent();
            name.Content = Name+" VS "+Name2;
            winText.Content = wintext;
            destroyed.Content += Destroyed;
            remaining.Content += Remaining;
            pHits.Content += PlayerHits;
            eHits.Content += EnemyHits;
            rounds.Content += RoundsNo;
        }
    }
}
