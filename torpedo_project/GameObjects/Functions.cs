using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace torpedo_project.GameObjects
{
    static class Functions
    {
        public static bool CoordsEqual(string coord, string shipCoords)
        {
            if (coord.Equals(shipCoords))
            {
                return true;
            }
            else return false;
        }
        public static string[] getStartCoord(string middlecoord_x, string middlecoord_y, string shipname,bool rotated)
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

        public static string[] getEndCoord(string middlecoord_x, string middlecoord_y, string shipname, bool rotated)
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

        public static void CheckIfAllShipCoordsHit(Ship lastShipHit, AiPlayer aiplayer)
        {
            if (lastShipHit.shipType.Equals("PatrolBoat"))
            {
                if (lastShipHit.ShipPartsHit == 2)
                {
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

        }

        public static void UpdateRemainingShips(string whichplayer, Label NumberofHits, Label player_remaining_ships, Label enemy_remaining_ships, AiPlayer aiplayer, Player player1)
        {
            NumberofHits.Content = player1.PlayerHits.Count.ToString();
            if (player1.RemainingShips.Count <= 5)
            {
                if (whichplayer.Equals(player1.PlayerName))
                {
                    player_remaining_ships.Content = player1.RemainingShips.Count.ToString();
                }
                else
                {
                    enemy_remaining_ships.Content = aiplayer.RemainingShips.Count.ToString();
                }
            }
        }
    }
}
