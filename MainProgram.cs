using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using IWshRuntimeLibrary;

namespace Calendar
{
    static class MainProgram
    {
        private static bool ioError = false;
        private static bool launchedViaStartup;
        public static HashSet<Task> taskList = new HashSet<Task>();
        internal static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Calendar\\" + Task.path;
        internal static readonly string dirpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Calendar\\files";
        internal static readonly string recoveryPath = dirpath + "\\recovery";
        private static bool recovered = false;
        private static bool msgShown = false;

        [STAThread]
        static void Main(string[] args)
        {
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
                Directory.CreateDirectory(recoveryPath);
                var fs = System.IO.File.Create(path);
                fs.Close();
            }

            launchedViaStartup = (args != null) && (args.Contains("-startup") | args.Contains("/startup"));
            CreateTaskList();
            RemoveExpiredTasks();

            if(!msgShown)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }

            if (launchedViaStartup)
            {
                StartupControl();
            }
            else
            {
                new CalendarWindow().ShowDialog();
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            }
        }

        private static void CreateTaskList()
        {
            string line;
            using (StreamReader reader = new StreamReader(path))
            {
                try
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] splitted = line.Split(';');
                        taskList.Add(new Task(Convert.ToDateTime(splitted[0]), splitted[0], splitted[1], Convert.ToBoolean(splitted[2])));
                    }
                }
                catch (IOException)
                {
                    ioError = true;
                    DialogResult result = MessageBox.Show("Aufgaben konnten nicht gelesen werden!", "Fehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
                        Application.Exit();
                    }
                }
            }
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            if (!recovered && !ioError)
                WriteToFile();
        }

        private static void WriteToFile()
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (Task t in taskList)
                writer.WriteLine(t.ToString(true));
            writer.Close();
        }

        private static void RemoveExpiredTasks()
        {
            List<Task> expiredTasks = new List<Task>();
            foreach (Task t in taskList)
            {
                if (t.IsExpired())
                    expiredTasks.Add(t);
            }

            foreach (Task t in expiredTasks)
                taskList.Remove(t);
        }

        public static void SaveFile()
        {
            string dst = recoveryPath + "\\save_" + DateTime.Today.ToShortDateString() + ".csv";
            if (System.IO.File.Exists(dst))
                System.IO.File.Delete(dst);
            System.IO.File.Copy(path, dst);
        }

        public static void Recovery(string file)
        {
            System.IO.File.WriteAllText(path, string.Empty);
            string content = System.IO.File.ReadAllText(file);
            System.IO.File.WriteAllText(path, content);
            recovered = true;
            Application.Restart();
        }

        public static void CreateStartupShortcut()
        {
            string app = System.Reflection.Assembly.GetExecutingAssembly().Location;

            WshShell wsh = new WshShell();
            IWshShortcut shortcut = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Kalender.lnk") as IWshShortcut;
            shortcut.Arguments = "-startup";
            shortcut.TargetPath = app;
            shortcut.WindowStyle = 1;
            shortcut.Description = "Kalender";
            shortcut.WorkingDirectory = Directory.GetCurrentDirectory();
            shortcut.IconLocation = app.Replace("\\", "/");
            shortcut.Save();
        }

        public static void RemoveStartupShortcut()
        {
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\Kalender.url");
        }

        public static bool StartupShortcutExists()
        {
            return System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\Kalender.lnk");
        }

        private static void StartupControl()
        {
            bool found = false;
            List<Task> presentTasks = new List<Task>();
            foreach (Task t in taskList)
            {
                if ((t.Date - DateTime.Today).TotalDays <= 5 && t.Remember)
                {
                    found = true;
                    presentTasks.Add(t);
                }
            }
            presentTasks.Sort();

            if (found)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Task t in presentTasks)
                    sb.AppendLine("    - " + t.ToString());

                string msg = sb.ToString();

                msgShown = true;

                MsgBoxCheck msgBox = new MsgBoxCheck();
                msgBox.outputText.Text = "Aufgaben in den nächsten 5 Tagen:\r\n\r\n" + msg + "\r\nAlle Aufgaben anzeigen?";


                msgBox.checkBox.CheckedChanged += (sender, e) =>
                { 
                    if (msgBox.checkBox.CheckState == CheckState.Checked)
                    {
                        foreach (Task t in presentTasks)
                        {
                            bool removed = taskList.Remove(t);
                            t.Remember = false;
                            bool added = taskList.Add(t);
                        }
                    }
                    else if (msgBox.checkBox.CheckState == CheckState.Unchecked)
                    {
                        foreach (Task t in presentTasks)
                        {
                            bool removed = taskList.Remove(t);
                            t.Remember = true;
                            bool added = taskList.Add(t);
                        }
                    }
                };

                msgBox.yes.Click += (sender, e) =>
                {
                    msgBox.Close();
                    msgBox.Dispose();
                    Main(null);
                };
                msgBox.no.Click += (sender, e) =>
                {
                    AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
                    msgBox.Close();
                };
                msgBox.ShowDialog();
            }
            else
            {
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
                Application.Exit();
            }
        }
    }
}
