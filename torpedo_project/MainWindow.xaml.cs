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

namespace torpedo_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestPlayerClasses();
        }

        private void TestPlayerClasses()
        {
            GameObjects.Player player1 = new GameObjects.Player("test_player");
            player_name_test_label.Content = player1.PlayerName;
            player1.fillUpRemainingShips(new GameObjects.Ship('A', '1','A','2'));
            player1.fillUpRemainingShips(new GameObjects.Ship('A', '5', 'A', '5'));
            player1.fillUpRemainingShips(new GameObjects.Ship('C', '1', 'D', '1'));

            foreach (GameObjects.Ship ship in player1.RemainingShips)
            {
                if (AreCoordsSame("" + ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1],
                                                 "" + ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]))
                {
                    Button toDrawInto = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawInto.Content = "O";
                }
                else {
                    Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = "O";
                    Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawEnd.Content = "O";
                }
            }
            Console.WriteLine(player1.RemainingShips);
        }

        private bool AreCoordsSame(string coordsStart,string coordsEnd) {
            if (coordsStart.Equals(coordsEnd))
            {
                return true;
            }
            else return false;
            
        }
    }
}
