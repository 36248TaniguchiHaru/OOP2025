namespace WindowsFormsApp1 {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.btChange = new System.Windows.Forms.Button();
            this.tbNum1 = new System.Windows.Forms.TextBox();
            this.tbNum2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudNum1 = new System.Windows.Forms.NumericUpDown();
            this.nudNum2 = new System.Windows.Forms.NumericUpDown();
            this.nudAnswer = new System.Windows.Forms.NumericUpDown();
            this.btCalc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mod1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mod1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(48, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "変換前";
            // 
            // btChange
            // 
            this.btChange.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btChange.Location = new System.Drawing.Point(177, 155);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(76, 34);
            this.btChange.TabIndex = 1;
            this.btChange.Text = "変換";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Click += new System.EventHandler(this.buChange_Click);
            // 
            // tbNum1
            // 
            this.tbNum1.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum1.Location = new System.Drawing.Point(153, 80);
            this.tbNum1.Name = "tbNum1";
            this.tbNum1.Size = new System.Drawing.Size(124, 42);
            this.tbNum1.TabIndex = 2;
            // 
            // tbNum2
            // 
            this.tbNum2.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum2.Location = new System.Drawing.Point(153, 214);
            this.tbNum2.Name = "tbNum2";
            this.tbNum2.Size = new System.Drawing.Size(124, 42);
            this.tbNum2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(48, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "変換後";
            // 
            // nudNum1
            // 
            this.nudNum1.Location = new System.Drawing.Point(23, 294);
            this.nudNum1.Name = "nudNum1";
            this.nudNum1.Size = new System.Drawing.Size(80, 19);
            this.nudNum1.TabIndex = 5;
            // 
            // nudNum2
            // 
            this.nudNum2.Location = new System.Drawing.Point(165, 294);
            this.nudNum2.Name = "nudNum2";
            this.nudNum2.Size = new System.Drawing.Size(88, 19);
            this.nudNum2.TabIndex = 6;
            // 
            // nudAnswer
            // 
            this.nudAnswer.Location = new System.Drawing.Point(318, 294);
            this.nudAnswer.Name = "nudAnswer";
            this.nudAnswer.Size = new System.Drawing.Size(83, 19);
            this.nudAnswer.TabIndex = 7;
            // 
            // btCalc
            // 
            this.btCalc.Location = new System.Drawing.Point(306, 335);
            this.btCalc.Name = "btCalc";
            this.btCalc.Size = new System.Drawing.Size(83, 37);
            this.btCalc.TabIndex = 8;
            this.btCalc.Text = "計算";
            this.btCalc.UseVisualStyleBackColor = true;
            this.btCalc.Click += new System.EventHandler(this.btCalc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(277, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "＝";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(123, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "÷";
            // 
            // mod1
            // 
            this.mod1.Location = new System.Drawing.Point(153, 353);
            this.mod1.Name = "mod1";
            this.mod1.Size = new System.Drawing.Size(80, 19);
            this.mod1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(424, 408);
            this.Controls.Add(this.mod1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btCalc);
            this.Controls.Add(this.nudAnswer);
            this.Controls.Add(this.nudNum2);
            this.Controls.Add(this.nudNum1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNum2);
            this.Controls.Add(this.tbNum1);
            this.Controls.Add(this.btChange);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mod1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.TextBox tbNum1;
        private System.Windows.Forms.TextBox tbNum2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudNum1;
        private System.Windows.Forms.NumericUpDown nudNum2;
        private System.Windows.Forms.NumericUpDown nudAnswer;
        private System.Windows.Forms.Button btCalc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown mod1;
    }
}

