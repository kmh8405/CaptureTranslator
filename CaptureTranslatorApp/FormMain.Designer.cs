namespace CaptureTranslatorApp
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblBeforeStart = new System.Windows.Forms.Label();
            this.btnApi = new System.Windows.Forms.Button();
            this.tbApi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeepLLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCapture.Location = new System.Drawing.Point(0, 0);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(201, 32);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "➕번역할 영역 캡처";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // lblBeforeStart
            // 
            this.lblBeforeStart.AutoSize = true;
            this.lblBeforeStart.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBeforeStart.Location = new System.Drawing.Point(73, 59);
            this.lblBeforeStart.Name = "lblBeforeStart";
            this.lblBeforeStart.Size = new System.Drawing.Size(259, 15);
            this.lblBeforeStart.TabIndex = 2;
            this.lblBeforeStart.Text = "※ 실행 전, 먼저 DeepL API 키를 등록해주세요.";
            // 
            // btnApi
            // 
            this.btnApi.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApi.Location = new System.Drawing.Point(246, 0);
            this.btnApi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApi.Name = "btnApi";
            this.btnApi.Size = new System.Drawing.Size(115, 32);
            this.btnApi.TabIndex = 3;
            this.btnApi.Text = "API 등록";
            this.btnApi.UseVisualStyleBackColor = true;
            this.btnApi.Click += new System.EventHandler(this.btnApi_Click);
            // 
            // tbApi
            // 
            this.tbApi.Location = new System.Drawing.Point(34, 36);
            this.tbApi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbApi.Name = "tbApi";
            this.tbApi.Size = new System.Drawing.Size(327, 21);
            this.tbApi.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(-3, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 75);
            this.label1.TabIndex = 5;
            this.label1.Text = "DeepL API Key 생성 방법:\r\n1. 하단 링크에 접속하여 Sign Up for Free 클릭\r\n2. 회원가입 후, 우측 상단의 프로필 -" +
    "> account 클릭\r\n3. 상단의 API Keys & Limits 클릭하고 아래에 있는 API키 복사\r\n4. 복사한 API Key를 이 창 " +
    "텍스트박스에 붙여넣기 후, API 등록 버튼 클릭";
            // 
            // DeepLLink
            // 
            this.DeepLLink.AutoSize = true;
            this.DeepLLink.Location = new System.Drawing.Point(147, 163);
            this.DeepLLink.Name = "DeepLLink";
            this.DeepLLink.Size = new System.Drawing.Size(93, 12);
            this.DeepLLink.TabIndex = 6;
            this.DeepLLink.TabStop = true;
            this.DeepLLink.Text = "DeepL 웹사이트";
            this.DeepLLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DeepLLink_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 184);
            this.Controls.Add(this.DeepLLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbApi);
            this.Controls.Add(this.btnApi);
            this.Controls.Add(this.lblBeforeStart);
            this.Controls.Add(this.btnCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "캡처영역 자동번역";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label lblBeforeStart;
        private System.Windows.Forms.Button btnApi;
        private System.Windows.Forms.TextBox tbApi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel DeepLLink;
    }
}

