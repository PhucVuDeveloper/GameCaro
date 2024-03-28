using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaroGame.PvP;
using CaroGame.PvC;

namespace CaroGame
{
    public partial class frmMenu : Form
    {
        //#region Properties
        //ChessBoardCaro ChessBoard;
        //#endregion
        public frmMenu()
        {
            InitializeComponent();

        }


        private void btnPvP_Click(object sender, EventArgs e)
        {
            frmPvP pvp = new frmPvP();
            this.Hide();
            pvp.ShowDialog();

        }
        private void btnPvE_Click(object sender, EventArgs e)
        {
            frmPvC gamePlay = new frmPvC();
            this.Hide();
            gamePlay.ShowDialog();
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trò chơi gồm hai người, lần lượt mỗi bên đánh dấu (O) và (X). Bên nào đạt được năm dấu chung hàng (có thể là hàng ngang, hàng dọc, hàng chéo) trước thì thắng!", "Hướng dẫn cách chơi", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                Application.Exit();
        }
    }
}
