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
            player1.fillUpRemainingShips(new GameObjects.Ship("A", 1,"A",2, "Patrol Boat"));
            player1.fillUpRemainingShips(new GameObjects.Ship("A", 5, "A", 7, "Submarine"));
            player1.fillUpRemainingShips(new GameObjects.Ship("C", 1, "D", 1, "Patrol Boat"));
            player1.fillUpRemainingShips(new GameObjects.Ship("B", 5, "D", 5, "Submarine"));
            player1.fillUpRemainingShips(new GameObjects.Ship("E", 3, "G", 3, "Submarine"));
            player1.fillUpRemainingShips(new GameObjects.Ship("I", 1, "I", 3, "Submarine"));

            place_boats(player1);
        }

        //the function can still be useful for checking if a player "hits" a ship
        private bool AreCoordsSame(string coordsStart,string coordsEnd) {
            if (coordsStart.Equals(coordsEnd))
            {
                return true;
            }
            else return false;
            
        }

        private void place_boats(GameObjects.Player player) {
            foreach (GameObjects.Ship ship in player.RemainingShips)
            {
                if (ship.shipType.Equals("Patrol Boat"))
                {
                   

                    Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0]+ ship.getCoords()[0, 1]);
                    toDrawStart.Content = "O";
                    Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + ship.getCoords()[1, 1]);
                    toDrawEnd.Content = "O";
                }else if (ship.shipType.Equals("Submarine"))
                {
                    player_name_test_label.Content = ship.getCoords()[1, 0];
                    player_name_test_label.Content = ship.getCoords()[1, 1];

                    Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = "O";
                    Button toDrawMid = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawMid.Content = "O";
                    Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
                    toDrawEnd.Content = "O";
                }
            }
        }





    }
}
