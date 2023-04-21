using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess__
{
    interface IPiece
    {
        int Row { get; set; }
        int Column { get; set; }
        char? Type { get; set; }
        char? Team { get; set; }
        string? Image { get; set; }
        
        int[,] MovesAvailable();
        void setToBlank();

        void movePiece(int row, int col);
        string getInfo();
    }
}
