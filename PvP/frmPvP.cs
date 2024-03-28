using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame.PvP
{

    public partial class frmPvP : Form
    {

        ChessBoardCaro ChessBoard;

        public frmPvP()
        {
            InitializeComponent();

            ChessBoard = new ChessBoardCaro(pnlChessBoard, txtPlayerName, pctbMark, btnUndo);
            txtPlayerName.Enabled = false;
            ChessBoard.DrawChessBoard();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            DialogResult ret = MessageBox.Show("Bạn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                Application.Exit();
        }
        void Undo()
        {
            ChessBoard.Undo();
            
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.Undo();
        }

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            frmMenu meNu = new frmMenu();
            this.Hide();
            meNu.ShowDialog();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            ChessBoard.DrawChessBoard();
        }
    }
}
