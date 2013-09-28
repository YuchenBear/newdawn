using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace sdkLocalDatabaseCS.Model
{
    public class TopicContext:DataContext
    {
        public TopicContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the topics.
        public Table<Topics> Topics;

        // Specify a table for the categories.
        public Table<TopicCategory> Categories;
    }

    [Table]
    public class Topics: INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _topicId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, 
                AutoSync = AutoSync.OnInsert)]

        public int TopicId
        {
            get { return _topicId; }
            set
            {
                if (_topicId != value)
                {
                    NotifyPropertyChanging("TopicId");
                    _topicId = value;
                    NotifyPropertyChanged("TopicId");
                }
            }
        }

        // Define topic title: private field, public property, and database column.
        private string _title;

        [Column]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    NotifyPropertyChanging("Title");
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        // Define like: private field, public property, and database column.
        private bool _like;

        [Column]
        public bool Like
        {
            get { return _like; }
            set
            {
                if (_like != value)
                {
                    NotifyPropertyChanging("Like");
                    _like = value;
                    NotifyPropertyChanged("Like");
                }
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;


        // Internal column for the associated Topic Category ID value
        [Column]
        internal int _categoryId;

        // Entity reference, to identify the Topic Category "storage" table
        private EntityRef<TopicCategory> _category;

        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "_category", ThisKey = "_categoryId", OtherKey = "Id", IsForeignKey = true)]
        public TopicCategory Category
        {
            get { return _category.Entity; }
            set
            {
                NotifyPropertyChanging("Category");
                _category.Entity = value;

                if (value != null)
                {
                    _categoryId = value.Id;
                }

                NotifyPropertyChanging("Category");
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

    [Table]
    public class TopicCategory : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _id;

        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            get { return _id; }
            set
            {
                NotifyPropertyChanging("Id");
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        // Define category name: private field, public property, and database column.
        private string _name;

        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                NotifyPropertyChanging("Name");
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        // Define the entity set for the collection side of the relationship.
        private EntitySet<Topics> _alltopics;

        [Association(Storage = "_alltopics", OtherKey = "_categoryId", ThisKey = "Id")]
        public EntitySet<Topics> Alltopics
        {
            get { return this._alltopics; }
            set { this._alltopics.Assign(value); }
        }


        // Assign handlers for the add and remove operations, respectively.
        public TopicCategory()
        {
            _alltopics = new EntitySet<Topics>(
                new Action<Topics>(this.attach_Topic),
                new Action<Topics>(this.detach_Topic)
                );
        }

        // Called during an add operation
        private void attach_Topic(Topics topic)
        {
            NotifyPropertyChanging("Topics");
            topic.Category = this;
        }

        // Called during a remove operation
        private void detach_Topic(Topics topic)
        {
            NotifyPropertyChanging("Topics");
            topic.Category = null;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}


       


