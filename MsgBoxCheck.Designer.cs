namespace Calendar
{
    partial class MsgBoxCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.yes = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.outputText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yes
            // 
            this.yes.Location = new System.Drawing.Point(163, 113);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(75, 23);
            this.yes.TabIndex = 0;
            this.yes.Text = "Ja";
            this.yes.UseVisualStyleBackColor = true;
            // 
            // no
            // 
            this.no.Location = new System.Drawing.Point(244, 113);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(75, 23);
            this.no.TabIndex = 1;
            this.no.Text = "Nein";
            this.no.UseVisualStyleBackColor = true;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(12, 151);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(278, 17);
            this.checkBox.TabIndex = 2;
            this.checkBox.Text = "Mitteilungen zu diesen Aufgaben nicht mehr anzeigen";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // outputText
            // 
            this.outputText.AutoSize = true;
            this.outputText.Location = new System.Drawing.Point(78, 21);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(27, 13);
            this.outputText.TabIndex = 3;
            this.outputText.Text = "asdf";
            // 
            // MsgBoxCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 180);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MsgBoxCheck";
            this.Text = "Kalender";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MsgBoxCheck_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button yes;
        internal System.Windows.Forms.Button no;
        internal System.Windows.Forms.CheckBox checkBox;
        internal System.Windows.Forms.Label outputText;
    }
}