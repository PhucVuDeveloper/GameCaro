using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame.PvC
{
    public class ControlChessBoardCaro
    {
        #region Properties
        private Random ranDom = new Random();//random ô cờ máy sẽ đánh đầu tiên, và random lượt đi đầu tiên
        private ChessBoardCaro ChessBoard;
        private ChessSquareCaro[,] arrChessSquare;
        private int chessBoardTurn;
        private bool reaDy;
        private int gameMode;

        public bool Ready { get => reaDy; set => reaDy = value; }
        public int Gamemode { get => gameMode; set => gameMode = value; }
        private Stack<ChessSquareCaro> stkCacNuocDaDi;
        #endregion

        #region Methods
        //3 loại bút vẽ
        public static Pen pen;
        public static SolidBrush sbBlack;
        public static SolidBrush sbWhite;

        public ControlChessBoardCaro()
        {
            //khởi tạo bàn cờ với số dòng , số cột 
            ChessBoard = new ChessBoardCaro(frmPvC.CHESS_BOARD_HEIGHT / ChessSquareCaro.CHESSBOARD_HEIGHT, frmPvC.CHESS_BOARD_WIDTH / ChessSquareCaro.CHESSBOARD_WIDTH);
            //khởi tạo 3 loại bút vẽ
            pen = new Pen(Color.DarkKhaki, 1);
            sbBlack = new SolidBrush(Color.Black);
            sbWhite = new SolidBrush(Color.White);

            reaDy = false;
            //khai báo mảng các ô cờ 
            arrChessSquare = new ChessSquareCaro[ChessBoard.SoDong, ChessBoard.SoCot];
        }
        //vẽ bàn cờ
        public void drawChessBoard(Graphics g)
        {
            ChessBoard.DrawChessBoard(g);
        }

        //khởi tạo mảng ô cờ
        public void initializeArayChessSquare()
        {
            for (int i = 0; i < ChessBoard.SoDong; i++)
                for (int j = 0; j < ChessBoard.SoCot; j++)
                {
                    arrChessSquare[i, j] = new ChessSquareCaro(i, j, 0);
                }
        }

        // đánh cờ
        public void playChess(Graphics g, int mouseX, int mouseY)
        {
            int dongRow = mouseY / ChessSquareCaro.CHESSBOARD_HEIGHT;
            int cotColumn = mouseX / ChessSquareCaro.CHESSBOARD_WIDTH;

            //loại bỏ trường hợp người chơi kích vào giữa đường kẻ vạch
            if (mouseY % ChessSquareCaro.CHESSBOARD_HEIGHT != 0 && mouseX % ChessSquareCaro.CHESSBOARD_WIDTH != 0)
            {
                //chỉ đánh vào những ô trống
                if (arrChessSquare[dongRow, cotColumn].SoHuu == 0)
                {
                    //quân đen đánh
                    if (chessBoardTurn == 1)
                    {
                        ChessBoard.DrawChess(g, cotColumn * ChessSquareCaro.CHESSBOARD_HEIGHT, dongRow * ChessSquareCaro.CHESSBOARD_WIDTH, chessBoardTurn);
                        arrChessSquare[dongRow, cotColumn].SoHuu = 1;

                        //sao chép o cờ ra một vùng nhớ mới để đẩy vào stack
                        ChessSquareCaro chessSquare = new ChessSquareCaro(arrChessSquare[dongRow, cotColumn].Row, arrChessSquare[dongRow, cotColumn].Column, arrChessSquare[dongRow, cotColumn].SoHuu);
                        //sau khi đánh xong thì đẩy o cờ vào trong stack
                        stkCacNuocDaDi.Push(chessSquare);

                        chessBoardTurn = 2;
                    }
                    //quân trắng đánh
                    else
                    {
                        ChessBoard.DrawChess(g, cotColumn * ChessSquareCaro.CHESSBOARD_HEIGHT, dongRow * ChessSquareCaro.CHESSBOARD_WIDTH, chessBoardTurn);
                        arrChessSquare[dongRow, cotColumn].SoHuu = 2;

                        //sao chép o cờ ra một vùng nhớ mới để đẩy vào stack
                        ChessSquareCaro chessSquare = new ChessSquareCaro(arrChessSquare[dongRow, cotColumn].Row, arrChessSquare[dongRow, cotColumn].Column, arrChessSquare[dongRow, cotColumn].SoHuu);
                        //sau khi đánh xong thì đẩy o cờ vào trong stack
                        stkCacNuocDaDi.Push(chessSquare);

                        chessBoardTurn = 1;
                    }
                }
            }
        }

        //vẽ lại quân cờ
        public void drawChessAgain(Graphics g)
        {
            //trong stack có quân cờ thì thực hiện vẽ lại quân cờ
            if (stkCacNuocDaDi.Count != 0)
            {
                foreach (ChessSquareCaro oco in stkCacNuocDaDi)
                {
                    ChessBoard.DrawChess(g, oco.Column * ChessSquareCaro.CHESSBOARD_WIDTH, oco.Row * ChessSquareCaro.CHESSBOARD_HEIGHT, oco.SoHuu);
                }
            }
        }

        //chơi với máy
        public void playWithComputer(Graphics g)
        {
            //chơi với máy
            gameMode = 2;
            //random lượt đi
            chessBoardTurn = ranDom.Next(0, 2);
            if (chessBoardTurn == 1)
            {
                MessageBox.Show("Máy đi trước");
            }
            else MessageBox.Show("Người chơi đi trước");

            reaDy = true;
            initializeArayChessSquare();
            stkCacNuocDaDi = new Stack<ChessSquareCaro>();
            drawChessBoard(g);
            Computer(g);
        }

        //máy đánh
        public void Computer(Graphics g)
        {
            int DiemMax = 0;
            int DiemPhongNgu = 0;
            int DiemTanCong = 0;
            ChessSquareCaro chessSquare = new ChessSquareCaro();

            if (chessBoardTurn == 1)
            {
                //lượt đi đầu tiên sẽ đánh random trong khoảng chính giữa đến 3 nước trên bàn cờ
                if (stkCacNuocDaDi.Count == 0)
                {
                    playChess(g, ranDom.Next((ChessBoard.SoCot / 2 - 3) * ChessSquareCaro.CHESSBOARD_WIDTH + 1, (ChessBoard.SoCot / 2 + 3) * ChessSquareCaro.CHESSBOARD_WIDTH + 1), ranDom.Next((ChessBoard.SoDong / 2 - 3) * ChessSquareCaro.CHESSBOARD_HEIGHT, (ChessBoard.SoDong / 2 + 3) * ChessSquareCaro.CHESSBOARD_HEIGHT));
                }
                else
                {
                    //thuật toán minmax tìm điểm cao nhất để đánh
                    for (int i = 0; i < ChessBoard.SoDong; i++)
                    {
                        for (int j = 0; j < ChessBoard.SoCot; j++)
                        {
                            //nếu nước cờ chưa có ai đánh và không bị cắt tỉa thì mới xét giá trị MinMax
                            if (arrChessSquare[i, j].SoHuu == 0 && !catTia(arrChessSquare[i, j]))
                            {
                                int DiemTam;

                                DiemTanCong = duyetTC_Ngang(i, j) + duyetTC_Doc(i, j) + duyetTC_CheoXuoi(i, j) + duyetTC_CheoNguoc(i, j);
                                DiemPhongNgu = duyetPN_Ngang(i, j) + duyetPN_Doc(i, j) + duyetPN_CheoXuoi(i, j) + duyetPN_CheoNguoc(i, j);

                                if (DiemPhongNgu > DiemTanCong)
                                {
                                    DiemTam = DiemPhongNgu;
                                }
                                else
                                {
                                    DiemTam = DiemTanCong;
                                }

                                if (DiemMax < DiemTam)
                                {
                                    DiemMax = DiemTam;
                                    chessSquare = new ChessSquareCaro(arrChessSquare[i, j].Row, arrChessSquare[i, j].Column, arrChessSquare[i, j].SoHuu);
                                }
                            }
                        }
                    }

                    playChess(g, chessSquare.Column * ChessSquareCaro.CHESSBOARD_WIDTH + 1, chessSquare.Row * ChessSquareCaro.CHESSBOARD_HEIGHT + 1);

                }
            }
        }

        #endregion

        #region Cắt tỉa Alpha Beta
        bool catTia(ChessSquareCaro chessSquare)
        {
            //nếu cả 4 hướng đều không có nước cờ thì cắt tỉa
            if (catTiaNgang(chessSquare) && catTiaDoc(chessSquare) && catTiaCheoPhai(chessSquare) && catTiaCheoTrai(chessSquare))
                return true;

            //chạy đến đây thì 1 trong 4 hướng vẫn có nước cờ thì không được cắt tỉa
            return false;
        }

        bool catTiaNgang(ChessSquareCaro chessSquare)
        {
            //duyệt bên phải
            if (chessSquare.Column <= ChessBoard.SoCot - 5)
                for (int i = 1; i <= 4; i++)
                    if (arrChessSquare[chessSquare.Row, chessSquare.Column + i].SoHuu != 0)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //duyệt bên trái
            if (chessSquare.Column >= 4)
                for (int i = 1; i <= 4; i++)
                    if (arrChessSquare[chessSquare.Row, chessSquare.Column - i].SoHuu != 0)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }
        bool catTiaDoc(ChessSquareCaro chessSquare)
        {
            //duyệt phía giưới
            if (chessSquare.Row <= ChessBoard.SoDong - 5)
                for (int i = 1; i <= 4; i++)
                    if (arrChessSquare[chessSquare.Row + i, chessSquare.Column].SoHuu != 0)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //duyệt phía trên
            if (chessSquare.Row >= 4)
                for (int i = 1; i <= 4; i++)
                    if (arrChessSquare[chessSquare.Row - i, chessSquare.Column].SoHuu != 0)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }
        bool catTiaCheoPhai(ChessSquareCaro chessSquare)
        {
            //duyệt từ trên xuống
            if (chessSquare.Row <= ChessBoard.SoDong - 5 && chessSquare.Column >= 4)
                for (int i = 1; i <= 4; i++)
                    if (arrChessSquare[chessSquare.Row + i, chessSquare.Column - i].SoHuu != 0)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //duyệt từ giưới lên
            if (chessSquare.Column <= ChessBoard.SoCot - 5 && chessSquare.Row >= 4)
                for (int i = 1; i <= 4; i++)
                    if (arrChessSquare[chessSquare.Row - i, chessSquare.Column + i].SoHuu != 0)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }
        bool catTiaCheoTrai(ChessSquareCaro chessSquare)
        {
            //duyệt từ trên xuống
            if (chessSquare.Row <= ChessBoard.SoDong - 5 && chessSquare.Column <= ChessBoard.SoCot - 5)
                for (int i = 1; i <= 4; i++)
                    if (arrChessSquare[chessSquare.Row + i, chessSquare.Column + i].SoHuu != 0)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //duyệt từ giưới lên
            if (chessSquare.Column >= 4 && chessSquare.Row >= 4)
                for (int i = 1; i <= 4; i++)
                    if (arrChessSquare[chessSquare.Row - i, chessSquare.Column - i].SoHuu != 0)//nếu có nước cờ thì không cắt tỉa
                        return false;

            //nếu chạy đến đây tức duyệt 2 bên đều không có nước đánh thì cắt tỉa
            return true;
        }

        #endregion

        #region AI

        private int[] MangDiemTanCong = new int[7] { 0, 4, 25, 246, 7300, 6561, 59049 };
        private int[] MangDiemPhongNgu = new int[7] { 0, 3, 24, 243, 2197, 19773, 177957 };

        #region Tấn công
        //duyệt ngang
        public int duyetTC_Ngang(int dongHT, int cotHT)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichPhai = 0;
            int SoQuanDichTrai = 0;
            int KhoangChong = 0;

            //bên phải
            for (int dem = 1; dem <= 4 && cotHT < ChessBoard.SoCot - 5; dem++)
            {

                if (arrChessSquare[dongHT, cotHT + dem].SoHuu == 1)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;
                }
                else
                    if (arrChessSquare[dongHT, cotHT + dem].SoHuu == 2)
                {
                    SoQuanDichPhai++;
                    break;
                }
                else KhoangChong++;
            }
            //bên trái
            for (int dem = 1; dem <= 4 && cotHT > 4; dem++)
            {
                if (arrChessSquare[dongHT, cotHT - dem].SoHuu == 1)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (arrChessSquare[dongHT, cotHT - dem].SoHuu == 2)
                {
                    SoQuanDichTrai++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichPhai > 0 && SoQuanDichTrai > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichPhai + SoQuanDichTrai];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        //duyệt dọc
        public int duyetTC_Doc(int dongHT, int cotHT)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichTren = 0;
            int SoQuanDichDuoi = 0;
            int KhoangChong = 0;

            //bên trên
            for (int dem = 1; dem <= 4 && dongHT > 4; dem++)
            {
                if (arrChessSquare[dongHT - dem, cotHT].SoHuu == 1)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (arrChessSquare[dongHT - dem, cotHT].SoHuu == 2)
                {
                    SoQuanDichTren++;
                    break;
                }
                else KhoangChong++;
            }
            //bên dưới
            for (int dem = 1; dem <= 4 && dongHT < ChessBoard.SoDong - 5; dem++)
            {
                if (arrChessSquare[dongHT + dem, cotHT].SoHuu == 1)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (arrChessSquare[dongHT + dem, cotHT].SoHuu == 2)
                {
                    SoQuanDichDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichTren > 0 && SoQuanDichDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichTren + SoQuanDichDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        //chéo xuôi
        public int duyetTC_CheoXuoi(int dongHT, int cotHT)
        {
            int DiemTanCong = 1;
            int SoQuanTa = 0;
            int SoQuanDichCheoTren = 0;
            int SoQuanDichCheoDuoi = 0;
            int KhoangChong = 0;

            //bên chéo xuôi xuống
            for (int dem = 1; dem <= 4 && cotHT < ChessBoard.SoCot - 5 && dongHT < ChessBoard.SoDong - 5; dem++)
            {
                if (arrChessSquare[dongHT + dem, cotHT + dem].SoHuu == 1)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (arrChessSquare[dongHT + dem, cotHT + dem].SoHuu == 2)
                {
                    SoQuanDichCheoTren++;
                    break;
                }
                else KhoangChong++;
            }
            //chéo xuôi lên
            for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT > 4; dem++)
            {
                if (arrChessSquare[dongHT - dem, cotHT - dem].SoHuu == 1)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (arrChessSquare[dongHT - dem, cotHT - dem].SoHuu == 2)
                {
                    SoQuanDichCheoDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }

        //chéo ngược
        public int duyetTC_CheoNguoc(int dongHT, int cotHT)
        {
            int DiemTanCong = 0;
            int SoQuanTa = 0;
            int SoQuanDichCheoTren = 0;
            int SoQuanDichCheoDuoi = 0;
            int KhoangChong = 0;

            //chéo ngược lên
            for (int dem = 1; dem <= 4 && cotHT < ChessBoard.SoCot - 5 && dongHT > 4; dem++)
            {
                if (arrChessSquare[dongHT - dem, cotHT + dem].SoHuu == 1)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (arrChessSquare[dongHT - dem, cotHT + dem].SoHuu == 2)
                {
                    SoQuanDichCheoTren++;
                    break;
                }
                else KhoangChong++;
            }
            //chéo ngược xuống
            for (int dem = 1; dem <= 4 && cotHT > 4 && dongHT < ChessBoard.SoDong - 5; dem++)
            {
                if (arrChessSquare[dongHT + dem, cotHT - dem].SoHuu == 1)
                {
                    if (dem == 1)
                        DiemTanCong += 37;

                    SoQuanTa++;
                    KhoangChong++;

                }
                else
                    if (arrChessSquare[dongHT + dem, cotHT - dem].SoHuu == 2)
                {
                    SoQuanDichCheoDuoi++;
                    break;
                }
                else KhoangChong++;
            }
            //bị chặn 2 đầu khoảng chống không đủ tạo thành 5 nước
            if (SoQuanDichCheoTren > 0 && SoQuanDichCheoDuoi > 0 && KhoangChong < 4)
                return 0;

            DiemTanCong -= MangDiemPhongNgu[SoQuanDichCheoTren + SoQuanDichCheoDuoi];
            DiemTanCong += MangDiemTanCong[SoQuanTa];
            return DiemTanCong;
        }
        #endregion

        #region phòng ngự

        //duyệt ngang
        public int duyetPN_Ngang(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongPhai = 0;
            int KhoangChongTrai = 0;
            bool ok = false;


            for (int dem = 1; dem <= 4 && cotHT < ChessBoard.SoCot - 5; dem++)
            {
                if (arrChessSquare[dongHT, cotHT + dem].SoHuu == 2)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (arrChessSquare[dongHT, cotHT + dem].SoHuu == 1)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongPhai++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongPhai == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;

            for (int dem = 1; dem <= 4 && cotHT > 4; dem++)
            {
                if (arrChessSquare[dongHT, cotHT - dem].SoHuu == 2)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (arrChessSquare[dongHT, cotHT - dem].SoHuu == 1)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTrai++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTrai == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTrai + KhoangChongPhai + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }

        //duyệt dọc
        public int duyetPN_Doc(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && dongHT > 4; dem++)
            {
                if (arrChessSquare[dongHT - dem, cotHT].SoHuu == 2)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;

                }
                else
                    if (arrChessSquare[dongHT - dem, cotHT].SoHuu == 1)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;
            //xuống
            for (int dem = 1; dem <= 4 && dongHT < ChessBoard.SoDong - 5; dem++)
            {
                //gặp quân địch
                if (arrChessSquare[dongHT + dem, cotHT].SoHuu == 2)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (arrChessSquare[dongHT + dem, cotHT].SoHuu == 1)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];
            return DiemPhongNgu;
        }

        //chéo xuôi
        public int duyetPN_CheoXuoi(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && dongHT < ChessBoard.SoDong - 5 && cotHT < ChessBoard.SoCot - 5; dem++)
            {
                if (arrChessSquare[dongHT + dem, cotHT + dem].SoHuu == 2)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (arrChessSquare[dongHT + dem, cotHT + dem].SoHuu == 1)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;
            //xuống
            for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT > 4; dem++)
            {
                if (arrChessSquare[dongHT - dem, cotHT - dem].SoHuu == 2)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (arrChessSquare[dongHT - dem, cotHT - dem].SoHuu == 1)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaPhai + SoQuanTaTrai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }

        //chéo ngược
        public int duyetPN_CheoNguoc(int dongHT, int cotHT)
        {
            int DiemPhongNgu = 0;
            int SoQuanTaTrai = 0;
            int SoQuanTaPhai = 0;
            int SoQuanDich = 0;
            int KhoangChongTren = 0;
            int KhoangChongDuoi = 0;
            bool ok = false;

            //lên
            for (int dem = 1; dem <= 4 && dongHT > 4 && cotHT < ChessBoard.SoCot - 5; dem++)
            {

                if (arrChessSquare[dongHT - dem, cotHT + dem].SoHuu == 2)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (arrChessSquare[dongHT - dem, cotHT + dem].SoHuu == 1)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaPhai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongTren++;
                }
            }


            if (SoQuanDich == 3 && KhoangChongTren == 1 && ok)
                DiemPhongNgu -= 200;

            ok = false;

            //xuống
            for (int dem = 1; dem <= 4 && dongHT < ChessBoard.SoDong - 5 && cotHT > 4; dem++)
            {
                if (arrChessSquare[dongHT + dem, cotHT - dem].SoHuu == 2)
                {
                    if (dem == 1)
                        DiemPhongNgu += 9;

                    SoQuanDich++;
                }
                else
                    if (arrChessSquare[dongHT + dem, cotHT - dem].SoHuu == 1)
                {
                    if (dem == 4)
                        DiemPhongNgu -= 170;

                    SoQuanTaTrai++;
                    break;
                }
                else
                {
                    if (dem == 1)
                        ok = true;

                    KhoangChongDuoi++;
                }
            }

            if (SoQuanDich == 3 && KhoangChongDuoi == 1 && ok)
                DiemPhongNgu -= 200;

            if (SoQuanTaPhai > 0 && SoQuanTaTrai > 0 && (KhoangChongTren + KhoangChongDuoi + SoQuanDich) < 4)
                return 0;

            DiemPhongNgu -= MangDiemTanCong[SoQuanTaTrai + SoQuanTaPhai];
            DiemPhongNgu += MangDiemPhongNgu[SoQuanDich];

            return DiemPhongNgu;
        }

        #endregion





        #endregion

        #region duyệt chiến thắng theo 8 hướng
        //kiểm tra chiến thắng
        public bool checkWin(Graphics g)
        {
            if (stkCacNuocDaDi.Count != 0)
            {
                foreach (ChessSquareCaro chessSquare in stkCacNuocDaDi)
                {
                    //duyệt theo 8 hướng mỗi quân cờ
                    if (duyetNgangPhai(g, chessSquare.Row, chessSquare.Column, chessSquare.SoHuu) || duyetNgangTrai(g, chessSquare.Row, chessSquare.Column, chessSquare.SoHuu)
                        || duyetDocTren(g, chessSquare.Row, chessSquare.Column, chessSquare.SoHuu) || duyetDocDuoi(g, chessSquare.Row, chessSquare.Column, chessSquare.SoHuu)
                        || duyetCheoXuoiTren(g, chessSquare.Row, chessSquare.Column, chessSquare.SoHuu) || duyetCheoXuoiDuoi(g, chessSquare.Row, chessSquare.Column, chessSquare.SoHuu)
                        || duyetCheoNguocTren(g, chessSquare.Row, chessSquare.Column, chessSquare.SoHuu) || duyetCheoNguocDuoi(g, chessSquare.Row, chessSquare.Column, chessSquare.SoHuu))
                    {
                        endGame(chessSquare);
                        return true;
                    }
                }
            }

            return false;
        }

        //vẽ đường kẻ trên 5 nước thắng
        public void drawWinLine(Graphics g, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(new Pen(Color.Blue, 3f), x1, y1, x2, y2);
        }

        public bool duyetNgangPhai(Graphics g, int dongHT, int cotHT, int SoHuu)
        {
            if (cotHT > ChessBoard.SoCot - 5)
                return false;
            for (int dem = 1; dem <= 4; dem++)
            {
                if (arrChessSquare[dongHT, cotHT + dem].SoHuu != SoHuu)
                {
                    return false;
                }

            }
            drawWinLine(g, (cotHT) * ChessSquareCaro.CHESSBOARD_WIDTH, dongHT * ChessSquareCaro.CHESSBOARD_HEIGHT + ChessSquareCaro.CHESSBOARD_HEIGHT / 2, (cotHT + 5) * ChessSquareCaro.CHESSBOARD_WIDTH, dongHT * ChessSquareCaro.CHESSBOARD_HEIGHT + ChessSquareCaro.CHESSBOARD_HEIGHT / 2);
            return true;
        }

        public bool duyetNgangTrai(Graphics g, int dongHT, int cotHT, int SoHuu)
        {
            if (cotHT < 4)
                return false;
            for (int dem = 1; dem <= 4; dem++)
            {
                if (arrChessSquare[dongHT, cotHT - dem].SoHuu != SoHuu)
                {
                    return false;
                }

            }
            drawWinLine(g, (cotHT + 1) * ChessSquareCaro.CHESSBOARD_WIDTH, dongHT * ChessSquareCaro.CHESSBOARD_HEIGHT + ChessSquareCaro.CHESSBOARD_HEIGHT / 2, (cotHT - 4) * ChessSquareCaro.CHESSBOARD_WIDTH, dongHT * ChessSquareCaro.CHESSBOARD_HEIGHT + ChessSquareCaro.CHESSBOARD_HEIGHT / 2);
            return true;
        }

        public bool duyetDocTren(Graphics g, int dongHT, int cotHT, int SoHuu)
        {
            if (dongHT < 4)
                return false;
            for (int dem = 1; dem <= 4; dem++)
            {
                if (arrChessSquare[dongHT - dem, cotHT].SoHuu != SoHuu)
                {
                    return false;
                }

            }
            drawWinLine(g, cotHT * ChessSquareCaro.CHESSBOARD_WIDTH + ChessSquareCaro.CHESSBOARD_WIDTH / 2, (dongHT + 1) * ChessSquareCaro.CHESSBOARD_HEIGHT, cotHT * ChessSquareCaro.CHESSBOARD_WIDTH + ChessSquareCaro.CHESSBOARD_WIDTH / 2, (dongHT - 4) * ChessSquareCaro.CHESSBOARD_HEIGHT);
            return true;
        }

        public bool duyetDocDuoi(Graphics g, int dongHT, int cotHT, int SoHuu)
        {
            if (dongHT > ChessBoard.SoDong - 5)
                return false;
            for (int dem = 1; dem <= 4; dem++)
            {
                if (arrChessSquare[dongHT + dem, cotHT].SoHuu != SoHuu)
                {
                    return false;
                }

            }
            drawWinLine(g, cotHT * ChessSquareCaro.CHESSBOARD_WIDTH + ChessSquareCaro.CHESSBOARD_WIDTH / 2, dongHT * ChessSquareCaro.CHESSBOARD_HEIGHT, cotHT * ChessSquareCaro.CHESSBOARD_WIDTH + ChessSquareCaro.CHESSBOARD_WIDTH / 2, (dongHT + 5) * ChessSquareCaro.CHESSBOARD_HEIGHT);
            return true;
        }

        public bool duyetCheoXuoiTren(Graphics g, int dongHT, int cotHT, int SoHuu)
        {
            if (dongHT < 4 || cotHT < 4)
                return false;
            for (int dem = 1; dem <= 4; dem++)
            {
                if (arrChessSquare[dongHT - dem, cotHT - dem].SoHuu != SoHuu)
                {
                    return false;
                }

            }
            drawWinLine(g, (cotHT + 1) * ChessSquareCaro.CHESSBOARD_WIDTH, (dongHT + 1) * ChessSquareCaro.CHESSBOARD_HEIGHT, (cotHT - 4) * ChessSquareCaro.CHESSBOARD_WIDTH, (dongHT - 4) * ChessSquareCaro.CHESSBOARD_HEIGHT);
            return true;
        }

        public bool duyetCheoXuoiDuoi(Graphics g, int dongHT, int cotHT, int SoHuu)
        {
            if (dongHT > ChessBoard.SoDong - 5 || cotHT > ChessBoard.SoCot - 5)
                return false;
            for (int dem = 1; dem <= 4; dem++)
            {
                if (arrChessSquare[dongHT + dem, cotHT + dem].SoHuu != SoHuu)
                {
                    return false;
                }

            }
            drawWinLine(g, cotHT * ChessSquareCaro.CHESSBOARD_WIDTH, dongHT * ChessSquareCaro.CHESSBOARD_HEIGHT, (cotHT + 5) * ChessSquareCaro.CHESSBOARD_WIDTH, (dongHT + 5) * ChessSquareCaro.CHESSBOARD_HEIGHT);
            return true;
        }

        public bool duyetCheoNguocDuoi(Graphics g, int dongHT, int cotHT, int SoHuu)
        {
            if (dongHT > ChessBoard.SoDong - 5 || cotHT < 4)
                return false;
            for (int dem = 1; dem <= 4; dem++)
            {
                if (arrChessSquare[dongHT + dem, cotHT - dem].SoHuu != SoHuu)
                {
                    return false;
                }

            }
            drawWinLine(g, (cotHT + 1) * ChessSquareCaro.CHESSBOARD_WIDTH, dongHT * ChessSquareCaro.CHESSBOARD_HEIGHT, (cotHT - 4) * ChessSquareCaro.CHESSBOARD_WIDTH, (dongHT + 5) * ChessSquareCaro.CHESSBOARD_HEIGHT);
            return true;
        }

        public bool duyetCheoNguocTren(Graphics g, int dongHT, int cotHT, int SoHuu)
        {
            if (dongHT < 4 || cotHT > ChessBoard.SoCot - 5)
                return false;
            for (int dem = 1; dem <= 4; dem++)
            {
                if (arrChessSquare[dongHT - dem, cotHT + dem].SoHuu != SoHuu)
                {
                    return false;
                }

            }
            drawWinLine(g, cotHT * ChessSquareCaro.CHESSBOARD_WIDTH, (dongHT + 1) * ChessSquareCaro.CHESSBOARD_HEIGHT, (cotHT + 5) * ChessSquareCaro.CHESSBOARD_WIDTH, (dongHT - 4) * ChessSquareCaro.CHESSBOARD_HEIGHT);
            return true;
        }

        #endregion

        //thông báo kết thúc trò chơi
        public void endGame(ChessSquareCaro chessSquare)
        {
            //chơi với máy
            if (chessSquare.SoHuu == 1)
                MessageBox.Show("Máy thắng");
            else
                MessageBox.Show("Người chơi thắng");

            reaDy = false;
        }
    }
}
