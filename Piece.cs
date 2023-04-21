using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess__
{
    class Piece : IPiece
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public char? Type { get; set; }
        public char? Team { get; set; }
        public string? Image { get; set; }

        public int[,] MovesAvailable()
        {
            throw new NotImplementedException();
        }

        public void setToBlank() {
            this.Type = 'n';
            this.Team = 'n';
            this.Image = null;
        }

        public void movePiece(int row, int col) { 
            this.Row = row;
            this.Column = col;
        }

        public string getInfo() { 
            return this.Row + " " + this.Column + " " + this.Type + " " + this.Team + " " + this.Image;
        }
    }
}

