namespace Calendar
{
    partial class CalendarWindow
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
            this.inputShow = new System.Windows.Forms.TextBox();
            this.show = new System.Windows.Forms.Button();
            this.inputAdd = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.inputDelete = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.showAll = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.TextBox();
            this.deleteAll = new System.Windows.Forms.Button();
            this.from = new System.Windows.Forms.Label();
            this.changeFrom = new System.Windows.Forms.TextBox();
            this.to = new System.Windows.Forms.Label();
            this.changeTo = new System.Windows.Forms.TextBox();
            this.changeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.recover = new System.Windows.Forms.Button();
            this.startupCheck = new System.Windows.Forms.CheckBox();
            this.datePicker = new System.Windows.Forms.MonthCalendar();
            this.selectedDate = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.help = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputShow
            // 
            this.inputShow.Location = new System.Drawing.Point(263, 298);
            this.inputShow.Name = "inputShow";
            this.inputShow.Size = new System.Drawing.Size(310, 20);
            this.inputShow.TabIndex = 2;
            this.inputShow.Click += new System.EventHandler(this.inputShow_Click);
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(594, 294);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(75, 27);
            this.show.TabIndex = 3;
            this.show.Text = "anzeigen";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // inputAdd
            // 
            this.inputAdd.Location = new System.Drawing.Point(263, 346);
            this.inputAdd.Name = "inputAdd";
            this.inputAdd.Size = new System.Drawing.Size(310, 20);
            this.inputAdd.TabIndex = 4;
            this.inputAdd.Click += new System.EventHandler(this.inputAdd_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(595, 340);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(74, 26);
            this.add.TabIndex = 5;
            this.add.Text = "hinzufügen";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // inputDelete
            // 
            this.inputDelete.Location = new System.Drawing.Point(263, 391);
            this.inputDelete.Name = "inputDelete";
            this.inputDelete.Size = new System.Drawing.Size(310, 20);
            this.inputDelete.TabIndex = 6;
            this.inputDelete.Click += new System.EventHandler(this.inputDelete_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(595, 385);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(74, 26);
            this.delete.TabIndex = 7;
            this.delete.Text = "entfernen";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // showAll
            // 
            this.showAll.Location = new System.Drawing.Point(263, 241);
            this.showAll.Name = "showAll";
            this.showAll.Size = new System.Drawing.Size(103, 29);
            this.showAll.TabIndex = 8;
            this.showAll.Text = "alle anzeigen";
            this.showAll.UseVisualStyleBackColor = true;
            this.showAll.Click += new System.EventHandler(this.showAll_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.outputLabel.Location = new System.Drawing.Point(19, 30);
            this.outputLabel.Multiline = true;
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.ReadOnly = true;
            this.outputLabel.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputLabel.Size = new System.Drawing.Size(651, 183);
            this.outputLabel.TabIndex = 9;
            // 
            // deleteAll
            // 
            this.deleteAll.Location = new System.Drawing.Point(566, 241);
            this.deleteAll.Name = "deleteAll";
            this.deleteAll.Size = new System.Drawing.Size(103, 29);
            this.deleteAll.TabIndex = 10;
            this.deleteAll.Text = "alle entfernen";
            this.deleteAll.UseVisualStyleBackColor = true;
            this.deleteAll.Click += new System.EventHandler(this.deleteAll_Click);
            // 
            // from
            // 
            this.from.AutoSize = true;
            this.from.Location = new System.Drawing.Point(260, 438);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(25, 13);
            this.from.TabIndex = 11;
            this.from.Text = "von";
            // 
            // changeFrom
            // 
            this.changeFrom.Location = new System.Drawing.Point(291, 435);
            this.changeFrom.Name = "changeFrom";
            this.changeFrom.Size = new System.Drawing.Size(129, 20);
            this.changeFrom.TabIndex = 12;
            this.changeFrom.Click += new System.EventHandler(this.changeFrom_Click);
            // 
            // to
            // 
            this.to.AutoSize = true;
            this.to.Location = new System.Drawing.Point(426, 438);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(18, 13);
            this.to.TabIndex = 13;
            this.to.Text = "zu";
            // 
            // changeTo
            // 
            this.changeTo.Location = new System.Drawing.Point(450, 435);
            this.changeTo.Name = "changeTo";
            this.changeTo.Size = new System.Drawing.Size(123, 20);
            this.changeTo.TabIndex = 14;
            this.changeTo.Click += new System.EventHandler(this.changeTo_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(595, 431);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(74, 26);
            this.changeButton.TabIndex = 15;
            this.changeButton.Text = "ändern";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(263, 475);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(74, 26);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "sichern";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.InitialDirectory = "files\\recovery";
            // 
            // recover
            // 
            this.recover.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recover.Location = new System.Drawing.Point(568, 475);
            this.recover.Name = "recover";
            this.recover.Size = new System.Drawing.Size(101, 26);
            this.recover.TabIndex = 17;
            this.recover.Text = "wiederherstellen";
            this.recover.UseVisualStyleBackColor = true;
            this.recover.Click += new System.EventHandler(this.recover_Click);
            // 
            // startupCheck
            // 
            this.startupCheck.AutoSize = true;
            this.startupCheck.Location = new System.Drawing.Point(19, 481);
            this.startupCheck.Name = "startupCheck";
            this.startupCheck.Size = new System.Drawing.Size(206, 17);
            this.startupCheck.TabIndex = 18;
            this.startupCheck.Text = "Beim Systemstart auf Aufgaben prüfen";
            this.startupCheck.UseVisualStyleBackColor = true;
            this.startupCheck.CheckedChanged += new System.EventHandler(this.startupCheck_CheckedChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(19, 289);
            this.datePicker.MaxSelectionCount = 1;
            this.datePicker.Name = "datePicker";
            this.datePicker.ShowToday = false;
            this.datePicker.ShowTodayCircle = false;
            this.datePicker.TabIndex = 19;
            this.datePicker.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.datePicker_DateChanged);
            // 
            // selectedDate
            // 
            this.selectedDate.Location = new System.Drawing.Point(63, 246);
            this.selectedDate.Name = "selectedDate";
            this.selectedDate.ReadOnly = true;
            this.selectedDate.Size = new System.Drawing.Size(154, 20);
            this.selectedDate.TabIndex = 20;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(16, 249);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(41, 13);
            this.dateLabel.TabIndex = 21;
            this.dateLabel.Text = "Datum:";
            // 
            // help
            // 
            this.help.AutoSize = true;
            this.help.Location = new System.Drawing.Point(16, 9);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(242, 13);
            this.help.TabIndex = 22;
            this.help.Text = "Drücken Sie F1 um Hilfeinformationen anzuzeigen";
            // 
            // CalendarWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 514);
            this.Controls.Add(this.help);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.selectedDate);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.startupCheck);
            this.Controls.Add(this.recover);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.changeTo);
            this.Controls.Add(this.to);
            this.Controls.Add(this.changeFrom);
            this.Controls.Add(this.from);
            this.Controls.Add(this.deleteAll);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.showAll);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.inputDelete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.inputAdd);
            this.Controls.Add(this.show);
            this.Controls.Add(this.inputShow);
            this.Name = "CalendarWindow";
            this.Text = "Kalender";
            this.Load += new System.EventHandler(this.CalendarWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputShow;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.TextBox inputAdd;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox inputDelete;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button showAll;
        private System.Windows.Forms.TextBox outputLabel;
        private System.Windows.Forms.Button deleteAll;
        private System.Windows.Forms.Label from;
        private System.Windows.Forms.TextBox changeFrom;
        private System.Windows.Forms.Label to;
        private System.Windows.Forms.TextBox changeTo;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button recover;
        private System.Windows.Forms.CheckBox startupCheck;
        private System.Windows.Forms.MonthCalendar datePicker;
        private System.Windows.Forms.TextBox selectedDate;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label help;
    }
}

