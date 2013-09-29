using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WotWforum.Classes
{
    [DataContract]     //Set this attribute to all the classes that want to serialize
    public class Reply : INotifyPropertyChanged
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string comment { get; set; }
        [DataMember]
        public string zipCode { get; set; }
        [DataMember]
        public DateTime date { get; set; }
        DataContractSerializer mySerializer = new DataContractSerializer(typeof(Reply)); 

        public Reply()
        {
            name = "TestName";
            comment = "TestComment";
            zipCode = "TestZipCode";
        }

        public Reply(string Name, string Comment)
        {
            name = Name;
            comment = Comment;
        }

        public Reply(string Name, string Comment, string ZipCode)
        {
            name = Name;
            comment = Comment;
            zipCode = ZipCode;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public static ObservableCollection<Reply> GetReplies()
        {
            var Replies = new ObservableCollection<Reply>();
            return Replies;
        }
    }
}
