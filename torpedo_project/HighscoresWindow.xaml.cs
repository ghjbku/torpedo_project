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
    /// Interaction logic for HighscoresWindow.xaml
    /// </summary>
    public partial class HighscoresWindow : Window
    {
        public HighscoresWindow()
        {
            InitializeComponent();
        }
        public HighscoresWindow(string wintext,string Name, string Destroyed, string Remaining, string PlayerHits,string EnemyHits, string RoundsNo) {
            InitializeComponent();
            name.Content = Name;
            winText.Content = wintext;
            destroyed.Content += Destroyed;
            remaining.Content += Remaining;
            pHits.Content += PlayerHits;
            eHits.Content += EnemyHits;
            rounds.Content += RoundsNo;
        }
    }
}
