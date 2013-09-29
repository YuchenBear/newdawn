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
using System.ComponentModel;
using WotWforum.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace WotWforum.ViewModel
{
    public class TopicViewModel : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private TopicContext topicDB;

        // Class constructor, create the data context object.
        public TopicViewModel(string topicDBConnectionString)
        {
            topicDB = new TopicContext(topicDBConnectionString);
        }

        // All the topics.
        private ObservableCollection<Topics> _hottestTopics;
        public ObservableCollection<Topics> HottestTopics
        {
            get { return _hottestTopics; }
            set
            {
                _hottestTopics = value;
                NotifyPropertyChanged("HottestTopics");
            }
        }

        // Topics associated with the date category.
        private ObservableCollection<Topics> _dateTopics;
        public ObservableCollection<Topics> DateTopics
        {
            get { return _dateTopics; }
            set
            {
                _dateTopics = value;
                NotifyPropertyChanged("DateTopics");
            }
        }

        // Topics associated with the nearby category.
        private ObservableCollection<Topics> _nearbyTopics;
        public ObservableCollection<Topics> NearbyTopics
        {
            get { return _nearbyTopics; }
            set
            {
                _nearbyTopics = value;
                NotifyPropertyChanged("NearbyTopics");
            }
        }

        // Topics associated with the @ category.
        private ObservableCollection<Topics> _atTopics;
        public ObservableCollection<Topics> AtTopics
        {
            get { return _atTopics; }
            set
            {
                _atTopics = value;
                NotifyPropertyChanged("AtTopics");
            }
        }

        // A list of all categories, used by the add topic page.
        private List<TopicCategory> _categoriesList;
        public List<TopicCategory> CategoriesList
        {
            get { return _categoriesList; }
            set
            {
                _categoriesList = value;
                NotifyPropertyChanged("CategoriesList");
            }
        }

        // Write changes in the data context to the database.
        public void SaveChangesToDB()
        {
            topicDB.SubmitChanges();
        }

        // Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {

            // Specify the query for all topics in the database.
            var TopicsInDB = from Topics topic in topicDB.Topics
                             select topic;

            // Query the database and load all topics.
            HottestTopics = new ObservableCollection<Topics>(TopicsInDB);

            // Specify the query for all categories in the database.
            var topicCategoriesInDB = from TopicCategory category in topicDB.Categories
                                      select category;


            // Query the database and load all associated topics to their respective collections.
            foreach (TopicCategory category in topicCategoriesInDB)
            {
                switch (category.Name)
                {
                    case "Date":
                        DateTopics = new ObservableCollection<Topics>(category.Alltopics);
                        break;
                    case "Nearby":
                        NearbyTopics = new ObservableCollection<Topics>(category.Alltopics);
                        break;
                    case "@":
                        AtTopics = new ObservableCollection<Topics>(category.Alltopics);
                        break;
                    default:
                        break;
                }
            }

            // Load a list of all categories.
            CategoriesList = topicDB.Categories.ToList();

        }

        // Add a topic to the database and collections.
        public void AddTopic(Topics newTopic)
        {
            // Add a topic to the data context.
            topicDB.Topics.InsertOnSubmit(newTopic);

            // Save changes to the database.
            topicDB.SubmitChanges();

            // Add a topic to the "all" observable collection.
            HottestTopics.Add(newTopic);

            // Add a topic to the appropriate filtered collection.
            switch (newTopic.Category.Name)
            {
                case "Date":
                    DateTopics.Add(newTopic);
                    break;
                case "Nearby":
                    NearbyTopics.Add(newTopic);
                    break;
                case "@":
                    AtTopics.Add(newTopic);
                    break;
                default:
                    break;
            }
        }

        // Remove a topic from the database and collections.
        public void DeleteTopic(Topics topicForDelete)
        {

            // Remove the topic from the "all" observable collection.
            HottestTopics.Remove(topicForDelete);

            // Remove the topic from the data context.
            topicDB.Topics.DeleteOnSubmit(topicForDelete);

            // Remove the topic from the appropriate category.   
            switch (topicForDelete.Category.Name)
            {
                case "Date":
                    DateTopics.Remove(topicForDelete);
                    break;
                case "Nearby":
                    NearbyTopics.Remove(topicForDelete);
                    break;
                case "@":
                    AtTopics.Remove(topicForDelete);
                    break;
                default:
                    break;
            }

            // Save changes to the database.
            topicDB.SubmitChanges();
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
