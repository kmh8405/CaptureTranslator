using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTranslatorApp
{
    public partial class FormResult: Form
    {
        private float currentFontSize = 12f; // 폰트 기본 사이즈
        public FormResult()
        {
            InitializeComponent();

            // Ctrl +/- 로 글자 크기 변경 설정
            this.KeyPreview = true;
            this.KeyDown += FormResult_KeyDown;

            SetFontSize(currentFontSize);

            // 복사 가능하도록 설정
            textBoxOriginal.ReadOnly = true;
            textBoxOriginal.Multiline = true;
            textBoxOriginal.ScrollBars = ScrollBars.Vertical;
            textBoxOriginal.ShortcutsEnabled = true; // 텍스트 편집 단축키
            textBoxOriginal.Cursor = Cursors.IBeam;
            textBoxOriginal.BackColor = Color.White;

            textBoxTranslated.ReadOnly = true;
            textBoxTranslated.Multiline = true;
            textBoxTranslated.ScrollBars = ScrollBars.Vertical;
            textBoxTranslated.ShortcutsEnabled = true;
            textBoxTranslated.Cursor = Cursors.IBeam;
            textBoxTranslated.BackColor = Color.White;
        }

        // 이미지 -> OCR+번역 -> 결과 표시
        public async Task LoadImageAndProcessAsync(Bitmap image)
        {
            var (originalText, translatedText) = await OCRManager.PerformOCRAndTranslateAsync(image);

            textBoxOriginal.Text = originalText.Trim();       // 왼쪽 텍스트박스 (원문)
            textBoxTranslated.Text = translatedText.Trim();   // 오른쪽 텍스트박스 (번역문)
        }

        private void FormResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add) // Ctrl + + (확대)
                {
                    currentFontSize += 1f;
                    SetFontSize(currentFontSize);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract) // Ctrl + - (축소)
                {
                    if (currentFontSize > 6f) // 최소 글자 크기 제한
                    {
                        currentFontSize -= 1f;
                        SetFontSize(currentFontSize);
                        e.Handled = true;
                    }
                }
            }
        }

        private void SetFontSize(float size)
        {
            Font font = new Font("맑은 고딕", size);
            textBoxOriginal.Font = font;
            textBoxTranslated.Font = font;
        }
    }
}
