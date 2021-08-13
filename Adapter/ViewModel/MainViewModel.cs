using Adapter.Adapter;
using Adapter.Command;
using Adapter.Model;
using Adapter.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Adapter.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
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




        public ObservableCollection<User> Users { get; set; }

        private User _user;

        public User User { get { return _user; } set { _user = value; OnpropertyChanged(); } }


        public RelayCommand SaveCommand { get; set; }

        public MainWindow MainWindows { get; set; }



        public MainViewModel()
        {
            XML XML_File = new XML();
            JSON JSON_File = new JSON();


            if (XML_File.User_List == null)
            {
                XML_File.User_List = new ObservableCollection<User>();
            }

            if (JSON_File.User_List == null)
            {
                JSON_File.User_List = new ObservableCollection<User>();
            }










            SaveCommand = new RelayCommand((e) =>
            {
                IAdapter adapter;


                if (Helper.Helper.mainWindow.XMLChkBox.IsChecked == true)
                {



                    try
                    {

                        if (XML_File.User_List == null)
                        {

                            XML_File.User_List.Add(new User()
                            {
                                Name = Helper.Helper.mainWindow.NameTxtBox.Text,
                                Surname = Helper.Helper.mainWindow.SurnameTxtBox.Text,
                                Email = Helper.Helper.mainWindow.EmailTxtBox.Text,
                                

                            });

                            XML_File.User_List.RemoveAt(0);

                            adapter = new XMLAdapter(XML_File);

                            Application1 application = new Application1(adapter);

                            application.Start();
                        }

                        if (XML_File.User_List != null)
                        {
                            XML_File.User_List.Add(new User()
                            {
                                Name = Helper.Helper.mainWindow.NameTxtBox.Text,
                                Surname = Helper.Helper.mainWindow.SurnameTxtBox.Text,
                                Email = Helper.Helper.mainWindow.EmailTxtBox.Text,


                            });

                            adapter = new XMLAdapter(XML_File);

                            Application1 application = new Application1(adapter);

                            application.Start();
                            MessageBox.Show("Sucsesfully!");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                }


                if (Helper.Helper.mainWindow.JSONChkBox.IsChecked == true)
                {



                    try
                    {

                        if (JSON_File.User_List == null)
                        {

                            JSON_File.User_List.Add(new User()
                            {
                                Name = Helper.Helper.mainWindow.NameTxtBox.Text,
                                Surname = Helper.Helper.mainWindow.SurnameTxtBox.Text,
                                Email = Helper.Helper.mainWindow.EmailTxtBox.Text,


                            });

                            JSON_File.User_List.RemoveAt(0);

                            adapter = new JsonAdapter(JSON_File);

                            Application1 application = new Application1(adapter);

                            application.Start();
                        }

                        if (JSON_File.User_List != null)
                        {
                            JSON_File.User_List.Add(new User()
                            {
                                Name = Helper.Helper.mainWindow.NameTxtBox.Text,
                                Surname = Helper.Helper.mainWindow.SurnameTxtBox.Text,
                                Email = Helper.Helper.mainWindow.EmailTxtBox.Text,


                            });

                            adapter = new JsonAdapter(JSON_File);

                            Application1 application = new Application1(adapter);

                            application.Start();
                            MessageBox.Show("Sucsesfully!");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                }

            });



        }
    }
}
