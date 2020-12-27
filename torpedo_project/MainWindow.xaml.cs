﻿using System.Windows;
using System.Windows.Controls;

namespace torpedo_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameObjects.Player player1;
        private bool IsPlacementEventStarted = false, rotated = false;
        private Image boat_image,old_image;
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
            old_image = null;
        }

        private void TestPlayerClasses()
        {


            player1 = new GameObjects.Player("test_player");
            player1.PlayerName = player_name_test_label.Content.ToString();
            player_name_test_label.Content = player1.PlayerName;
          /*  player1.fillUpRemainingShips(new GameObjects.Ship("A", 1, "A", 2, "PatrolBoat"));
            player1.fillUpRemainingShips(new GameObjects.Ship("A", 5, "A", 7, "Submarine"));
            player1.fillUpRemainingShips(new GameObjects.Ship("C", 1, "D", 1, "PatrolBoat"));
            player1.fillUpRemainingShips(new GameObjects.Ship("B", 5, "D", 5, "Submarine"));
            player1.fillUpRemainingShips(new GameObjects.Ship("C", 3, "E", 3, "Submarine"));
            player1.fillUpRemainingShips(new GameObjects.Ship("J", 1, "J", 3, "Destroyer"));
            player1.fillUpRemainingShips(new GameObjects.Ship("I", 4, "I", 7, "Battleship"));
            player1.fillUpRemainingShips(new GameObjects.Ship("A", 9, "D", 9, "Battleship"));
            player1.fillUpRemainingShips(new GameObjects.Ship("F", 9, "J", 9, "Carrier"));
            player1.fillUpRemainingShips(new GameObjects.Ship("G", 3, "G", 7, "Carrier"));
            place_boats(player1);*/
        }

        //checking if a player "hits" a ship
        private bool PlayerHits_a_Ship(string clickedArea, GameObjects.Player player)
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

        private bool coordsEqual(string coord, string shipCoords)
        {
            if (coord.Equals(shipCoords))
            {
                return true;
            }
            else return false;
        }


        private void place_boats(GameObjects.Player player)
        {
            foreach (GameObjects.Ship ship in player.RemainingShips)
            {
                drawBoat(ship);
            }
        }

        private void drawBoat(GameObjects.Ship ship) {
            Image front, mid, mid2, mid3, back;

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
                else if (ship.shipType.Equals("Carrier")) {
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
            else {
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
                else if (ship.shipType.Equals("Carrier")) {
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

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button clickedArea = (Button)sender;

            //if its not placement mode
            if (old_image == null)
            {
                player_name_test_label.Content = clickedArea.Name;

                if (PlayerHits_a_Ship(clickedArea.Name, player1))
                {
                    player_name_test_label.Content = "you have hit " + clickedArea.Name;
                }
            }
            else {
                create_shipOnPosition(old_image.Name,clickedArea);
            }

        }

        private void create_shipOnPosition(string ship_name,Button middle_position_button) {
            string m_position = middle_position_button.Name;
            string[] resultAlphabet = System.Text.RegularExpressions.Regex.Split(m_position, @"\d+");
            string[] resultNumber = System.Text.RegularExpressions.Regex.Split(m_position, @"\D+");
            string[] startCoord,endCoord;
            GameObjects.Ship createdShip;

                startCoord = getStartCoord(resultAlphabet[0], resultNumber[1], ship_name);
                endCoord = getEndCoord(resultAlphabet[0], resultNumber[1], ship_name);
                player_name_test_label.Content = startCoord[0] + startCoord[1] + "," + endCoord[0] + endCoord[1];

                Canvas.SetLeft(boat_image, 0);
                Canvas.SetTop(boat_image, 0);
            boat_image.RenderTransform = GetBasicScaling(boat_image,false);

                if (startCoord[0].Equals("asd"))
                {
                    return;
                }

            if (PlayerHits_a_Ship(m_position, player1)||
                PlayerHits_a_Ship(startCoord[0]+startCoord[1], player1)||
                PlayerHits_a_Ship(endCoord[0] + endCoord[1], player1)
               )
            { old_image = null; return; }

                createdShip = new GameObjects.Ship(startCoord[0], int.Parse(startCoord[1]), endCoord[0], int.Parse(endCoord[1]), ship_name);
                player1.fillUpRemainingShips(createdShip);
                drawBoat(createdShip);

            old_image = null;
        }

        private string[] getStartCoord(string middlecoord_x,string middlecoord_y, string shipname) {
            if (shipname.Equals("PatrolBoat")) {
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
                else {
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
                    int starty = int.Parse(middlecoord_y) - 1;
                    return (middlecoord_x + "," + starty.ToString()).Split(',');
                }
            }
            else if (shipname.Equals("Battleship"))
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
                        case "I":
                            return ("G" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    int starty = int.Parse(middlecoord_y) - 2;
                    return (middlecoord_x + "," + starty.ToString()).Split(',');
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
                        case "I":
                            return ("G" + "," + middlecoord_y).Split(',');
                    }
                }
                else
                {
                    int starty = int.Parse(middlecoord_y) - 2;
                    return (middlecoord_x + "," + starty.ToString()).Split(',');
                }
            }
            return "asd,1".Split(',');
        }
        private string[] getEndCoord(string middlecoord_x, string middlecoord_y,string shipname)
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
                    int starty = int.Parse(middlecoord_y) + 1;
                    return (middlecoord_x + "," + starty.ToString()).Split(',');
                }
            }
            else if(shipname.Equals("Submarine")|| shipname.Equals("Destroyer")){
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
                    int starty = int.Parse(middlecoord_y) + 1;
                    return (middlecoord_x + "," + starty.ToString()).Split(',');
                }
            }
            else if (shipname.Equals("Battleship"))
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
                    int starty = int.Parse(middlecoord_y) + 1;
                    return (middlecoord_x + "," + starty.ToString()).Split(',');
                }
            }
            else if (shipname.Equals("Carrier"))
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
                    int starty = int.Parse(middlecoord_y) + 2;
                    return (middlecoord_x + "," + starty.ToString()).Split(',');
                }
            }
            return "asd,1".Split(',');
        }

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

            if (IsPlacementEventStarted)
            {
                IsPlacementEventStarted = false;
                if (!rotated)
                {
                    Canvas.SetLeft(boat_image, e.GetPosition(this).X - (boat_image.Margin.Left + 20));
                    Canvas.SetTop(boat_image, e.GetPosition(this).Y - (boat_image.Margin.Top + 15));
                }
                else {
                    Canvas.SetLeft(boat_image, e.GetPosition(this).X - (boat_image.Margin.Left + 35));
                    Canvas.SetTop(boat_image, e.GetPosition(this).Y - (boat_image.Margin.Top + 5));
                }

            }
            else
            {
                IsPlacementEventStarted = true;
                if (!boat_image.Equals(old_image)) { 
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
    }
}
