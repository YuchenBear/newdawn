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
        public int score { get; set; }
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
            score = 0;
            replies = Reply.GetReplies();
        }

        public Thread(string Name, string Title, string ZipCode, Image Picture)
        {
            Random random = new Random();
            name = Name;
            title = Title;
            zipCode = ZipCode;
            date = new DateTime(2013, random.Next(0,13), random.Next(0,28), random.Next(0,24), random.Next(0,60), 23);
            agreed = 1;
            disagreed = 1;
            score = 0;
            replies = Reply.GetReplies();
            replyCount = replies.Count;
        }

        public Thread(string Name, string Title, string Comment, int Score)
        {
            Random random = new Random();
            name = Name;
            title = Title;
            comment = Comment;
            zipCode = random.Next(23211,99999).ToString();
            date = new DateTime(2013, random.Next(1, 12), random.Next(1, 27), random.Next(1, 24), random.Next(1, 21), 23);
            agreed = 1;
            disagreed = 1;
            score = Score;
            replies = Reply.GetReplies();
            replyCount = replies.Count;
        }

        public void AddReply(string Name, string Comment)
        {
            Reply newReply = new Reply(Name, Comment);
            replies.Add(newReply);
            replyCount++;
        }

        public void AddReply(Reply newReply)
        {
            replies.Add(newReply);
            replyCount++;
        }

        public void Agree()
        {
            agreed++;
            score++;
        }

        public void Disagree()
        {
            disagreed++;
            score--;
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

            Threads.Add(new Thread("Ted Harvey","I lost my Teddy Bear!","Please help, I can't sleep without it!",13));
            Threads.Add(new Thread("Alex Timothy", "Broken Lightpole", "I can't walk the street at night like this!",22));
            Threads.Add(new Thread("Allison Precious", "Drugs for sale", "Guaranteed low price.",132));
            Threads.Add(new Thread("I need money", "The government should give everyone $1000 dollar", "Pretty please?", 3203));
            Threads.Add(new Thread("Vivi", "It's my Birthday!", "I'm 9!", 3203));

            return Threads;
        }
    }
}
