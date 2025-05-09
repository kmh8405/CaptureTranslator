using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CaptureTranslatorApp
{
    public partial class FormMain: Form
    {
        private bool apiWarningShown = false; // 경고창은 앱 실행 중 1회만
        public FormMain()
        {
            InitializeComponent();
            tbApi.Clear();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            // API 키가 등록되어 있지 않으면 경고창 (1회만)
            if (string.IsNullOrEmpty(Translator.ApiKey))
            {
                if (!apiWarningShown)
                {
                    MessageBox.Show("API 키를 먼저 등록해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    apiWarningShown = true;
                }
                return;
            }

            // FormMain 숨기고 CaptureOverlay 실행
            this.Hide();
            CaptureOverlay overlay = new CaptureOverlay();
            overlay.FormClosed += (s, args) => this.Show(); // overlay 닫히면 다시 보여줌
            overlay.Show();
        }

        private void btnApi_Click(object sender, EventArgs e)
        {
            string apiKey = tbApi.Text.Trim();  // 텍스트박스에서 API 키 가져오기

            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("API 키를 입력해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Translator.SetApiKey(apiKey); // Translator.cs에서 API 키 설정
            tbApi.Clear(); // 텍스트박스 초기화

            MessageBox.Show("API 키가 등록되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeepLLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.deepl.com/en/pro-api#api-pricing",
                UseShellExecute = true
            });
        }
    }
}
