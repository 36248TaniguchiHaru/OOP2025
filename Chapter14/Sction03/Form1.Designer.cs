namespace Sction03 {
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
            button1 = new Button();
            ToolStripStatusLabel = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(346, 149);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // ToolStripStatusLabel
            // 
            ToolStripStatusLabel.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            ToolStripStatusLabel.Location = new Point(0, 428);
            ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            ToolStripStatusLabel.Size = new Size(800, 22);
            ToolStripStatusLabel.TabIndex = 2;
            ToolStripStatusLabel.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ToolStripStatusLabel);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ToolStripStatusLabel.ResumeLayout(false);
            ToolStripStatusLabel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private StatusStrip ToolStripStatusLabel;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
