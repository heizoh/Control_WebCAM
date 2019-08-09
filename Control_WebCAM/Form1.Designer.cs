namespace Control_WebCAM
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Shot = new System.Windows.Forms.Button();
            this.button_Rec = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_Config = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(12, 738);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 34);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "起動";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button_Shot
            // 
            this.button_Shot.Enabled = false;
            this.button_Shot.Location = new System.Drawing.Point(174, 738);
            this.button_Shot.Name = "button_Shot";
            this.button_Shot.Size = new System.Drawing.Size(75, 34);
            this.button_Shot.TabIndex = 1;
            this.button_Shot.Text = "撮影";
            this.button_Shot.UseVisualStyleBackColor = true;
            this.button_Shot.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button_Rec
            // 
            this.button_Rec.Enabled = false;
            this.button_Rec.Location = new System.Drawing.Point(93, 738);
            this.button_Rec.Name = "button_Rec";
            this.button_Rec.Size = new System.Drawing.Size(75, 34);
            this.button_Rec.TabIndex = 1;
            this.button_Rec.Text = "録画";
            this.button_Rec.UseVisualStyleBackColor = true;
            this.button_Rec.Click += new System.EventHandler(this.Button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 778);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1280, 69);
            this.textBox1.TabIndex = 2;
            // 
            // button_Config
            // 
            this.button_Config.Location = new System.Drawing.Point(1217, 738);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(75, 34);
            this.button_Config.TabIndex = 1;
            this.button_Config.Text = "設定";
            this.button_Config.UseVisualStyleBackColor = true;
            this.button_Config.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 863);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Config);
            this.Controls.Add(this.button_Rec);
            this.Controls.Add(this.button_Shot);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Shot;
        private System.Windows.Forms.Button button_Rec;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_Config;
    }
}

