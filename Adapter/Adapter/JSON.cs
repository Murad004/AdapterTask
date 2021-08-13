using Adapter.Model;
using Adapter.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapter
{
    public class JSON : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<User> _User_List { get; set; }
        public ObservableCollection<User> User_List { get { return _User_List; } set { _User_List = value; OnpropertyChanged(); } }


        private User _user;

        public User User { get { return _user; } set { _user = value; OnpropertyChanged(); } }


        public MainWindow MainWindows { get; set; }

        public MainViewModel MainViewModels { get; set; }

        public JSON()
        {

        }



        public void JSON_Serialize()
        {



            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($@"User.json", true))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, User_List);
                }
            }

        }

        public void JSON_Deserialize()
        {
            User[] users = null;
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader($@"User.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    users = serializer.Deserialize<User[]>(jr);
                }

            }
        }
    }
}
