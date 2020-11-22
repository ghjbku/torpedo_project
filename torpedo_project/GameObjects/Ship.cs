using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torpedo_project.GameObjects
{
    class Ship
    {
        private char x_start { get; set; }
        private char y_start { get; set; }
        private char x_end { get; set; }
        private char y_end { get; set; }

        public Ship(char x_start, char y_start, char x_end, char y_end) {
            this.x_start = x_start;
            this.y_start = y_start;
            this.x_end = x_end;
            this.y_end = y_end;
        }

        public char[,] getCoords() {
            char[,] coords = new char[,] { {x_start, y_start }, { x_end, y_end } };
            return coords;
        }
    }
}
