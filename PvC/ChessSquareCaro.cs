using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame.PvC
{
    public class ChessSquareCaro
    {
        #region Properties
        private int roW; //dòng
        public int Row { get => roW; set => roW = value; }

        private int columN; //cột
        public int Column { get => columN; set => columN = value; }

        private int soHuu; //sở hữu
        public int SoHuu { get => soHuu; set => soHuu = value; }

        #endregion

        #region Initialize
        public ChessSquareCaro(int Row, int Column, int SoHuu)
        {
            this.Row = Row;
            this.Column = Column;
            this.SoHuu = SoHuu;
        }
        public ChessSquareCaro()
        {

        }

        #endregion

        #region Methods
        public const int CHESSBOARD_HEIGHT = 30;
        public const int CHESSBOARD_WIDTH = 30;

        #endregion
    }
}
