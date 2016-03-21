using System;
using System.Collections.Generic;

namespace Calendar
{
    public class Task : IComparable<Task>
    {
        protected internal const string path = @"files\file.csv";
        public const string stdDateFormat = "d.M.yyyy";
        public DateTime Date { get; set; }
        public string DateStr { get; set; }
        public string TaskName { get; set; }
        public bool Remember { get; set; }

        public Task(string dateStr, string taskName) : this(Convert.ToDateTime(dateStr), dateStr, taskName, true)
        {
        }

        public Task(DateTime date, string dateStr, string taskName, bool remember)
        {
            Date = date;
            DateStr = dateStr;
            TaskName = taskName;
            Remember = remember;
        }

        public static List<Task> GetAllSpecificTasks(HashSet<Task> taskList, string neededTask)
        {
            List<Task> foundTasks = new List<Task>();

            foreach (Task t in taskList)
            {
                if (t.TaskName.Equals(neededTask))
                {
                    foundTasks.Add(t);
                }
            }

            return foundTasks;
        }

        public static Task GetSpecificTask(HashSet<Task> taskList, Task neededTask)
        {
            Task foundTask = null;
            foreach (Task t in taskList)
            {
                if (t.Equals(neededTask))
                {
                    foundTask = t;
                    break;
                }
            }

            return foundTask;
        }

        public bool IsExpired()
        {
            if (this.Date < DateTime.Today)
                return true;
            else
                return false;
        }

        public string ToString(bool writeToFile = false)
        {
            if (writeToFile)
                return String.Format("{0};{1};{2}", DateStr, TaskName, Convert.ToString(Remember));
            else
                return String.Format("{0}: {1}", DateStr, TaskName);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Task))
            {
                return false;
            }
            else
            {
                Task t = (Task)obj;
                return this.DateStr.Equals(t.DateStr) && this.TaskName.Equals(t.TaskName);
            }
        }

        public override int GetHashCode()
        {
            return DateStr.GetHashCode() + TaskName.GetHashCode();
        }

        public int CompareTo(Task t)
        {
            if (t == null)
                throw new NullReferenceException();
            return this.Date.CompareTo(t.Date);
        }
    }
}
