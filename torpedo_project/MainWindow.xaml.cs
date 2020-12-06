﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace torpedo_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameObjects.Player player1;
        private bool IsPlacementEventStarted = false;
        public MainWindow()
        {
            InitializeComponent();
            TestPlayerClasses();
        }

        public MainWindow(string name)
        {
            InitializeComponent();
            TestPlayerClasses();
            player_name_test_label.Content = name;
        }

        private void TestPlayerClasses()
        {


            player1 = new GameObjects.Player("test_player");
            player1.PlayerName = player_name_test_label.Content.ToString();
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
        private bool PlayerHits_a_Ship(System.Windows.Controls.Button clickedArea, GameObjects.Player player) {
            int i = 0;
            while (i < player.RemainingShips.Count)
            {
                char[] arrayForTrim = { 't','_' };
                var name = clickedArea.Name.TrimEnd(arrayForTrim);
                var ship = player.RemainingShips[i];
                switch (ship.getCoords().Length) {

                    case 4:
                        if (coordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                                coordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]))
                        {
                            return true;
                        }
                        else i++;
                        break;

                    case 6:
                        if (coordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                            coordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                            coordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1])
                            )
                        {
                            return true;
                        }
                        else i++;
                        break;

                    case 8:
                        if (coordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                            coordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                            coordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]) ||
                            coordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1])
                            )
                        {
                            return true;
                        }
                        else i++;
                        break;
                    case 10:
                        if (coordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                            coordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                            coordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]) ||
                            coordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1]) ||
                            coordsEqual(name, ship.getCoords()[4, 0] + ship.getCoords()[4, 1])
                            )
                        {
                            return true;
                        }
                        else i++;
                        break;
                }
            }
            return false;
        }


        private bool coordsEqual(string coord, string shipCoords) {
            if (coord.Equals(shipCoords)) {
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

                    System.Windows.Controls.Button toDrawStart = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[0, 0]+ ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    System.Windows.Controls.Button toDrawEnd = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + ship.getCoords()[1, 1]);
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
                    System.Windows.Controls.Button toDrawStart = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    System.Windows.Controls.Button toDrawMid = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawMid.Content = mid;
                    System.Windows.Controls.Button toDrawEnd = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
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
                    System.Windows.Controls.Button toDrawStart = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    System.Windows.Controls.Button toDrawMid = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawMid.Content = mid;
                    System.Windows.Controls.Button toDrawEnd = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
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
                    System.Windows.Controls.Button toDrawStart = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    System.Windows.Controls.Button toDrawMid = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawMid.Content = mid;
                    System.Windows.Controls.Button toDrawMid2 = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
                    toDrawMid2.Content = mid2;
                    System.Windows.Controls.Button toDrawEnd = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[3, 0] + "" + ship.getCoords()[3, 1]);
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
                    System.Windows.Controls.Button toDrawStart = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                    toDrawStart.Content = front;
                    System.Windows.Controls.Button toDrawMid = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                    toDrawMid.Content = mid;
                    System.Windows.Controls.Button toDrawMid2 = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
                    toDrawMid2.Content = mid2;
                    System.Windows.Controls.Button toDrawMid3 = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[3, 0] + "" + ship.getCoords()[3, 1]);
                    toDrawMid3.Content = mid3;
                    System.Windows.Controls.Button toDrawEnd = (System.Windows.Controls.Button)PlayerShipTable.FindName(ship.getCoords()[4, 0] + "" + ship.getCoords()[4, 1]);
                    toDrawEnd.Content = back;
                }
            }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button clickedArea = (System.Windows.Controls.Button)sender;

            player_name_test_label.Content = clickedArea.Name;
            if (PlayerHits_a_Ship(clickedArea, player1)) {
                player_name_test_label.Content = "you have hit "+clickedArea.Name;
            }
            
        }

        private void boat_iconRotatePressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //should only work if a ship is in placement mode
            if (IsPlacementEventStarted)
            {
                player_name_test_label.Content = e.Key;
                if (e.Key == System.Windows.Input.Key.R)
                {
                    player_name_test_label.Content = "R pressed";
                }
            }
        }

        private void boat_ChangeIconPosition(object sender, DependencyPropertyChangedEventArgs e)
        {
            //should only work if a ship is in placement mode
            if (IsPlacementEventStarted)
            {
                Image boat_image = (Image)sender;
                player_name_test_label.Content = System.Windows.Forms.Control.MousePosition;
            }
           
        }

        private void boat_StartPlacementEventWhenLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (IsPlacementEventStarted)
            {
                IsPlacementEventStarted = false;
            }else IsPlacementEventStarted = true;
        }
    }
}
