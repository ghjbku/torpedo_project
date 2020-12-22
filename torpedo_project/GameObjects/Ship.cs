using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torpedo_project.GameObjects
{
    class Ship
    {
        private string x_start { get; set; }
        private int y_start { get; set; }
        private string x_end { get; set; }
        private int y_end { get; set; }
        public string shipType { get; set; }

        public bool rotated { get; set; }

        enum ALPHABETS {
                A = 'A',
                B = 'B',
                C = 'C',
                D = 'D',
                E = 'E',
                F = 'F',
                G = 'G',
                H = 'H',
                I = 'I',
                J = 'J'
        }

        public Ship(string x_start, int y_start, string x_end, int y_end,string shipType) {
            this.x_start = x_start;
            this.y_start = y_start;
            this.x_end = x_end;
            this.y_end = y_end;
            this.shipType = shipType;

            if (!this.x_start.Equals(this.x_end)) {
                this.rotated = true;
            }
        }

        public string[,] getCoords() {
            string[,] coords2x;
            string[,] coords3x;
            string[,] coords4x;
            string[,] coords5x;
            switch (shipType) {
                case "PatrolBoat":
                coords2x = new string[,] { { x_start, y_start.ToString() },
                                           { x_end, y_end.ToString() } };
                return coords2x;

                case "Submarine":
                    if (x_start.Equals(x_end))
                    {
                        if (y_end - y_start == 2)
                        {
                            coords3x = new string[,] { { x_start, y_start.ToString() },
                                                       { x_end, (y_end - 1).ToString() }, 
                                                       { x_end, y_end.ToString() } };
                            return coords3x;
                        }
                        else return null;
                    }
                    else if (y_start.Equals(y_end))
                    {
                        if (check_for_alphabetic_order(x_start, x_end,shipType))
                        {
                            coords3x = new string[,] { { x_start, y_start.ToString() },
                                                       { GetMiddlecoord(x_start).ToString(), y_end.ToString() },
                                                       { x_end, y_end.ToString() } };
                            return coords3x;
                        }
                        else return null;
                    }
                    else return null;

                case "Destroyer":
                    if (x_start.Equals(x_end))
                    {
                        if (y_end - y_start == 2)
                        {
                            coords3x = new string[,] { { x_start, y_start.ToString() },
                                                       { x_end, (y_end - 1).ToString() },
                                                       { x_end, y_end.ToString() } };
                            return coords3x;
                        }
                        else return null;
                    }
                    else if (y_start.Equals(y_end))
                    {
                        if (check_for_alphabetic_order(x_start, x_end, shipType))
                        {
                            coords3x = new string[,] { { x_start, y_start.ToString() },
                                                       { GetMiddlecoord(x_start).ToString(), y_end.ToString() },
                                                       { x_end, y_end.ToString() } };
                            return coords3x;
                        }
                        else return null;
                    }
                    else return null;

                case "Battleship":
                    if (x_start.Equals(x_end))
                    {
                        if (y_end - y_start == 3)
                        {
                            coords4x = new string[,] { { x_start, y_start.ToString() },
                                                       { x_end, (y_end - 2).ToString() },
                                                       { x_end, (y_end - 1).ToString() },
                                                       { x_end, y_end.ToString() } };
                            return coords4x;
                        }
                        else return null;
                    }
                    else if (y_start.Equals(y_end))
                    {
                        if (check_for_alphabetic_order(x_start, x_end, shipType))
                        {
                            coords4x = new string[,] { { x_start, y_start.ToString() },
                                                       { GetMiddlecoord(x_start).ToString(), y_end.ToString() },
                                                       { GetMiddlecoord(GetMiddlecoord(x_start).ToString()), y_end.ToString() },
                                                       { x_end, y_end.ToString() } };
                            return coords4x;
                        }
                        else return null;
                    }
                    else return null;
                    

                case "Carrier":
                    if (x_start.Equals(x_end))
                    {
                        if (y_end - y_start == 4)
                        {
                            coords5x = new string[,] { { x_start, y_start.ToString() },
                                                       { x_end, (y_end - 3).ToString() },
                                                       { x_end, (y_end - 2).ToString() },
                                                       { x_end, (y_end - 1).ToString() },
                                                       { x_end, y_end.ToString() } };
                            return coords5x;
                        }
                        else return null;
                    }
                    else if (y_start.Equals(y_end))
                    {
                        if (check_for_alphabetic_order(x_start, x_end, shipType))
                        {
                            coords5x = new string[,] { { x_start, y_start.ToString() },
                                                       { GetMiddlecoord(x_start).ToString(), y_end.ToString() },
                                                       { GetMiddlecoord(GetMiddlecoord(x_start).ToString()), y_end.ToString() },
                                                       { GetMiddlecoord(GetMiddlecoord(GetMiddlecoord(x_start).ToString())), y_end.ToString() },
                                                       { x_end, y_end.ToString() } };
                            return coords5x;
                        }
                        else return null;
                    }
                    else return null;

                default:
                    return null;
            }
        }


        private string GetMiddlecoord(string x_start) {
            if (x_start.Equals(ALPHABETS.A.ToString())) return ALPHABETS.B.ToString();
            else if (x_start.Equals(ALPHABETS.B.ToString())) return ALPHABETS.C.ToString();
            else if (x_start.Equals(ALPHABETS.C.ToString())) return ALPHABETS.D.ToString();
            else if (x_start.Equals(ALPHABETS.D.ToString())) return ALPHABETS.E.ToString();
            else if (x_start.Equals(ALPHABETS.E.ToString())) return ALPHABETS.F.ToString();
            else if (x_start.Equals(ALPHABETS.F.ToString())) return ALPHABETS.G.ToString();
            else if (x_start.Equals(ALPHABETS.G.ToString())) return ALPHABETS.H.ToString();
            else if (x_start.Equals(ALPHABETS.H.ToString())) return ALPHABETS.I.ToString();
            else if (x_start.Equals(ALPHABETS.I.ToString())) return ALPHABETS.J.ToString();
            else return ALPHABETS.A.ToString();
        }

        private bool check_for_alphabetic_order(string start, string end, string shiptype)
        {
            if (shiptype.Equals("Submarine"))
            {
                if (start.Equals("A") && end.Equals("C")) return true;
                else if (start.Equals("B") && end.Equals("D")) return true;
                else if (start.Equals("C") && end.Equals("E")) return true;
                else if (start.Equals("D") && end.Equals("F")) return true;
                else if (start.Equals("E") && end.Equals("G")) return true;
                else if (start.Equals("F") && end.Equals("H")) return true;
                else if (start.Equals("G") && end.Equals("I")) return true;
                else if (start.Equals("H") && end.Equals("J")) return true;
                else return false;
            }
            //TODO make the checking for all the ship types
            else if (shiptype.Equals("Destroyer"))
            {
                if (start.Equals("A") && end.Equals("C")) return true;
                else if (start.Equals("B") && end.Equals("D")) return true;
                else if (start.Equals("C") && end.Equals("E")) return true;
                else if (start.Equals("D") && end.Equals("F")) return true;
                else if (start.Equals("E") && end.Equals("G")) return true;
                else if (start.Equals("F") && end.Equals("H")) return true;
                else if (start.Equals("G") && end.Equals("I")) return true;
                else if (start.Equals("H") && end.Equals("J")) return true;
                else return false;
            }
            else if (shiptype.Equals("Battleship"))
            {
                if (start.Equals("A") && end.Equals("D")) return true;
                else if (start.Equals("B") && end.Equals("E")) return true;
                else if (start.Equals("C") && end.Equals("F")) return true;
                else if (start.Equals("D") && end.Equals("G")) return true;
                else if (start.Equals("E") && end.Equals("H")) return true;
                else if (start.Equals("F") && end.Equals("I")) return true;
                else if (start.Equals("G") && end.Equals("J")) return true;
                else return false;
            }
            else if (shiptype.Equals("Carrier"))
            {
                if (start.Equals("A") && end.Equals("E")) return true;
                else if (start.Equals("B") && end.Equals("F")) return true;
                else if (start.Equals("C") && end.Equals("G")) return true;
                else if (start.Equals("D") && end.Equals("H")) return true;
                else if (start.Equals("E") && end.Equals("I")) return true;
                else if (start.Equals("F") && end.Equals("J")) return true;
                else return false;
            }
            else return false;
        }
    }
}
