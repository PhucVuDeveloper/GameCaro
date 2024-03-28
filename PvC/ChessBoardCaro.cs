using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame.PvC
{
    public class ChessBoardCaro
    {
        #region Properties
        private int soDong;
        public int SoDong { get => soDong; set => soDong = value; }

        private int soCot;
        public int SoCot { get => soCot; set => soCot = value; }

        #endregion

        #region Initialize
        public ChessBoardCaro()
        {
            SoCot = 0;
            SoDong = 0;
        }
        public ChessBoardCaro(int SoDong, int SoCot)
        {
            soCot = SoCot;
            soDong = SoDong;
        }
        #endregion

        #region Methods
        //khai báo 2 ảnh để vẽ ảnh lên bàn cờ
        Image ImageO = new Bitmap(Properties.Resources.o);
        Image ImageX = new Bitmap(Properties.Resources.x);

        //vẽ bàn cờ
        public void DrawChessBoard(Graphics g)
        {
            //vẽ cột
            for (int i = 0; i <= SoCot; i++)
            {
                g.DrawLine(ControlChessBoardCaro.pen, i * ChessSquareCaro.CHESSBOARD_WIDTH, 0, i * ChessSquareCaro.CHESSBOARD_WIDTH, SoDong * ChessSquareCaro.CHESSBOARD_HEIGHT);
            }
            //vẽ dòng
            for (int i = 0; i <= SoDong; i++)
            {
                g.DrawLine(ControlChessBoardCaro.pen, 0, i * ChessSquareCaro.CHESSBOARD_HEIGHT, SoCot * ChessSquareCaro.CHESSBOARD_WIDTH, i * ChessSquareCaro.CHESSBOARD_HEIGHT);
            }
        }

        //vẽ quân cờ
        public void DrawChess(Graphics g, int X, int Y, int SoHuu)
        {
            if (SoHuu == 1)
            {
                g.DrawImage(ImageO, X, Y);

            }
            else
            {
                g.DrawImage(ImageX, X + 2, Y + 2);
            }
        }

        #endregion
    }
}
