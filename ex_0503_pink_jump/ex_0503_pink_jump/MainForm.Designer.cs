namespace ex_0503_pink_jump {
    partial class MainForm {
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
            if (disposing && (components != null)) {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.jumpImages = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.animTimer = new System.Windows.Forms.Timer(this.components);
            this.updown = new System.Windows.Forms.NumericUpDown();
            this.slider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // jumpImages
            // 
            this.jumpImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("jumpImages.ImageStream")));
            this.jumpImages.TransparentColor = System.Drawing.Color.Transparent;
            this.jumpImages.Images.SetKeyName(0, "pink_jump_001.png");
            this.jumpImages.Images.SetKeyName(1, "pink_jump_002.png");
            this.jumpImages.Images.SetKeyName(2, "pink_jump_003.png");
            this.jumpImages.Images.SetKeyName(3, "pink_jump_004.png");
            this.jumpImages.Images.SetKeyName(4, "pink_jump_005.png");
            this.jumpImages.Images.SetKeyName(5, "pink_jump_006.png");
            this.jumpImages.Images.SetKeyName(6, "pink_jump_007.png");
            this.jumpImages.Images.SetKeyName(7, "pink_jump_008.png");
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(172, 209);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(245, 13);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(145, 67);
            this.upButton.TabIndex = 1;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(245, 86);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(145, 67);
            this.downButton.TabIndex = 1;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // animTimer
            // 
            this.animTimer.Interval = 10;
            this.animTimer.Tick += new System.EventHandler(this.animTimer_Tick);
            // 
            // updown
            // 
            this.updown.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.updown.Location = new System.Drawing.Point(245, 168);
            this.updown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.updown.Name = "updown";
            this.updown.Size = new System.Drawing.Size(145, 35);
            this.updown.TabIndex = 2;
            this.updown.ValueChanged += new System.EventHandler(this.updown_ValueChanged);
            // 
            // slider
            // 
            this.slider.LargeChange = 3;
            this.slider.Location = new System.Drawing.Point(245, 209);
            this.slider.Maximum = 7;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(145, 45);
            this.slider.TabIndex = 3;
            this.slider.ValueChanged += new System.EventHandler(this.slider_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 304);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.updown);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.pictureBox);
            this.Name = "MainForm";
            this.Text = "Jump";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList jumpImages;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Timer animTimer;
        private System.Windows.Forms.NumericUpDown updown;
        private System.Windows.Forms.TrackBar slider;
    }
}

