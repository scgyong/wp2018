namespace BricksEditor {
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
            this.label1 = new System.Windows.Forms.Label();
            this.xField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tField = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(831, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "x:";
            // 
            // xField
            // 
            this.xField.Location = new System.Drawing.Point(833, 28);
            this.xField.Name = "xField";
            this.xField.Size = new System.Drawing.Size(100, 21);
            this.xField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(831, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "y:";
            // 
            // yField
            // 
            this.yField.Location = new System.Drawing.Point(833, 78);
            this.yField.Name = "yField";
            this.yField.Size = new System.Drawing.Size(100, 21);
            this.yField.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(831, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "width:";
            // 
            // wField
            // 
            this.wField.Location = new System.Drawing.Point(833, 125);
            this.wField.Name = "wField";
            this.wField.Size = new System.Drawing.Size(100, 21);
            this.wField.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(831, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "height:";
            // 
            // hField
            // 
            this.hField.Location = new System.Drawing.Point(833, 172);
            this.hField.Name = "hField";
            this.hField.Size = new System.Drawing.Size(100, 21);
            this.hField.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(831, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "type:";
            // 
            // tField
            // 
            this.tField.Location = new System.Drawing.Point(833, 222);
            this.tField.Name = "tField";
            this.tField.Size = new System.Drawing.Size(100, 21);
            this.tField.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(833, 249);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(833, 278);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(100, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 565);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.tField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xField);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Bricks Stage Editor";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox yField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox wField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox hField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tField;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
    }
}

