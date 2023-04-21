using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Chess__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int test = 0;
        private Dictionary<int, Dictionary<int, IPiece>> boardState = new Dictionary<int, Dictionary<int, IPiece>>();
        private bool highlighted;
        private IPiece selectedPiece = new Piece();
        private int selectedX;
        private int selectedY;

        // Add the Pawn instance to the list



        public MainWindow()
        {
            //List<IPiece> pieceList = new List<IPiece>();
            //Dictionary<int, Dictionary<int, IPiece>> boardState = new Dictionary<int, Dictionary<int, IPiece>>();
            boardState.Add(0, new Dictionary<int, IPiece>());
            boardState.Add(1, new Dictionary<int, IPiece>());
            boardState.Add(2, new Dictionary<int, IPiece>());
            boardState.Add(3, new Dictionary<int, IPiece>());
            boardState.Add(4, new Dictionary<int, IPiece>());
            boardState.Add(5, new Dictionary<int, IPiece>());
            boardState.Add(6, new Dictionary<int, IPiece>());
            boardState.Add(7, new Dictionary<int, IPiece>());

            IPiece blackrook1 = new Piece();
            blackrook1.Row = 0;
            blackrook1.Column = 0;
            blackrook1.Type = 'r';
            blackrook1.Team = 'b';
            blackrook1.Image = "/Resources/rook_black.png";
            boardState[0][0] = blackrook1;

            IPiece blackrook2 = new Piece();
            blackrook2.Row = 0;
            blackrook2.Column = 7;
            blackrook2.Type = 'r';
            blackrook2.Team = 'b';
            blackrook2.Image = "/Resources/rook_black.png";
            boardState[0][7] = blackrook2;

            IPiece whiterook1 = new Piece();
            whiterook1.Row = 7;
            whiterook1.Column = 0;
            whiterook1.Type = 'r';
            whiterook1.Team = 'w';
            whiterook1.Image = "/Resources/rook_white.png";
            boardState[7][0] = whiterook1;

            IPiece whiterook2 = new Piece();
            whiterook2.Row = 7;
            whiterook2.Column = 7;
            whiterook2.Type = 'r';
            whiterook2.Team = 'w';
            whiterook2.Image = "/Resources/rook_white.png";
            boardState[7][7] = whiterook2;

            IPiece blackknight1 = new Piece();
            blackknight1.Row = 0;
            blackknight1.Column = 1;
            blackknight1.Type = 'k';
            blackknight1.Team = 'k';
            blackknight1.Image = "/Resources/knight_black.png";
            boardState[0][1] = blackknight1;

            IPiece blackknight2 = new Piece();
            blackknight2.Row = 0;
            blackknight2.Column = 6;
            blackknight2.Type = 'k';
            blackknight2.Team = 'b';
            blackknight2.Image = "/Resources/knight_black.png";
            boardState[0][6] = blackknight2;

            IPiece whiteknight1 = new Piece();
            whiteknight1.Row = 7;
            whiteknight1.Column = 1;
            whiteknight1.Type = 'k';
            whiteknight1.Team = 'w';
            whiteknight1.Image = "/Resources/knight_white.png";
            boardState[7][1] = whiteknight1;

            IPiece whiteknight2 = new Piece();
            whiteknight2.Row = 7;
            whiteknight2.Column = 6;
            whiteknight2.Type = 'k';
            whiteknight2.Team = 'w';
            whiteknight2.Image = "/Resources/knight_white.png";
            boardState[7][6] = whiteknight2;

            IPiece blackbishop1 = new Piece();
            blackbishop1.Row = 0;
            blackbishop1.Column = 2;
            blackbishop1.Type = 'b';
            blackbishop1.Team = 'b';
            blackbishop1.Image = "/Resources/bishop_black.png";
            boardState[0][2] = blackbishop1;

            IPiece blackbishop2 = new Piece();
            blackbishop2.Row = 0;
            blackbishop2.Column = 5;
            blackbishop2.Type = 'b';
            blackbishop2.Team = 'b';
            blackbishop2.Image = "/Resources/bishop_black.png";
            boardState[0][5] = blackbishop2;

            IPiece whitebishop1 = new Piece();
            whitebishop1.Row = 7;
            whitebishop1.Column = 2;
            whitebishop1.Type = 'b';
            whitebishop1.Team = 'w';
            whitebishop1.Image = "/Resources/bishop_white.png";
            boardState[7][2] = whitebishop1;

            IPiece whitebishop2 = new Piece();
            whitebishop2.Row = 7;
            whitebishop2.Column = 5;
            whitebishop2.Type = 'b';
            whitebishop2.Team = 'w';
            whitebishop2.Image = "/Resources/bishop_white.png";
            boardState[7][5] = whitebishop2;

            IPiece whitequeen = new Piece();
            whitequeen.Row = 0;
            whitequeen.Column = 4;
            whitequeen.Type = 'q';
            whitequeen.Team = 'w';
            whitequeen.Image = "/Resources/queen_white.png";
            boardState[7][4] = whitequeen;

            IPiece blackqueen = new Piece();
            blackqueen.Row = 7;
            blackqueen.Column = 4;
            blackqueen.Type = 'q';
            blackqueen.Team = 'b';
            blackqueen.Image = "/Resources/queen_black.png";
            boardState[0][4] = blackqueen;

            IPiece whiteking = new Piece();
            whiteking.Row = 7;
            whiteking.Column = 3;
            whiteking.Type = 'k';
            whiteking.Team = 'w';
            whiteking.Image = "/Resources/king_white.png";
            boardState[7][3] = whiteking;

            IPiece blackking = new Piece();
            blackking.Row = 0;
            blackking.Column = 3;
            blackking.Type = 'k';
            blackking.Team = 'b';
            blackking.Image = "/Resources/king_black.png";
            boardState[0][3] = blackking;


            for (int i = 0; i < 8; i++)
            {
                IPiece pawn = new Pawn();
                pawn.Row = 1;
                pawn.Column = i;
                pawn.Type = 'p';
                pawn.Team = 'b';
                pawn.Image = "/Resources/pawn_black.png";
                boardState[1][i] = pawn;
            }

            for (int i = 2; i < 6; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    IPiece piece = new Piece();
                    piece.Row = i;
                    piece.Column = x;
                    piece.Type = 'n';
                    piece.Team = 'n';
                    piece.Image = null;
                    boardState[i][x] = piece;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                IPiece pawn = new Pawn();
                pawn.Row = 0;
                pawn.Column = i;
                pawn.Type = 'p';
                pawn.Team = 'w';
                pawn.Image = "/Resources/pawn_white.png";
                boardState[6][i] = pawn;
            }

            foreach (var row in boardState)
            {
                foreach (var col in row.Value)
                {
                    int rowIdx = row.Key;
                    int colIdx = col.Key;
                    IPiece piece = col.Value;

                    // Do something with the piece
                    Console.WriteLine($"Piece at ({rowIdx}, {colIdx}): {piece.Type}");
                }
            }
            InitializeComponent();
        }

        private SolidColorBrush ToggleColor(SolidColorBrush color)
        {
            var color2 = Brushes.DarkBlue;
            if (color == Brushes.DarkGray)
            {
                color2 = Brushes.LightGreen;
            }
            else
            {
                color2 = Brushes.DarkGray;
            }
            return color2;

        }
        private void ReColorBoard()
        {
            var color = Brushes.Red;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var square = FindName("Button" + (j) + i) as Button;
                    if (j == 0 && i > 0) { color = ToggleColor(ToggleColor(color)); }
                    else { color = ToggleColor(color); }

                    var newPiece = FindName("Button" + j + i) as Button;
                    Image image = new Image();
                    if (boardState[j][i].Image != null)
                    {
                        image.Source = new BitmapImage(new Uri(boardState[j][i].Image, UriKind.Relative));
                        image.Stretch = Stretch.Fill;
                        image.Margin = new Thickness(0, 0, -2, -2);
                        newPiece.Content = image;
                    }
                    else {
                        newPiece.Content = null;
                    }

                    if (square != null)
                    {
                        square.Background = color;
                    }
                }
            }
        }

        public void Test() {
            boardState[3][3].Image = "/Resources/pawn_black.png";
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            if (!highlighted)
            {
                Console.WriteLine(boardState);
                //Should be the Bishop
                Console.WriteLine(boardState[0][2].getInfo());

                //Should be the Queen
                Console.WriteLine(boardState[7][3].getInfo());

                ReColorBoard();
                Console.WriteLine(test);
                Console.WriteLine("Button clicked: Row = {0}, Column = {1}", row, column);
                try
                {
                    Console.WriteLine("Clicked on Piece of Type{0}", boardState[row][column]);
                }
                catch {
                    Console.WriteLine("Did not exist at: Row = {0}, Column = {1}", row, column);
                }
                selectedX = row;
                selectedY = column;
                selectedPiece.Column = boardState[row][column].Column;

                switch (boardState[row][column].Type)
                {
                    case 'p':
                        var teamMultiplier = 1;
                        if (boardState[row][column].Team == 'w')
                        {
                            teamMultiplier = -1;
                        }
                        var square = FindName("Button" + (row + (1 * teamMultiplier)) + column) as Button;
                        if (square != null)
                        {
                            square.Background = Brushes.Yellow;
                        }
                        square = FindName("Button" + (row + (2 * teamMultiplier)) + column) as Button;
                        if (square != null)
                        {
                            square.Background = Brushes.Yellow;
                        }
                        highlighted = true;
                        break;

                    case 'b':
                        
                        for(int i = 0; i < 7; i++) { 
                            var bishopSquare = FindName("Button" + (row + i) + (column+i)) as Button;
                            if (bishopSquare != null)
                            {
                                bishopSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var bishopSquare = FindName("Button" + (row - i) + (column + i)) as Button;
                            if (bishopSquare != null)
                            {
                                bishopSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var bishopSquare = FindName("Button" + (row + i) + (column - i)) as Button;
                            if (bishopSquare != null)
                            {
                                bishopSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var bishopSquare = FindName("Button" + (row - i) + (column - i)) as Button;
                            if (bishopSquare != null)
                            {
                                bishopSquare.Background = Brushes.Yellow;
                            }
                        }

                        highlighted = true;
                        break;
                    case 'r':

                        for (int i = 0; i < 7; i++)
                        {
                            var rookSquare = FindName("Button" + (row + i) + (column)) as Button;
                            if (rookSquare != null)
                            {
                                rookSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var rookSquare = FindName("Button" + (row - i) + (column)) as Button;
                            if (rookSquare != null)
                            {
                                rookSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var rookSquare = FindName("Button" + (row) + (column - i)) as Button;
                            if (rookSquare != null)
                            {
                                rookSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var rookSquare = FindName("Button" + (row) + (column + i)) as Button;
                            if (rookSquare != null)
                            {
                                rookSquare.Background = Brushes.Yellow;
                            }
                        }

                        highlighted = true;
                        break;
                    case 'k':


                        var knightSquare = FindName("Button" + (row + 2) + (column+1)) as Button;
                        if (knightSquare != null)
                        {
                            knightSquare.Background = Brushes.Yellow;
                        }

                        knightSquare = FindName("Button" + (row + 2) + (column-1)) as Button;
                        if (knightSquare != null)
                        {
                            knightSquare.Background = Brushes.Yellow;
                        }

                        knightSquare = FindName("Button" + (row + 1) + (column - 2)) as Button;
                        if (knightSquare != null)
                        {
                            knightSquare.Background = Brushes.Yellow;
                        }

                        knightSquare = FindName("Button" + (row + 1) + (column + 2)) as Button;
                        if (knightSquare != null)
                        {
                            knightSquare.Background = Brushes.Yellow;
                        }
                         knightSquare = FindName("Button" + (row - 2) + (column + 1)) as Button;
                        if (knightSquare != null)
                        {
                            knightSquare.Background = Brushes.Yellow;
                        }

                        knightSquare = FindName("Button" + (row - 2) + (column - 1)) as Button;
                        if (knightSquare != null)
                        {
                            knightSquare.Background = Brushes.Yellow;
                        }

                        knightSquare = FindName("Button" + (row - 1) + (column - 2)) as Button;
                        if (knightSquare != null)
                        {
                            knightSquare.Background = Brushes.Yellow;
                        }

                        knightSquare = FindName("Button" + (row - 1) + (column + 2)) as Button;
                        if (knightSquare != null)
                        {
                            knightSquare.Background = Brushes.Yellow;
                        }

                        highlighted = true;
                        break;

                    case 'q':

                        for (int i = 0; i < 7; i++)
                        {
                            var queenSquare = FindName("Button" + (row + i) + (column)) as Button;
                            if (queenSquare != null)
                            {
                                queenSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var queenSquare = FindName("Button" + (row - i) + (column)) as Button;
                            if (queenSquare != null)
                            {
                                queenSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var queenSquare = FindName("Button" + (row) + (column - i)) as Button;
                            if (queenSquare != null)
                            {
                                queenSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var queenSquare = FindName("Button" + (row) + (column + i)) as Button;
                            if (queenSquare != null)
                            {
                                queenSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var queenSquare = FindName("Button" + (row + i) + (column + i)) as Button;
                            if (queenSquare != null)
                            {
                                queenSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var queenSquare = FindName("Button" + (row - i) + (column + i)) as Button;
                            if (queenSquare != null)
                            {
                                queenSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var queenSquare = FindName("Button" + (row + i) + (column - i)) as Button;
                            if (queenSquare != null)
                            {
                                queenSquare.Background = Brushes.Yellow;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            var queenSquare = FindName("Button" + (row - i) + (column - i)) as Button;
                            if (queenSquare != null)
                            {
                                queenSquare.Background = Brushes.Yellow;
                            }
                        }
                        highlighted = true;
                        break;
                    default:
                        break;
                }

            }

            else {
                //PossibleMovement: So we're highlighted now. If the player clicks either a different on of their pieces, or a highlighted color
                /*They should get to move
                 * 
                 */


                var square = FindName("Button" + (row) + column) as Button;
                if(square != null) {
                    if (square.Background == Brushes.Yellow) {
                        //ACTUAL MOVEMENT
                        //selectedPiece.setToBlank();
                        Console.WriteLine(boardState[row][column].getInfo());
                        Console.WriteLine(boardState[selectedPiece.Row][selectedPiece.Column].getInfo());
                        IPiece tempPiece = new Piece();
                        tempPiece = boardState[row][column];
                        //This is what is moving it.
                        boardState[row][column] = boardState[selectedX][selectedY];
                        boardState[selectedX][selectedY] = tempPiece;
                        ReColorBoard();
                    }
                }
                highlighted = false;
                ReColorBoard();
            }

            //        Button button = sender as Button;
            //        Image image = button.Content as Image;
            //        if(image != null ) { 
            //        Console.WriteLine(image.Source);
            //        }
            //        var cell = chessGrid.Children
            //.Cast<UIElement>()
            //.FirstOrDefault(e => chessGrid.GetRow(e) == 1 && Grid.GetColumn(1) == 1) as Border;

            //        // Set the background color of the cell to blue

            //            cell.Background = new SolidColorBrush(Colors.Blue);
            //        Console.WriteLine(cell.Background);



            //// Get the child element at the specified row and column
            ////UIElement element = chessGrid.Children[row][column];
            //foreach (UIElement element in chessGrid.Children)
            //{
            //    // Do something with the element
            //    Console.WriteLine(element);
            //}
            //Console.WriteLine(chessGrid.Children);

            // If the child element is an Image, cast it and store it in the 'image' variable
            //if (element is Image)
            //{
            //    image = (Image)element;
            //}

            //// Do something with the 'image' variable
            //if (image != null)
            //{
            //    Console.WriteLine("Found image at Row={0}, Column={1}, Source={2}", row, column, image.Source);
            //}
            //else
            //{
            //    Console.WriteLine("No image found at Row={0}, Column={1}", row, column);
            //}

        }

    }
}
