using System.Windows;
using System.Windows.Controls;

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
            player1.fillUpRemainingShips(new GameObjects.Ship("C", 3, "E", 3, "Submarine"));
            player1.fillUpRemainingShips(new GameObjects.Ship("J", 1, "J", 3, "Destroyer"));
            player1.fillUpRemainingShips(new GameObjects.Ship("I", 4, "I", 7, "Battleship"));
            player1.fillUpRemainingShips(new GameObjects.Ship("A", 9, "D", 9, "Battleship"));
            player1.fillUpRemainingShips(new GameObjects.Ship("F", 9, "J", 9, "Carrier"));
            player1.fillUpRemainingShips(new GameObjects.Ship("G", 3, "G", 7, "Carrier"));


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
                Image front,mid,mid2,mid3,back;

                if (ship.shipType.Equals("Patrol Boat"))
                {
                    if (ship.rotated == true) {
                         front = (Image)FindResource("LeftShipFront");
                         back = (Image)FindResource("LeftShipBack");
                    }
                    else
                    {
                         front = (Image)FindResource("ShipFront");
                         back = (Image)FindResource("ShipBack");
                    }

                    Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0]+ ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + ship.getCoords()[1, 1]);
                    toDrawEnd.Content = back;
                }
                else if (ship.shipType.Equals("Submarine"))
                {
                    if (ship.rotated == true)
                    {
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");
                    }
                    else
                    {
                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");
                    }
                    Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    Button toDrawMid = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawMid.Content = mid;
                    Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
                    toDrawEnd.Content = back;
                }
                else if (ship.shipType.Equals("Destroyer"))
                {
                    if (ship.rotated == true)
                    {
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");
                    }
                    else
                    {
                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");
                    }
                    Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    Button toDrawMid = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawMid.Content = mid;
                    Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
                    toDrawEnd.Content = back;
                }
                else if (ship.shipType.Equals("Battleship"))
                {
                    if (ship.rotated == true)
                    {
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        mid2 = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");
                    }
                    else
                    {
                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        mid2 = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");
                    }
                    Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    Button toDrawMid = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawMid.Content = mid;
                    Button toDrawMid2 = (Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
                    toDrawMid2.Content = mid2;
                    Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[3, 0] + "" + ship.getCoords()[3, 1]);
                    toDrawEnd.Content = back;
                }
                else if (ship.shipType.Equals("Carrier"))
                {
                    if (ship.rotated == true)
                    {
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        mid2 = (Image)FindResource("LeftShipMid");
                        mid3 = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");
                    }
                    else
                    {
                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        mid2 = (Image)FindResource("ShipMid");
                        mid3 = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");
                    }
                    Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    Button toDrawMid = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawMid.Content = mid;
                    Button toDrawMid2 = (Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
                    toDrawMid2.Content = mid2;
                    Button toDrawMid3 = (Button)PlayerShipTable.FindName(ship.getCoords()[3, 0] + "" + ship.getCoords()[3, 1]);
                    toDrawMid3.Content = mid3;
                    Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[4, 0] + "" + ship.getCoords()[4, 1]);
                    toDrawEnd.Content = back;
                }
            }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (player_name_test_label.Content.Equals(" "))
            {
                player_name_test_label.Content = "Clicked+";
            }
            else
            {
                player_name_test_label.Content = " ";
            }
            
        }
    }
}
