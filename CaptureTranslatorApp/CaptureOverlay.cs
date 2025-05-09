using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTranslatorApp
{
    public partial class CaptureOverlay: Form
    {
        // 드래그 시작 (사각형 영역, 드래그 여부)
        private Point dragStartPoint;
        private Rectangle captureArea;
        private bool isDragging = false;

        public CaptureOverlay()
        {
            InitializeComponent();

            // 전체 화면을 투명한 배경으로 설정
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.BackColor = Color.Black;
            this.Opacity = 0.3; // 반투명
            this.DoubleBuffered = true;
            this.Cursor = Cursors.Cross; // 십자 모양 커서

            // 드래그를 위한 마우스 이벤트 핸들러 연결
            this.MouseDown += CaptureOverlay_MouseDown;
            this.MouseMove += CaptureOverlay_MouseMove;
            this.MouseUp += CaptureOverlay_MouseUp;

            // ESC 키로 창을 닫는 이벤트 핸들러 연결
            this.KeyDown += CaptureOverlay_KeyDown;
            this.KeyPreview = true; // ESC 키가 폼에 전달되도록 설정
        }

        // ESC 키를 누르면 폼 닫기
        private void CaptureOverlay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        // 마우스를 눌렀을 때 (드래그 시작)
        private void CaptureOverlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragStartPoint = e.Location;
                isDragging = true;
            }
        }

        // 마우스를 이동할 때 (드래그 중 영역을 그리기)
        private void CaptureOverlay_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // 현재 위치를 끝 지점으로 설정하고, 영역을 갱신
                Point endPoint = e.Location;
                captureArea = new Rectangle(
                    Math.Min(dragStartPoint.X, endPoint.X),
                    Math.Min(dragStartPoint.Y, endPoint.Y),
                    Math.Abs(dragStartPoint.X - endPoint.X),
                    Math.Abs(dragStartPoint.Y - endPoint.Y)
                );
                Invalidate(); // 폼을 다시 그려서 영역을 업데이트. 아래 OnPaint()를 실행하기 위함
            }
        }

        // 마우스를 뗐을 때 (드래그 종료)
        private void CaptureOverlay_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // 드래그 종료, 캡처한 영역을 처리 (OCR, 저장 등)
                isDragging = false;
                CaptureSelectedRegion();
            }
        }

        // 선택된 영역을 캡처하여 OCR 처리
        private async void CaptureSelectedRegion()
        {
            this.Hide(); // 먼저 오버레이 숨김 (회색 배경이 캡처되지 않도록)

            // 약간의 딜레이를 줘서 오버레이가 완전히 사라진 뒤 캡처 실행
            await Task.Delay(100);

            Bitmap bmp = new Bitmap(captureArea.Width, captureArea.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(captureArea.Location, Point.Empty, captureArea.Size, CopyPixelOperation.SourceCopy);
            }

            // 디버깅용 이미지 확인을 위한 저장
            bmp.Save("captured_image.png");

            // 결과 표시용 폼 생성 및 표시
            FormResult resultForm = new FormResult();
            await resultForm.LoadImageAndProcessAsync(bmp);
            resultForm.ShowDialog();

            this.Close(); // 창 닫기
        }

        // 폼을 다시 그려서 선택된 영역을 표시
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (isDragging)
            {
                e.Graphics.DrawRectangle(Pens.Red, captureArea);
            }
        }
    }
}
