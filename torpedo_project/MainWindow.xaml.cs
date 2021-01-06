using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace torpedo_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameObjects.Player player1;
        private GameObjects.AiPlayer aiplayer;
        private bool IsPlacementEventStarted = false, rotated = false, isVsAi = true;
        private Image boat_image, old_image;
        private string partHit;
        private GameObjects.Ship lastShipHit;

        public MainWindow(string name, bool isai)
        {
            InitializeComponent();
            player_name_test_label.Content = name;
            old_image = null;
            partHit = "";
            isVsAi = isai;
            InitGame(name);
        }

        private void InitGame(string playername)
        {
            player1 = new GameObjects.Player(playername);
            player1.RoundsNo = 0;
            aiplayer = new GameObjects.AiPlayer();
            aiplayer.RoundsNo = 0;
            AiShipPlacement(aiplayer);
            UpdateRemainingShips("ai");
        }
        private void TestingLabelOutput(string output) {
            player_name_test_label.Content = output;
        }
        private void AiShipPlacement(GameObjects.AiPlayer aiplayer)
        {
            const string range = "ABCDEFGHIJ";
            System.Random rnd = new System.Random();

            do
            {
                int dice = rnd.Next(1, 11);
                rotated = rnd.Next(0, 2) == 0;
                string Coord1 = new string(Enumerable.Range(1, 1).Select(x => range[rnd.Next(0, range.Length)]).ToArray());
                CreateShipOnPosition("PatrolBoat", Coord1 + dice.ToString(), aiplayer, true);
            } while (aiplayer.RemainingShips.Count < 1);

            do
            {
                int dice = rnd.Next(1, 11);
                rotated = rnd.Next(0, 2) == 0;
                string Coord1 = new string(Enumerable.Range(1, 1).Select(x => range[rnd.Next(0, range.Length)]).ToArray());
                CreateShipOnPosition("Submarine", Coord1 + dice.ToString(), aiplayer, true);
            } while (aiplayer.RemainingShips.Count < 2);

            do
            {
                int dice = rnd.Next(1, 11);
                rotated = rnd.Next(0, 2) == 0;
                string Coord1 = new string(Enumerable.Range(1, 1).Select(x => range[rnd.Next(0, range.Length)]).ToArray());
                CreateShipOnPosition("Destroyer", Coord1 + dice.ToString(), aiplayer, true);
            } while (aiplayer.RemainingShips.Count < 3);

            do
            {
                int dice = rnd.Next(1, 11);
                rotated = rnd.Next(0, 2) == 0;
                string Coord1 = new string(Enumerable.Range(1, 1).Select(x => range[rnd.Next(0, range.Length)]).ToArray());
                CreateShipOnPosition("Battleship", Coord1 + dice.ToString(), aiplayer, true);
            } while (aiplayer.RemainingShips.Count < 4);

            do
            {
                int dice = rnd.Next(1, 11);
                rotated = rnd.Next(0, 2) == 0;
                string Coord1 = new string(Enumerable.Range(1, 1).Select(x => range[rnd.Next(0, range.Length)]).ToArray());
                CreateShipOnPosition("Carrier", Coord1 + dice.ToString(), aiplayer, true);
            } while (aiplayer.RemainingShips.Count < 5);
        }

        //checking if a player "hits" a ship
        private bool PlayerHitsaShip(string clickedArea, PlayerEntity player)
        {
            int i = 0;
            while (i < player.RemainingShips.Count)
            {
                char[] arrayForTrim = { 't', '_' };
                var name = clickedArea.TrimEnd(arrayForTrim);
                var ship = player.RemainingShips[i];
                switch (ship.getCoords().Length)
                {
                    case 4:
                        if (CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                                CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]))
                        {
                            WhichPartIsHit(clickedArea, ship, i, 4);
                            lastShipHit = ship;
                            return true;
                        }
                        else i++;
                        break;

                    case 6:
                        if (CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                            CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                            CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1])
                            )
                        {
                            WhichPartIsHit(clickedArea, ship, i, 6);
                            lastShipHit = ship;
                            return true;
                        }
                        else i++;
                        break;

                    case 8:
                        if (CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                            CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                            CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]) ||
                            CoordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1])
                            )
                        {
                            WhichPartIsHit(clickedArea, ship, i, 8);
                            lastShipHit = ship;
                            return true;
                        }
                        else i++;
                        break;
                    case 10:
                        if (CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                            CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                            CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]) ||
                            CoordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1]) ||
                            CoordsEqual(name, ship.getCoords()[4, 0] + ship.getCoords()[4, 1])
                            )
                        {
                            WhichPartIsHit(clickedArea, ship, i, 10);
                            lastShipHit = ship;
                            return true;
                        }
                        else i++;
                        break;
                }
            }
            return false;
        }

        private void StartGameAfterPlacement() {
            PatrolBoat.Visibility = Visibility.Hidden;
            Submarine.Visibility = Visibility.Hidden;
            Destroyer.Visibility = Visibility.Hidden;
            Battleship.Visibility = Visibility.Hidden;
            Carrier.Visibility = Visibility.Hidden;
            turn_indicator.Content = "your turn!";
        }

        private bool CoordsEqual(string coord, string shipCoords)
        {
            if (coord.Equals(shipCoords))
            {
                return true;
            }
            else return false;
        }

        private void WhichPartIsHit(string clickedButtonCoord, GameObjects.Ship ship, int i, int HowLong)
        {
            char[] arrayForTrim = { 't', '_' };
            var name = clickedButtonCoord.TrimEnd(arrayForTrim);
            ship.ShipPartsHit += 1;
            if (CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]))
            {
                if (ship.rotated)
                {
                    partHit = "ShipHitLeftFront";
                }
                else partHit = "ShipHitFront";
            }
            if (HowLong == 4)
            {
                if (CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]))
                {
                    if (ship.rotated)
                    {
                        partHit = "ShipHitLeftBack";
                    }
                    else partHit = "ShipHitBack";
                }
            }
            else if (HowLong == 6)
            {
                if (CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]))
                {
                    if (ship.rotated)
                    {
                        partHit = "ShipHitLeftMid";
                    }
                    else partHit = "ShipHitMid";
                }
                else if (CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]))
                {
                    if (ship.rotated)
                    {
                        partHit = "ShipHitLeftBack";
                    }
                    else partHit = "ShipHitBack";
                }
            }
            else if (HowLong == 8)
            {
                if (CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                    CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1])
                   )
                {
                    if (ship.rotated)
                    {
                        partHit = "ShipHitLeftMid";
                    }
                    else partHit = "ShipHitMid";
                }
                else if (CoordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1]))
                {
                    if (ship.rotated)
                    {
                        partHit = "ShipHitLeftBack";
                    }
                    else partHit = "ShipHitBack";
                }
            }
            else if (HowLong == 10)
            {
                if (CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                   CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]) ||
                   CoordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1])
                  )
                {
                    if (ship.rotated)
                    {
                        partHit = "ShipHitLeftMid";
                    }
                    else partHit = "ShipHitMid";
                }
                else if (CoordsEqual(name, ship.getCoords()[4, 0] + ship.getCoords()[4, 1]))
                {
                    if (ship.rotated)
                    {
                        partHit = "ShipHitLeftBack";
                    }
                    else partHit = "ShipHitBack";
                }
            }
        }

        private void PlaceBoats(GameObjects.Player player, GameObjects.AiPlayer aiplayer)
        {
            if (aiplayer == null)
            {
                foreach (GameObjects.Ship ship in player.RemainingShips)
                {
                    DrawBoat(ship, false);
                }
            }
            else
            {
                foreach (GameObjects.Ship ship in aiplayer.RemainingShips)
                {
                    DrawBoat(ship, true);
                }
            }
        }

        private void DrawBoat(GameObjects.Ship ship, bool isAi)
        {
            Image front, mid, mid2, mid3, back;
            if (player1.RemainingShips.Count <= 5 && aiplayer.RemainingShips.Count <= 5){
            //PlayerTargetTable
            if (!isAi)
            {
                if (ship.rotated == true)
                {
                    if (ship.shipType.Equals("PatrolBoat"))
                    {
                        front = (Image)FindResource("LeftShipFront");
                        back = (Image)FindResource("LeftShipBack");

                        Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + ship.getCoords()[0, 1]);
                        toDrawStart.Content = front;
                        Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + ship.getCoords()[1, 1]);
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Submarine") || ship.shipType.Equals("Destroyer"))
                    {
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");

                        Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                        toDrawStart.Content = front;
                        Button toDrawMid = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                        toDrawMid.Content = mid;
                        Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Battleship"))
                    {
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        mid2 = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");

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
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        mid2 = (Image)FindResource("LeftShipMid");
                        mid3 = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");

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
                else
                {
                    if (ship.shipType.Equals("PatrolBoat"))
                    {
                        front = (Image)FindResource("ShipFront");
                        back = (Image)FindResource("ShipBack");

                        Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + ship.getCoords()[0, 1]);
                        toDrawStart.Content = front;
                        Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + ship.getCoords()[1, 1]);
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Submarine") || ship.shipType.Equals("Destroyer"))
                    {
                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");

                        Button toDrawStart = (Button)PlayerShipTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1]);
                        toDrawStart.Content = front;
                        Button toDrawMid = (Button)PlayerShipTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1]);
                        toDrawMid.Content = mid;
                        Button toDrawEnd = (Button)PlayerShipTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1]);
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Battleship"))
                    {

                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        mid2 = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");
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
                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        mid2 = (Image)FindResource("ShipMid");
                        mid3 = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");

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
            
            //if its ai
            else
            {

                if (ship.rotated == true)
                {
                    if (ship.shipType.Equals("PatrolBoat"))
                    {
                        front = (Image)FindResource("LeftShipFront");
                        back = (Image)FindResource("LeftShipBack");

                        Button toDrawStart = (Button)PlayerTargetTable.FindName(ship.getCoords()[0, 0] + ship.getCoords()[0, 1] + "_t");
                        toDrawStart.Content = front;
                        Button toDrawEnd = (Button)PlayerTargetTable.FindName(ship.getCoords()[1, 0] + ship.getCoords()[1, 1] + "_t");
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Submarine") || ship.shipType.Equals("Destroyer"))
                    {
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");

                        Button toDrawStart = (Button)PlayerTargetTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1] + "_t");
                        toDrawStart.Content = front;
                        Button toDrawMid = (Button)PlayerTargetTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1] + "_t");
                        toDrawMid.Content = mid;
                        Button toDrawEnd = (Button)PlayerTargetTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1] + "_t");
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Battleship"))
                    {
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        mid2 = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");

                        Button toDrawStart = (Button)PlayerTargetTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1] + "_t");
                        toDrawStart.Content = front;
                        Button toDrawMid = (Button)PlayerTargetTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1] + "_t");
                        toDrawMid.Content = mid;
                        Button toDrawMid2 = (Button)PlayerTargetTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1] + "_t");
                        toDrawMid2.Content = mid2;
                        Button toDrawEnd = (Button)PlayerTargetTable.FindName(ship.getCoords()[3, 0] + "" + ship.getCoords()[3, 1] + "_t");
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Carrier"))
                    {
                        front = (Image)FindResource("LeftShipFront");
                        mid = (Image)FindResource("LeftShipMid");
                        mid2 = (Image)FindResource("LeftShipMid");
                        mid3 = (Image)FindResource("LeftShipMid");
                        back = (Image)FindResource("LeftShipBack");

                        Button toDrawStart = (Button)PlayerTargetTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1] + "_t");
                        toDrawStart.Content = front;
                        Button toDrawMid = (Button)PlayerTargetTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1] + "_t");
                        toDrawMid.Content = mid;
                        Button toDrawMid2 = (Button)PlayerTargetTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1] + "_t");
                        toDrawMid2.Content = mid2;
                        Button toDrawMid3 = (Button)PlayerTargetTable.FindName(ship.getCoords()[3, 0] + "" + ship.getCoords()[3, 1] + "_t");
                        toDrawMid3.Content = mid3;
                        Button toDrawEnd = (Button)PlayerTargetTable.FindName(ship.getCoords()[4, 0] + "" + ship.getCoords()[4, 1] + "_t");
                        toDrawEnd.Content = back;
                    }
                }
                else
                {
                    if (ship.shipType.Equals("PatrolBoat"))
                    {
                        front = (Image)FindResource("ShipFront");
                        back = (Image)FindResource("ShipBack");

                        Button toDrawStart = (Button)PlayerTargetTable.FindName(ship.getCoords()[0, 0] + ship.getCoords()[0, 1] + "_t");
                        toDrawStart.Content = front;
                        Button toDrawEnd = (Button)PlayerTargetTable.FindName(ship.getCoords()[1, 0] + ship.getCoords()[1, 1] + "_t");
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Submarine") || ship.shipType.Equals("Destroyer"))
                    {
                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");

                        Button toDrawStart = (Button)PlayerTargetTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1] + "_t");
                        toDrawStart.Content = front;
                        Button toDrawMid = (Button)PlayerTargetTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1] + "_t");
                        toDrawMid.Content = mid;
                        Button toDrawEnd = (Button)PlayerTargetTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1] + "_t");
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Battleship"))
                    {

                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        mid2 = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");
                        Button toDrawStart = (Button)PlayerTargetTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1] + "_t");
                        toDrawStart.Content = front;
                        Button toDrawMid = (Button)PlayerTargetTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1] + "_t");
                        toDrawMid.Content = mid;
                        Button toDrawMid2 = (Button)PlayerTargetTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1] + "_t");
                        toDrawMid2.Content = mid2;
                        Button toDrawEnd = (Button)PlayerTargetTable.FindName(ship.getCoords()[3, 0] + "" + ship.getCoords()[3, 1] + "_t");
                        toDrawEnd.Content = back;
                    }
                    else if (ship.shipType.Equals("Carrier"))
                    {
                        front = (Image)FindResource("ShipFront");
                        mid = (Image)FindResource("ShipMid");
                        mid2 = (Image)FindResource("ShipMid");
                        mid3 = (Image)FindResource("ShipMid");
                        back = (Image)FindResource("ShipBack");

                        Button toDrawStart = (Button)PlayerTargetTable.FindName(ship.getCoords()[0, 0] + "" + ship.getCoords()[0, 1] + "_t");
                        toDrawStart.Content = front;
                        Button toDrawMid = (Button)PlayerTargetTable.FindName(ship.getCoords()[1, 0] + "" + ship.getCoords()[1, 1] + "_t");
                        toDrawMid.Content = mid;
                        Button toDrawMid2 = (Button)PlayerTargetTable.FindName(ship.getCoords()[2, 0] + "" + ship.getCoords()[2, 1] + "_t");
                        toDrawMid2.Content = mid2;
                        Button toDrawMid3 = (Button)PlayerTargetTable.FindName(ship.getCoords()[3, 0] + "" + ship.getCoords()[3, 1] + "_t");
                        toDrawMid3.Content = mid3;
                        Button toDrawEnd = (Button)PlayerTargetTable.FindName(ship.getCoords()[4, 0] + "" + ship.getCoords()[4, 1] + "_t");
                        toDrawEnd.Content = back;
                    }
                }
            }
        }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {

            Button clickedArea = (Button)sender;

            //if its not placement mode
            if (old_image == null)
            {
                //only proceed if the button is from the PlayerTargetTable
                if (clickedArea.Parent.Equals(PlayerTargetTable))
                {
                    if (PlayerHitsaShip(clickedArea.Name, aiplayer))
                    {

                        if (!player1.PlayerHits.Contains(clickedArea.Name))
                        {
                            player1.updatePlayerHits(clickedArea.Name);
                            aiplayer.updateEnemyHits(clickedArea.Name);
                            
                        }
                        CheckIfAllShipCoordsHit();

                        TestingLabelOutput("you have hit " + clickedArea.Name + "," + partHit);


                        if (partHit.Equals("ShipHitFront"))
                        {
                            clickedArea.Content = (Image)FindResource("ShipHitFront");
                        }
                        else if (partHit == "ShipHitMid")
                        {
                            clickedArea.Content = (Image)FindResource("ShipHitMid");
                        }
                        else if (partHit == "ShipHitBack")
                        {
                            clickedArea.Content = (Image)FindResource("ShipHitBack");
                        }
                        else if (partHit == "ShipHitLeftFront")
                        {
                            clickedArea.Content = (Image)FindResource("ShipHitLeftFront");
                        }
                        else if (partHit == "ShipHitLeftMid")
                        {
                            clickedArea.Content = (Image)FindResource("ShipHitLeftMid");
                        }
                        else if (partHit == "ShipHitLeftBack")
                        {
                            clickedArea.Content = (Image)FindResource("ShipHitLeftBack");
                        }
                        
                    }
                    else
                    {
                        TestingLabelOutput(clickedArea.Name);
                        clickedArea.Content = (Image)FindResource("NotHit");
                    }
                }
            }
            else
            {
                CreateShipOnPosition(old_image.Name, clickedArea.Name, player1, false);
            }
            AiRandomCoord();
        }

        private void CheckIfAllShipCoordsHit()
        {
            if (lastShipHit.shipType.Equals("PatrolBoat"))
            {
                if (lastShipHit.ShipPartsHit == 2) {
                    aiplayer.fillUpDestroyedShips(lastShipHit); 
                }
            }
            else if (lastShipHit.shipType.Equals("Submarine") || lastShipHit.shipType.Equals("Destroyer"))
            {
                if (lastShipHit.ShipPartsHit == 3)
                {
                    aiplayer.fillUpDestroyedShips(lastShipHit);
                }
            }
            else if (lastShipHit.shipType.Equals("Battleship"))
            {
                if (lastShipHit.ShipPartsHit == 4)
                {
                    aiplayer.fillUpDestroyedShips(lastShipHit);
                }
            }
            else if (lastShipHit.shipType.Equals("Carrier"))
            {
                if (lastShipHit.ShipPartsHit == 5)
                {
                    aiplayer.fillUpDestroyedShips(lastShipHit);
                }
            }
            UpdateRemainingShips("ai");
            CheckPlayerWins();
            CheckAiWins();
        }

        private void UpdateRemainingShips(string whichplayer) {
            NumberofHits.Content = player1.PlayerHits.Count.ToString();
            if (player1.RemainingShips.Count <= 5){
                if (whichplayer.Equals(player1.PlayerName)) {
                    player_remaining_ships.Content = player1.RemainingShips.Count.ToString();
                }
                else {
                    enemy_remaining_ships.Content = aiplayer.RemainingShips.Count.ToString();
                }
            }
        }
        private void CreateShipOnPosition(string ship_name, string m_position, PlayerEntity player, bool aiship)
        {
            string[] resultAlphabet = System.Text.RegularExpressions.Regex.Split(m_position, @"\d+");
            string[] resultNumber = System.Text.RegularExpressions.Regex.Split(m_position, @"\D+");
            string[] startCoord, endCoord;
            GameObjects.Ship createdShip;

            startCoord = getStartCoord(resultAlphabet[0], resultNumber[1], ship_name);
            endCoord = getEndCoord(resultAlphabet[0], resultNumber[1], ship_name);

            if (startCoord[0].Equals("asd") || endCoord[0].Equals("asd"))
            {
                return;
            }

            TestingLabelOutput(startCoord[0] + startCoord[1] + "," + endCoord[0] + endCoord[1]);

            if (!aiship)
            {
                    Canvas.SetLeft(boat_image, 0);
                    Canvas.SetTop(boat_image, 0);
                    boat_image.RenderTransform = GetBasicScaling(boat_image, false);
            }

            createdShip = new GameObjects.Ship(startCoord[0], int.Parse(startCoord[1]), endCoord[0], int.Parse(endCoord[1]), ship_name);
            string[,] shipcoords = createdShip.getCoords();
            int len = createdShip.getCoords().Length;

            //if the ship's any coord hits another ship, it wont place the ship to the table
            if (PlayerHitsaShip(m_position, player) ||
                PlayerHitsaShip(startCoord[0] + startCoord[1], player) ||
                PlayerHitsaShip(endCoord[0] + endCoord[1], player)
               )
            {
                old_image = null;
                return;
            }
            if (len == 8)
            {
                if (
                    PlayerHitsaShip(shipcoords[2, 0] + shipcoords[2, 1], player)
                   )
                {
                    old_image = null;
                    return;
                }
            }
            else if (len == 10)
            {
                if (PlayerHitsaShip(shipcoords[1, 0] + shipcoords[1, 1], player) ||
                    PlayerHitsaShip(shipcoords[2, 0] + shipcoords[2, 1], player) ||
                    PlayerHitsaShip(shipcoords[3, 0] + shipcoords[3, 1], player)
                   )
                {
                    old_image = null;
                    return;
                }
            }
            player.fillUpRemainingShips(createdShip);


            if (!aiship)
            {
                DrawBoat(createdShip, false);
                UpdateRemainingShips(player.PlayerName);
            }

            if (player1.RemainingShips.Count == 5) {
                StartGameAfterPlacement();
            }

            old_image = null;
        }

        private string[] getStartCoord(string middlecoord_x, string middlecoord_y, string shipname)
        {
            if (shipname.Equals("PatrolBoat"))
            {
                if (!rotated)
                {
                    switch (middlecoord_x)
                    {
                        case "B":
                            return ("B" + "," + middlecoord_y).Split(',');
                        case "C":
                            return ("C" + "," + middlecoord_y).Split(',');
                        case "D":
                            return ("D" + "," + middlecoord_y).Split(',');
                        case "E":
                            return ("E" + "," + middlecoord_y).Split(',');
                        case "F":
                            return ("F" + "," + middlecoord_y).Split(',');
                        case "G":
                            return ("G" + "," + middlecoord_y).Split(',');
                        case "H":
                            return ("H" + "," + middlecoord_y).Split(',');
                        case "I":
                            return ("I" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    return (middlecoord_x + "," + middlecoord_y).Split(',');
                }
            }
            else if (shipname.Equals("Submarine") || shipname.Equals("Destroyer"))
            {
                if (!rotated)
                {
                    switch (middlecoord_x)
                    {
                        case "B":
                            return ("A" + "," + middlecoord_y).Split(',');
                        case "C":
                            return ("B" + "," + middlecoord_y).Split(',');
                        case "D":
                            return ("C" + "," + middlecoord_y).Split(',');
                        case "E":
                            return ("D" + "," + middlecoord_y).Split(',');
                        case "F":
                            return ("E" + "," + middlecoord_y).Split(',');
                        case "G":
                            return ("F" + "," + middlecoord_y).Split(',');
                        case "H":
                            return ("G" + "," + middlecoord_y).Split(',');
                        case "I":
                            return ("H" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    if (int.Parse(middlecoord_y) > 1)
                    {
                        int starty = int.Parse(middlecoord_y) - 1;
                        return (middlecoord_x + "," + starty.ToString()).Split(',');
                    }
                    else return "asd,1".Split(',');
                }
            }
            else if (shipname.Equals("Battleship"))
            {
                if (!rotated)
                {
                    switch (middlecoord_x)
                    {
                        case "B":
                            return ("A" + "," + middlecoord_y).Split(',');
                        case "C":
                            return ("B" + "," + middlecoord_y).Split(',');
                        case "D":
                            return ("C" + "," + middlecoord_y).Split(',');
                        case "E":
                            return ("D" + "," + middlecoord_y).Split(',');
                        case "F":
                            return ("E" + "," + middlecoord_y).Split(',');
                        case "G":
                            return ("F" + "," + middlecoord_y).Split(',');
                        case "H":
                            return ("G" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    if (int.Parse(middlecoord_y) > 1)
                    {
                        int starty = int.Parse(middlecoord_y) - 1;
                        return (middlecoord_x + "," + starty.ToString()).Split(',');
                    }
                    else return "asd,1".Split(',');
                }
            }
            else if (shipname.Equals("Carrier"))
            {
                if (!rotated)
                {
                    switch (middlecoord_x)
                    {
                        case "C":
                            return ("A" + "," + middlecoord_y).Split(',');
                        case "D":
                            return ("B" + "," + middlecoord_y).Split(',');
                        case "E":
                            return ("C" + "," + middlecoord_y).Split(',');
                        case "F":
                            return ("D" + "," + middlecoord_y).Split(',');
                        case "G":
                            return ("E" + "," + middlecoord_y).Split(',');
                        case "H":
                            return ("F" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    if (int.Parse(middlecoord_y) > 2)
                    {
                        int starty = int.Parse(middlecoord_y) - 2;
                        return (middlecoord_x + "," + starty.ToString()).Split(',');
                    }
                    else return "asd,1".Split(',');
                }
            }
            return "asd,1".Split(',');
        }
        private string[] getEndCoord(string middlecoord_x, string middlecoord_y, string shipname)
        {
            if (shipname.Equals("PatrolBoat"))
            {
                if (!rotated)
                {
                    switch (middlecoord_x)
                    {
                        case "B":
                            return ("C" + "," + middlecoord_y).Split(',');
                        case "C":
                            return ("D" + "," + middlecoord_y).Split(',');
                        case "D":
                            return ("E" + "," + middlecoord_y).Split(',');
                        case "E":
                            return ("F" + "," + middlecoord_y).Split(',');
                        case "F":
                            return ("G" + "," + middlecoord_y).Split(',');
                        case "G":
                            return ("H" + "," + middlecoord_y).Split(',');
                        case "H":
                            return ("I" + "," + middlecoord_y).Split(',');
                        case "I":
                            return ("J" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    if (int.Parse(middlecoord_y) < 10)
                    {
                        int starty = int.Parse(middlecoord_y) + 1;
                        return (middlecoord_x + "," + starty.ToString()).Split(',');
                    }
                    else return "asd,1".Split(',');
                }
            }
            else if (shipname.Equals("Submarine") || shipname.Equals("Destroyer"))
            {
                if (!rotated)
                {
                    switch (middlecoord_x)
                    {
                        case "B":
                            return ("C" + "," + middlecoord_y).Split(',');
                        case "C":
                            return ("D" + "," + middlecoord_y).Split(',');
                        case "D":
                            return ("E" + "," + middlecoord_y).Split(',');
                        case "E":
                            return ("F" + "," + middlecoord_y).Split(',');
                        case "F":
                            return ("G" + "," + middlecoord_y).Split(',');
                        case "G":
                            return ("H" + "," + middlecoord_y).Split(',');
                        case "H":
                            return ("I" + "," + middlecoord_y).Split(',');
                        case "I":
                            return ("J" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    if (int.Parse(middlecoord_y) < 10)
                    {
                        int starty = int.Parse(middlecoord_y) + 1;
                        return (middlecoord_x + "," + starty.ToString()).Split(',');
                    }
                    else return "asd,1".Split(',');
                }
            }
            else if (shipname.Equals("Battleship"))
            {
                if (!rotated)
                {
                    switch (middlecoord_x)
                    {
                        case "B":
                            return ("D" + "," + middlecoord_y).Split(',');
                        case "C":
                            return ("E" + "," + middlecoord_y).Split(',');
                        case "D":
                            return ("F" + "," + middlecoord_y).Split(',');
                        case "E":
                            return ("G" + "," + middlecoord_y).Split(',');
                        case "F":
                            return ("H" + "," + middlecoord_y).Split(',');
                        case "G":
                            return ("I" + "," + middlecoord_y).Split(',');
                        case "H":
                            return ("J" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    if (int.Parse(middlecoord_y) < 9)
                    {
                        int starty = int.Parse(middlecoord_y) + 2;
                        return (middlecoord_x + "," + starty.ToString()).Split(',');
                    }
                    else return "asd,1".Split(',');
                }
            }
            else if (shipname.Equals("Carrier"))
            {
                if (!rotated)
                {
                    switch (middlecoord_x)
                    {
                        case "C":
                            return ("E" + "," + middlecoord_y).Split(',');
                        case "D":
                            return ("F" + "," + middlecoord_y).Split(',');
                        case "E":
                            return ("G" + "," + middlecoord_y).Split(',');
                        case "F":
                            return ("H" + "," + middlecoord_y).Split(',');
                        case "G":
                            return ("I" + "," + middlecoord_y).Split(',');
                        case "H":
                            return ("J" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    if (int.Parse(middlecoord_y) < 9)
                    {
                        int starty = int.Parse(middlecoord_y) + 2;
                        return (middlecoord_x + "," + starty.ToString()).Split(',');
                    }
                    else return "asd,1".Split(',');
                }
            }
            return "asd,1".Split(',');
        }

        //returns the scaling of the ship 
        private System.Windows.Media.ScaleTransform GetBasicScaling(Image boat_image, bool rotated)
        {
            if (rotated)
            {
                if (boat_image.Name.Equals("Submarine") || boat_image.Name.Equals("Destroyer"))
                {
                    return new System.Windows.Media.ScaleTransform(1, 1.5);
                }
                else if (boat_image.Name.Equals("Battleship"))
                {
                    return new System.Windows.Media.ScaleTransform(1, 2);
                }
                else if (boat_image.Name.Equals("Carrier"))
                {
                    return new System.Windows.Media.ScaleTransform(1, 2.5);
                }
                else
                    return new System.Windows.Media.ScaleTransform(1, 1);
            }
            else
            {
                if (boat_image.Name.Equals("Submarine") || boat_image.Name.Equals("Destroyer"))
                {
                    return new System.Windows.Media.ScaleTransform(1.5, 1);
                }
                else if (boat_image.Name.Equals("Battleship"))
                {
                    return new System.Windows.Media.ScaleTransform(2, 1);
                }
                else if (boat_image.Name.Equals("Carrier"))
                {
                    return new System.Windows.Media.ScaleTransform(2.5, 1);
                }
                else
                    return new System.Windows.Media.ScaleTransform(1, 1);
            }
        }

        private void boat_iconRotatePressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //if player presses insert, the ai's ships will appear

            if (e.Key == System.Windows.Input.Key.Insert)
            {
                if (isVsAi)
                {
                    PlaceBoats(null, aiplayer);
                }
            }

            //should only work if a ship is in placement mode
            if (IsPlacementEventStarted)
            {
                if (e.Key == System.Windows.Input.Key.R)
                {
                    System.Windows.Media.TransformGroup transformationGroup = new System.Windows.Media.TransformGroup();
                    if (rotated)
                    {
                        rotated = false;
                        transformationGroup.Children.Add(new System.Windows.Media.RotateTransform(0));
                    }
                    else
                    {
                        rotated = true;
                        transformationGroup.Children.Add(new System.Windows.Media.RotateTransform(90));

                    }
                    transformationGroup.Children.Add(GetBasicScaling(boat_image, rotated));
                    boat_image.RenderTransform = transformationGroup;
                }
            }
        }

        private void boat_StartPlacementEventWhenLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            boat_image = (Image)sender;

                //if the boat is already being in "movement" mode
                if (IsPlacementEventStarted)
                {
                    IsPlacementEventStarted = false;
                    if (!rotated)
                    {
                        Canvas.SetLeft(boat_image, e.GetPosition(this).X - (boat_image.Margin.Left + 20));
                        Canvas.SetTop(boat_image, e.GetPosition(this).Y - (boat_image.Margin.Top + 15));
                    }
                    else
                    {
                        Canvas.SetLeft(boat_image, e.GetPosition(this).X - (boat_image.Margin.Left + 35));
                        Canvas.SetTop(boat_image, e.GetPosition(this).Y - (boat_image.Margin.Top + 5));
                    }

                }
                else
                {
                    IsPlacementEventStarted = true;
                    //if you click on another ship to "pick it up"
                    if (!boat_image.Equals(old_image))
                    {
                        old_image = boat_image;
                        rotated = false;
                    }
                }
        }

        private void boat_ChangeIconPosition(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //should only work if a ship is in placement mode
            if (IsPlacementEventStarted)
            {   //minus the margin, which would make the cursor "touch" the very end of the image, hence why i add 20 for the x and 5 for the y
                Canvas.SetLeft(boat_image, e.GetPosition(this).X - (boat_image.Margin.Left + 20));
                Canvas.SetTop(boat_image, e.GetPosition(this).Y - (boat_image.Margin.Top + 5));
            }

        }

        //TO DO quit from the game if someone wins (or go to highscores)
        private void CheckPlayerWins()
        {
            if (aiplayer.DestroyedShips.Count == 5)
            {
                string wintext = "You win";
                enemy_remaining_ships.Content = wintext;
                CreateHSWindowAndLoadIt(player1,aiplayer.PlayerName, wintext);
            }
        }

        //TO DO quit from the game if someone wins (or go to highscores)
        private void CheckAiWins()
        {
            if (player1.DestroyedShips.Count == 5)
            {
                string wintext = "Ai win!";
                player_remaining_ships.Content = wintext;
                CreateHSWindowAndLoadIt(player1,aiplayer.PlayerName, wintext);
            }
        }

        private void CreateHSWindowAndLoadIt(PlayerEntity player,string player2,string wintext) {
            HighscoresWindow hs = new HighscoresWindow(wintext,player.PlayerName,player2,player.DestroyedShips.Count.ToString(), player.RemainingShips.Count.ToString(), player.PlayerHits.Count.ToString(), player.EnemyHits.Count.ToString(), player.RoundsNo.ToString());
            this.Visibility = Visibility.Hidden;
            hs.Show();
        }

        //TO DO check ai turns
        private void AiTurns()
        {
            //aiplayer.RoundsNo++;
        }

        //This is for testing
        private void TestingLabel(string output) {
            number_of_rounds.Content = output;
        }

        private void AiRandomCoord()
        {
            const string range = "ABCDEFGHIJ";
            System.Random rnd = new System.Random();

            int dice = rnd.Next(1, 11);
            string Coord1 = new string(Enumerable.Range(1, 1).Select(x => range[rnd.Next(0, range.Length)]).ToArray());
            TestingLabel(Coord1 + dice.ToString()); 
            AiClickButton(Coord1 + dice.ToString());
        }
        
        //in progress
        private void AiClickButton(string coord_tip)
        {
            Button clicked_button = (Button)PlayerShipTable.FindName(coord_tip);
            //clicked_button.Click += new EventHandler(this.clicked_button);
        }
        
        //in progress
        private void buttons_Click(object sender, EventArgs e)
        {
            //Button clicked_button = (Button)sender;
        }
    }
}
