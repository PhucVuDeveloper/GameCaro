using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame.PvC
{
    public partial class frmPvC : Form
    {
        #region Properties
        public static int CHESS_BOARD_WIDTH;
        public static int CHESS_BOARD_HEIGHT;
        private Graphics grp;
        private ControlChessBoardCaro conTrol;
        #endregion

        #region Methods
        public frmPvC()
        {
            InitializeComponent();

            //vẽ nên pnlBanCo
            grp = pnlChessBoard.CreateGraphics();

            //lấy chiều rộng và chiều cao pnBanCo để vẽ bàn cờ
            CHESS_BOARD_HEIGHT = pnlChessBoard.Height;
            CHESS_BOARD_WIDTH = pnlChessBoard.Width;

            //khởi tạo đối tượng điều khiển trò chơi
            conTrol = new ControlChessBoardCaro();

        }

        private void pnlChessBoard_Paint(object sender, PaintEventArgs e)
        {
            if (conTrol.Ready)
            {
                //vẽ bàn cờ
                conTrol.drawChessBoard(grp);
                //vẽ lại các quân cờ trong stack
                conTrol.drawChessAgain(grp);
            }
        }
        private void pnlChessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (conTrol.Ready)
            {
                //chơi với người
                if (conTrol.Gamemode == 1)
                {
                    //đánh cờ với tọa độ chuột khi lick vào panel bàn cờ
                    conTrol.playChess(grp, e.Location.X, e.Location.Y);
                    //sau khi đánh cờ thì kiểm tra chiến thắng luôn
                    conTrol.checkWin(grp);
                }
                //chơi với máy
                else
                {
                    //người chơi đánh
                    conTrol.playChess(grp, e.Location.X, e.Location.Y);
                    //kiểm tra người chơi chưa chiến thắng thì cho máy đánh
                    if (!conTrol.checkWin(grp))
                    {
                        //máy đánh
                        conTrol.Computer(grp);
                        conTrol.checkWin(grp);
                    }
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            conTrol.playWithComputer(grp);

            grp.Clear(pnlChessBoard.BackColor);
            Image image = new Bitmap(Properties.Resources.background);
            pnlChessBoard.BackgroundImage = image;
            //xóa tất cả các hình đã vẽ trên panel chỉ giữ lại màu nền panel
            btnStartPvE.Text = "New Game";
        }
        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            frmMenu meNu = new frmMenu();
            this.Hide();
            meNu.ShowDialog();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                Application.Exit();
        }
        #endregion
    }
}
