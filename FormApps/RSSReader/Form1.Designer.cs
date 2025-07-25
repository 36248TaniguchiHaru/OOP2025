namespace RSSReader {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btRssGet = new Button();
            lbTitles = new ListBox();
            wvRssview = new Microsoft.Web.WebView2.WinForms.WebView2();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            button3 = new Button();
            textBox1 = new TextBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)wvRssview).BeginInit();
            SuspendLayout();
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14F);
            btRssGet.Location = new Point(618, 12);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(75, 32);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.DrawMode = DrawMode.OwnerDrawFixed;
            lbTitles.Font = new Font("Yu Gothic UI", 12F);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(12, 93);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(681, 130);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            lbTitles.DrawItem += lbTitles_DrawItem_1;
            // 
            // wvRssview
            // 
            wvRssview.AllowExternalDrop = true;
            wvRssview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssview.CreationProperties = null;
            wvRssview.DefaultBackgroundColor = Color.White;
            wvRssview.Location = new Point(12, 242);
            wvRssview.Name = "wvRssview";
            wvRssview.Size = new Size(681, 398);
            wvRssview.TabIndex = 3;
            wvRssview.ZoomFactor = 1D;
            // 
            // button1
            // 
            button1.Location = new Point(12, 13);
            button1.Name = "button1";
            button1.Size = new Size(45, 31);
            button1.TabIndex = 4;
            button1.Text = "戻る";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(63, 13);
            button2.Name = "button2";
            button2.Size = new Size(45, 31);
            button2.TabIndex = 5;
            button2.Text = "進む";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Yu Gothic UI", 11F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(114, 14);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(498, 28);
            comboBox1.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(554, 50);
            button3.Name = "button3";
            button3.Size = new Size(93, 37);
            button3.TabIndex = 7;
            button3.Text = "お気に入り登録";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Yu Gothic UI", 12F);
            textBox1.Location = new Point(156, 53);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(392, 29);
            textBox1.TabIndex = 8;
            // 
            // button4
            // 
            button4.Location = new Point(648, 50);
            button4.Name = "button4";
            button4.Size = new Size(45, 37);
            button4.TabIndex = 9;
            button4.Text = "削除";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 652);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(wvRssview);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Name = "Form1";
            Text = "RSSリーダー";
            ((System.ComponentModel.ISupportInitialize)wvRssview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssview;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private Button button3;
        private TextBox textBox1;
        private Button button4;
    }
}
