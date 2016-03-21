using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calendar
{
    public partial class CalendarWindow : Form
    {
        private bool addClicked = false;
        private bool deleteClicked = false;
        private bool changeFromClicked = false;
        private bool changeToClicked = false;

        public CalendarWindow()
        {
            InitializeComponent();
            this.Icon = new Icon(@"files\icon.ico");
            if (MainProgram.StartupShortcutExists())
                startupCheck.CheckState = CheckState.Checked;
            else
                startupCheck.CheckState = CheckState.Unchecked;
        }

        private void ClearOtherTextBoxes(ref TextBox me)
        {
            TextBox[] textboxes = { inputShow, inputAdd, inputDelete, changeFrom, changeTo };
            int index = 0;

            for (int i = 0; i < textboxes.Length; i++)
            {
                if (textboxes[i].Equals(me))
                    index = i;
            }

            List<TextBox> tmp = textboxes.ToList();
            tmp.RemoveAt(index);

            foreach (TextBox t in tmp)
                t.Text = "";

            ResetAllTextBoxes(false);
        }

        private void ResetAllTextBoxes(bool resetValues = true) //except inputShow
        {
            addClicked = false;
            deleteClicked = false;
            changeFromClicked = false;
            changeToClicked = false;

            if (resetValues)
            {
                inputAdd.Text = "";
                inputDelete.Text = "";
                changeFrom.Text = "";
                changeTo.Text = "";
            }
        }

        private void ShowAllLabel()
        {
            ResetAllTextBoxes();
            List<Task> sortedTaskList = MainProgram.taskList.ToList();
            sortedTaskList.Sort();
            StringBuilder sb = new StringBuilder();

            foreach (Task t in sortedTaskList)
            {
                sb.AppendLine(t.ToString());
            }
            outputLabel.Text = sb.ToString();
        }

        private string GetDate()
        {
            return datePicker.SelectionRange.Start.ToString(Task.stdDateFormat);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                MessageBox.Show(this, "Eingaben müssen Datum und Aufgabe  enthalten.\r\n(Ausgenommen \"anzeigen\": nur Aufgabe)\r\n\r\nFormat: "
                    + "<Datum> <Aufgabe>\r\n\r\nDatum und Aufgabe müssen durch Leerzeichen getrennt sein. Keine weiteren Leerzeichen eingeben.\r\n\r\n"
                    + "Beim Systemstart auf Aufgaben prüfen:\r\nFür Aufgaben, die in den nächsten 5 Tagen fällig sind, wird beim Systemstart eine kurze "
                    + "Meldung angezeigt.", "Hilfe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CalendarWindow_Load(object sender, EventArgs e)
        {
            ShowAllLabel();
            selectedDate.Text = DateTime.Today.ToString(Task.stdDateFormat);
        }


        private void show_Click(object sender, EventArgs e)
        {
            try
            {
                string neededTask = inputShow.Text.Trim();
                List<Task> tasks = Task.GetAllSpecificTasks(MainProgram.taskList, neededTask);

                if (tasks.Count == 0)
                    throw new InvalidTaskException();

                StringBuilder sb = new StringBuilder();

                foreach (Task t in tasks)
                    sb.AppendLine(t.ToString());

                outputLabel.Text = sb.ToString();
                ResetAllTextBoxes();
            }
            catch (InvalidTaskException)
            {
                MessageBox.Show(this, "Eintrag nicht gefunden: " + inputShow.Text, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                inputShow.SelectAll();
                inputShow.Focus();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                string[] values = inputAdd.Text.Trim().Split(' ');

                if (values.Length != 2)
                    throw new InvalidTaskException();

                Task t = new Task(values[0], values[1]);

                if (t.IsExpired())
                    throw new ExpiredTaskException();

                MainProgram.taskList.Add(t);
                MessageBox.Show(this, "Aufgabe " + values[1] + " am " + values[0] + " hinzugefügt.", "Aufgabe hinzugefügt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowAllLabel();
            }
            catch (ExpiredTaskException)
            {
                MessageBox.Show(this, inputAdd.Text.Trim().Split(' ')[0] + " ist ein bereits vergangenes Datum!", "Datum bereits vergangen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                inputAdd.SelectAll();
                inputAdd.Focus();
            }
            catch (Exception ex) when (ex is InvalidTaskException || ex is FormatException)
            {
                MessageBox.Show(this, "Ungültige Eingabe: " + inputAdd.Text, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                inputAdd.SelectAll();
                inputAdd.Focus();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] entry = inputDelete.Text.Trim().Split(' ');

                Task t = Task.GetSpecificTask(MainProgram.taskList, new Task(entry[0], entry[1]));
                if (t != null)
                    MainProgram.taskList.Remove(t);
                else
                    throw new InvalidTaskException();
                MessageBox.Show(this, "Eintrag " + entry[1] + " vom " + entry[0] + " entfernt.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowAllLabel();
            }
            catch (InvalidTaskException)
            {
                MessageBox.Show(this, "Eintrag nicht vorhanden: " + inputDelete.Text, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                inputDelete.SelectAll();
                inputDelete.Focus();
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                MessageBox.Show(this, "Ungültige Eingabe: " + inputDelete.Text, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                inputDelete.SelectAll();
                inputDelete.Focus();
            }
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            ShowAllLabel();
        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Wirklich alle Aufgaben entfernen?", "Alle Aufgaben entfernen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MainProgram.taskList.Clear();
                ShowAllLabel();
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] entryFrom = changeFrom.Text.Trim().Split(' ');
                Task from = Task.GetSpecificTask(MainProgram.taskList, new Task(entryFrom[0], entryFrom[1]));

                string[] entryTo = changeTo.Text.Trim().Split(' ');
                Task to = new Task(entryTo[0], entryTo[1]);

                if (!MainProgram.taskList.Remove(from))
                    throw new InvalidTaskException();

                MainProgram.taskList.Add(to);

                MessageBox.Show(this, "Aufgabe von " + entryFrom[0] + ": " + entryFrom[1] + " zu " + entryTo[0] + ": " + entryTo[1] + " geändert.", "Aufgabe geändert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowAllLabel();
            }
            catch (InvalidTaskException)
            {
                MessageBox.Show(this, "Eintrag nicht gefunden: " + changeFrom.Text, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                changeFrom.SelectAll();
                changeFrom.Focus();
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                MessageBox.Show(this, "Ungültige Eingabe!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                changeFrom.SelectAll();
                changeFrom.Focus();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            MainProgram.SaveFile();
            MessageBox.Show(this, "Aufgaben vom " + DateTime.Today.ToShortDateString() + " gesichert.", "Gesichert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void recover_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = MainProgram.recoveryPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                MainProgram.Recovery(openFileDialog.FileName);
        }

        private void startupCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (startupCheck.CheckState == CheckState.Checked)
                MainProgram.CreateStartupShortcut();
            else
                MainProgram.RemoveStartupShortcut();
        }

        private void datePicker_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedDate.Text = GetDate();
            addClicked = false;
            deleteClicked = false;
            changeFromClicked = false;
            changeToClicked = false;
        }

        private void inputAdd_Click(object sender, EventArgs e)
        {
            if (!addClicked)
            {
                ClearOtherTextBoxes(ref inputAdd);
                inputAdd.Text = GetDate() + " ";
                inputAdd.Select(inputAdd.Text.Length, 0);
                addClicked = true;
            }
        }

        private void inputDelete_Click(object sender, EventArgs e)
        {
            if (!deleteClicked)
            {
                ClearOtherTextBoxes(ref inputDelete);
                inputDelete.Text = GetDate() + " ";
                inputDelete.Select(inputDelete.Text.Length, 0);
                deleteClicked = true;
            }
        }

        private void changeFrom_Click(object sender, EventArgs e)
        {
            if (!changeFromClicked)
            {
                ClearOtherTextBoxes(ref changeFrom);
                changeFrom.Text = GetDate() + " ";
                changeFrom.Select(changeFrom.Text.Length, 0);
                changeFromClicked = true;
            }
        }

        private void changeTo_Click(object sender, EventArgs e)
        {
            if (!changeToClicked)
            {
                changeTo.Text = GetDate() + " ";
                changeTo.Select(changeTo.Text.Length, 0);
                changeToClicked = true;
            }
        }

        private void inputShow_Click(object sender, EventArgs e)
        {
            ResetAllTextBoxes(); //Textboxes except inputShow
        }
    }
}
