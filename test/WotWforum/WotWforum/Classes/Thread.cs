using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WotWforum.Classes
{
    public class Thread : INotifyPropertyChanged
    {
        public string name { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public Image picture { get; set; }
        public string zipCode { get; set; }
        public int agreed { get; set; }
        public int disagreed { get; set; }
        public DateTime date { get; set; }
        public ObservableCollection<Reply> replies { get; set; }
        public int replyCount { get; set; }

        public Thread()
        {
            name = "testName";
            title = "testTitle";
            comment = "testComment";
            zipCode = "11111";
            date = new DateTime();
            agreed = 1;
            disagreed = 1;
            replies = Reply.GetReplies();
        }

        public Thread(string Name, string Title, string ZipCode, Image Picture)
        {
            name = Name;
            title = Title;
            zipCode = ZipCode;
            date = DateTime.Now;
            agreed = 1;
            disagreed = 1;
            replies = Reply.GetReplies();
            replyCount = replies.Count;
        }

        public void AddReply(string Name, string Comment, string ZipCode)
        {
            Reply newReply = new Reply();
            replies.Add(newReply);
            replyCount++;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public static ObservableCollection<Thread> GetThreads()
        {
            var Threads = new ObservableCollection<Thread>();

            Threads.Add(new Thread());
            Threads.Add(new Thread());
            Threads.Add(new Thread());
            Threads.Add(new Thread());

            return Threads;
        }
    }
}
