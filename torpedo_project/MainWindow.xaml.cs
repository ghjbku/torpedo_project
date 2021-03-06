﻿using System;
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
        private bool IsPlacementEventStarted = false, rotated = false, isVsAi = true, is_created = false, is_placement_finished = false;
        private Image boat_image, old_image;
        public string partHit, partHitAi, LastCoordThatHit;
        public GameObjects.Ship lastShipHit, lastShipHitAi;
        private System.Collections.Generic.List<string> turn_possible_content;
        private short whoseturn;
        private short changeturn { get { return whoseturn; } set { whoseturn = value; OnturnChanged(); } }
        private string PathForXml;

        public MainWindow(string name, bool isai, string pathForXml)
        {
            InitializeComponent();
            turn_possible_content = new System.Collections.Generic.List<string>();
            player_name_test_label.Content = name;
            old_image = null;
            partHit = "";
            isVsAi = isai;
            PathForXml = pathForXml;
            InitGame(name);
        }

        private void InitGame(string playername)
        {
            turn_possible_content.Add("Your turn!");
            turn_possible_content.Add("AI turn!");
            player1 = new GameObjects.Player(playername)
            {
                RoundsNo = 0
            };
            aiplayer = new GameObjects.AiPlayer
            {
                RoundsNo = 0
            };
            AiShipPlacement(aiplayer);
            GameObjects.Functions.UpdateRemainingShipsForAi(NumberofHits, enemy_remaining_ships, aiplayer, player1);
        }
        private void AiShipPlacement(GameObjects.AiPlayer aiplayer)
        {
            const string range = "ABCDEFGHIJ";
            Random rnd = new Random();

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
        private bool PlayerHitsaShip(string clickedArea, PlayerEntity playerThatWasHit)
        {
            int i = 0;
            while (i < playerThatWasHit.RemainingShips.Count)
            {
                char[] arrayForTrim = { 't', '_' };
                var name = clickedArea.TrimEnd(arrayForTrim);
                var ship = playerThatWasHit.RemainingShips[i];
                switch (ship.getCoords().Length)
                {
                    case 4:
                        if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                                GameObjects.Functions.CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]))
                        {
                            if (playerThatWasHit.Equals(aiplayer))
                            {
                                lastShipHit = ship;
                                WhichPartIsHit(clickedArea, ship, i, 4, false);
                            }
                            else if (playerThatWasHit.Equals(player1))
                            {
                                lastShipHitAi = ship;
                                WhichPartIsHit(clickedArea, ship, i, 4, true);
                            }
                            return true;
                        }
                        else i++;
                        break;

                    case 6:
                        if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                            GameObjects.Functions.CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                            GameObjects.Functions.CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1])
                            )
                        {
                            if (playerThatWasHit.Equals(aiplayer))
                            {
                                lastShipHit = ship;
                                WhichPartIsHit(clickedArea, ship, i, 6, false);
                            }
                            else if (playerThatWasHit.Equals(player1))
                            {
                                lastShipHitAi = ship;
                                WhichPartIsHit(clickedArea, ship, i, 6, true);
                            }
                            return true;
                        }
                        else i++;
                        break;

                    case 8:
                        if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                            GameObjects.Functions.CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                            GameObjects.Functions.CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]) ||
                            GameObjects.Functions.CoordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1])
                            )
                        {
                            if (playerThatWasHit.Equals(aiplayer))
                            {
                                lastShipHit = ship;
                                WhichPartIsHit(clickedArea, ship, i, 8, false);
                            }
                            else if (playerThatWasHit.Equals(player1))
                            {
                                lastShipHitAi = ship;
                                WhichPartIsHit(clickedArea, ship, i, 8, true);
                            }
                            return true;
                        }
                        else i++;
                        break;
                    case 10:
                        if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]) ||
                            GameObjects.Functions.CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                            GameObjects.Functions.CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]) ||
                            GameObjects.Functions.CoordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1]) ||
                            GameObjects.Functions.CoordsEqual(name, ship.getCoords()[4, 0] + ship.getCoords()[4, 1])
                            )
                        {
                            if (playerThatWasHit.Equals(aiplayer))
                            {
                                lastShipHit = ship;
                                WhichPartIsHit(clickedArea, ship, i, 10, false);
                            }
                            else if (playerThatWasHit.Equals(player1))
                            {
                                lastShipHitAi = ship;
                                WhichPartIsHit(clickedArea, ship, i, 10, true);
                            }
                            return true;
                        }
                        else i++;
                        break;
                }
            }
            return false;
        }

        private void StartGameAfterPlacement()
        {
            is_placement_finished = true;
            PatrolBoat.Visibility = Visibility.Hidden;
            Submarine.Visibility = Visibility.Hidden;
            Destroyer.Visibility = Visibility.Hidden;
            Battleship.Visibility = Visibility.Hidden;
            Carrier.Visibility = Visibility.Hidden;

            changeturn = (short)new Random().Next(0, turn_possible_content.Count);
            turn_indicator.Content = turn_possible_content[whoseturn];
            if (whoseturn == 1)
            {
                AiTurns();
            }
            player1.RoundsNo++;
        }

        private void WhichPartIsHit(string clickedButtonCoord, GameObjects.Ship ship, int i, int HowLong, bool ai)
        {
            char[] arrayForTrim = { 't', '_' };
            var name = clickedButtonCoord.TrimEnd(arrayForTrim);
            if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[0, 0] + ship.getCoords()[0, 1]))
            {
                if (ship.rotated)
                {
                    if (!ai)
                    {
                        partHit = "ShipHitLeftFront";
                    }
                    else partHitAi = "ShipHitLeftFront";
                }
                else if (!ai)
                {
                    partHit = "ShipHitFront";
                }
                else partHitAi = "ShipHitFront";
            }
            if (HowLong == 4)
            {
                if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]))
                {
                    if (ship.rotated)
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitLeftBack";
                        }
                        else partHitAi = "ShipHitLeftBack";
                    }
                    else
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitBack";
                        }
                        else partHitAi = "ShipHitBack";
                    }
                }
            }
            else if (HowLong == 6)
            {
                if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]))
                {
                    if (ship.rotated)
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitLeftMid";
                        }
                        else partHitAi = "ShipHitLeftMid";
                    }
                    else
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitMid";
                        }
                        else partHitAi = "ShipHitMid";
                    }
                }
                else if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]))
                {
                    if (ship.rotated)
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitLeftBack";
                        }
                        else partHitAi = "ShipHitLeftBack";
                    }
                    else
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitBack";
                        }
                        else partHitAi = "ShipHitBack";
                    }
                }
            }
            else if (HowLong == 8)
            {
                if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                    GameObjects.Functions.CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1])
                   )
                {
                    if (ship.rotated)
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitLeftMid";
                        }
                        else partHitAi = "ShipHitLeftMid";
                    }
                    else
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitMid";
                        }
                        else partHitAi = "ShipHitLeftMid";
                    }
                }
                else if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1]))
                {
                    if (ship.rotated)
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitLeftBack";
                        }
                        else partHitAi = "ShipHitLeftBack";
                    }
                    else
                    {
                        if (!ai)
                        { partHit = "ShipHitBack"; }
                        else partHitAi = "ShipHitBack";
                    }
                }
            }
            else if (HowLong == 10)
            {
                if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[1, 0] + ship.getCoords()[1, 1]) ||
                   GameObjects.Functions.CoordsEqual(name, ship.getCoords()[2, 0] + ship.getCoords()[2, 1]) ||
                   GameObjects.Functions.CoordsEqual(name, ship.getCoords()[3, 0] + ship.getCoords()[3, 1])
                  )
                {
                    if (ship.rotated)
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitLeftMid";
                        }
                        else partHitAi = "ShipHitLeftMid";
                    }
                    else
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitMid";
                        }
                        else partHitAi = "ShipHitMid";
                    }
                }
                else if (GameObjects.Functions.CoordsEqual(name, ship.getCoords()[4, 0] + ship.getCoords()[4, 1]))
                {
                    if (ship.rotated)
                    {
                        if (!ai)
                        {
                            partHit = "ShipHitLeftBack";
                        }
                        else partHitAi = "ShipHitLeftBack";
                    }
                    else
                    {
                        if (!ai)
                        { partHit = "ShipHitBack"; }
                        else partHitAi = "ShipHitBack";
                    }
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
            if (player1.RemainingShips.Count <= 5 && aiplayer.RemainingShips.Count <= 5)
            {
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
                if (is_placement_finished)
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
                                lastShipHit.ShipPartsHit += 1;
                            }

                            GameObjects.Functions.CheckIfAllShipCoordsHit(lastShipHit, aiplayer);
                            GameObjects.Functions.UpdateRemainingShipsForAi(NumberofHits, enemy_remaining_ships, aiplayer, player1);
                            CheckPlayerWins();

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
                            SetTurnData(1);
                        }
                        else
                        {
                            if (clickedArea.Content == null)
                            {
                                clickedArea.Content = (Image)FindResource("NotHit");
                                SetTurnData(1);
                            }
                            else { return; }
                        }
                    }
                    player1.RoundsNo++;
                }
            }
            else
            {
                CreateShipOnPosition(old_image.Name, clickedArea.Name, player1, false);
            }
        }

        private void CreateShipOnPosition(string ship_name, string m_position, PlayerEntity player, bool aiship)
        {
            string[] resultAlphabet = System.Text.RegularExpressions.Regex.Split(m_position, @"\d+");
            string[] resultNumber = System.Text.RegularExpressions.Regex.Split(m_position, @"\D+");
            string[] startCoord, endCoord;
            GameObjects.Ship createdShip;

            startCoord = GameObjects.Functions.getStartCoord(resultAlphabet[0], resultNumber[1], ship_name, rotated);
            endCoord = GameObjects.Functions.getEndCoord(resultAlphabet[0], resultNumber[1], ship_name, rotated);

            if (startCoord[0].Equals("asd") || endCoord[0].Equals("asd"))
            {
                return;
            }

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
                GameObjects.Functions.UpdateRemainingShips(NumberofHits, player_remaining_ships, aiplayer, player1, true);
            }

            if (player1.RemainingShips.Count == 5)
            {
                StartGameAfterPlacement();
            }

            old_image = null;
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

        private void SetTurnData(short which)
        {
            turn_indicator.Content = turn_possible_content[which];
            changeturn = which;
        }


        //this will run every time the turn is changed
        private void OnturnChanged()
        {
            if (whoseturn == 1)
            {
                AiTurns();
                player1.RoundsNo++;
            }
            RoundNumber(player1.RoundsNo.ToString());
        }

        private void RoundNumber(string output)
        {
            number_of_rounds.Content = output;
        }

        private void AiTurns()
        {
            AiClickButton(GameObjects.Functions.AiRandomCoord(LastCoordThatHit, lastShipHitAi));
        }

        private void AiClickButton(string coord_tip)
        {
            Button clicked_button = (Button)PlayerShipTable.FindName(coord_tip);
            if (PlayerHitsaShip(clicked_button.Name, player1))
            {
                LastCoordThatHit = coord_tip;
                if (aiplayer.PlayerHits.Contains(clicked_button.Name))
                {
                    AiTurns();
                    return;
                }
                else
                {
                    clicked_button.Content = (Image)FindResource(partHitAi);
                    aiplayer.updatePlayerHits(clicked_button.Name);
                    player1.updateEnemyHits(clicked_button.Name);
                    lastShipHitAi.ShipPartsHit += 1;
                }
                if (lastShipHitAi.ShipPartsHit > 1)
                {
                    if (GameObjects.Functions.CheckIfAllShipCoordsHit(lastShipHitAi, player1) == null)
                    {
                        LastCoordThatHit = null;
                        GameObjects.Functions.UpdateRemainingShips(NumberofHitsEnemy, player_remaining_ships, aiplayer, player1, false);
                        CheckAiWins();
                    }
                }
            }
            else
            {
                if (clicked_button.Content != null)
                {
                    AiTurns();
                    return;
                }
                else
                {
                    clicked_button.Content = (Image)FindResource("NotHit");

                }
            }
            SetTurnData(0);
        }

        private void CheckPlayerWins()
        {
            if (aiplayer.RemainingShips.Count == 0)
            {
                string wintext = "You win";
                player1.won = true;
                CreateHSWindowAndLoadIt(player1, aiplayer.PlayerName, wintext);
            }
        }

        private void CheckAiWins()
        {
            if (player1.RemainingShips.Count == 0)
            {
                string wintext = "Ai win!";
                player1.won = false;
                CreateHSWindowAndLoadIt(player1, aiplayer.PlayerName, wintext);
            }
        }

        private void CreateHSWindowAndLoadIt(PlayerEntity player, string player2, string wintext)
        {
            if (!is_created)
            {
                is_created = true;
                HighscoresWindow hs = new HighscoresWindow(wintext, player, player.PlayerName, player2, player.DestroyedShips.Count.ToString(), player.RemainingShips.Count.ToString(), player.PlayerHits.Count.ToString(), player.EnemyHits.Count.ToString(), player.RoundsNo.ToString(), PathForXml);
                this.Visibility = Visibility.Hidden;
                hs.Show();
            }
        }

    }
}
