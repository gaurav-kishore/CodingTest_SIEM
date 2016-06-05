using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace SiemensTest
{
    class ViewModelBase:INotifyPropertyChanged
    {
        public void NotifyPropertyChanged(string PropertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    class TestAppViewModel:ViewModelBase
    {
        #region Fields
        private long _age;
        private string _id;
        private string _name;
        private ObservableCollection<User> _userList;
        #endregion Fields

        #region Ctor
        public TestAppViewModel()
        {
            _userList = new ObservableCollection<User>();
            _addUser = new Commands(ExecuteAddUser, CanExecuteAddUser);
        }
        #endregion Ctor

        #region Properties
        public long Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value > 0)
                {
                    _age = value;
                    NotifyPropertyChanged("Age");
                }
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }

            set
            {
                if((value != null) && (value != string.Empty))
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if ((value != null) && (value != string.Empty))
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public ObservableCollection<User> UserList
        {
            get
            {
                return _userList;
            }
        }
        #endregion Properties

        #region Commands
        private ICommand _addUser;
        
        public ICommand AddUserCommand
        {
            get
            {
                return _addUser;
            }
        }
        
        #endregion Commands

        #region Command Methods
        private bool CanExecuteAddUser(object parameter)
        {
            if((ID != string.Empty) && (ID != null))
            {
                if(Age > 0)
                {
                    if((Name != string.Empty) && (Name != null))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void ExecuteAddUser(object parameter)
        {
            _userList.Add(new User(ID, Name, Age));
        }
        #endregion Command Methods
    }
}
