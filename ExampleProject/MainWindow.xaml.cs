using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace ExampleProject
{


    public partial class MainWindow : Window
    {

        private StudentList student_list;
        private Student StudentFromList;
        private Student TempStudent;
        private StudentDB studentDB;

        public MainWindow()
        {

            InitializeComponent();
            //this.DataContext = this;

            StudentDB = new StudentDB();
            StudentList = StudentDB.SelectAll(); //a method, not a static member
            StudentsListView.ItemsSource = StudentList;

            //MessageBox.Show(StudentList.Count.ToString());

            TelephonePrefixList lst = TelephonePrefix.GetAllPrefixes();
            //MessageBox.Show(lst[0].Prefix);
            TelephonePrefixCbox.ItemsSource = lst;
            
            CityCbox.ItemsSource = CityDB.SelectAll();


            /*
                        City c = new City();
                        c.Id = 2;
                        c.Name = "Jerusalem";

                        Student s = new Student();
                        s.FirstName = "Dani";
                        s.LastName = "Danon";
                        s.City = c;
                        s.Semester = 6;
                        s.Telephone = 223322;

                        StudentDB sdb = new StudentDB();
                        sdb.insert(s);
                        sdb.saveChanges();
            */



            /*
                        string ss = "";
                        foreach (TelephonePrefix tp in lst)
                            ss += (" " + tp.ToString());
            */
            //MessageBox.Show(ss);
            //MessageBox.Show((TelephonePrefix.of("050") == TelephonePrefix.of("052")).ToString());

        }

        public StudentList StudentList
        {
            get { return student_list; }
            set { student_list = value; }
        }

        private StudentDB StudentDB { get => studentDB; set => studentDB = value; }


        private void StudentsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentFromList = this.StudentsListView.SelectedItem as Student;


            if (StudentFromList == null)
                this.message.Text = "please select a student";
            else
            {
                this.message.Text = "student" + StudentFromList.ToString();
                StudentFromList.City = CityDB.SelectAll().Find(c => c.Id == StudentFromList.City.Id);

                this.TempStudent = (Student)StudentFromList.Clone();
                this.details.DataContext = null;  // force refresh
                this.details.DataContext = TempStudent;
            }


        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (TempStudent.Id == 0) // insert
            {
                this.StudentDB.insert(TempStudent);
                int result = this.StudentDB.saveChanges();

                if (result == 0)   //ERROR
                { 
                    MessageBox.Show("Error in Insert !");
                }
                else
                {
                    this.StudentList.Add(TempStudent);
                    RefreshStudentList();
                }
            }
            else //update  
            {

                StudentFromList.FirstName = TempStudent.FirstName;
                StudentFromList.LastName = TempStudent.LastName;
                StudentFromList.City = TempStudent.City;
                StudentFromList.Telephone = TempStudent.Telephone;
                StudentFromList.TelephonePrefix = TempStudent.TelephonePrefix;
                RefreshStudentList();
                //StudentFromList = StudentList.Find(st => st.Id == TempStudent.Id); // for some strange reason, after RefreshStudentList(), StudentFromList becomes null !!!
                //MessageBox.Show(StudentFromList == null?"is null":"is not null");

                //StudentFromList = this.StudentsListView.SelectedItem as Student;


                //user = this.lstView2.SelectedItem as User;
                //int x = srv.UpdateAtDB(user);
                //if (x == 0)   //ERROR
                //{ MessageBox.Show("Error in delete !"); }
                //else
                {
                    // .....
                }
            }

            //TempStudent = new Student();
            //this.details.DataContext = null;  // force refresh
            //this.details.DataContext = TempStudent;
        }

        private void NewStudent_Button_Click(object sender, RoutedEventArgs e)
        {
            TempStudent = new Student();
            this.details.DataContext = null;  // force refresh
            this.details.DataContext = TempStudent;
        }

        private void RefreshStudentList()
        {
            //StudentsListView.ItemsSource = null;  // force refresh
            //StudentsListView.ItemsSource = StudentList;

            //smart refresh: does not free listview resources (like stupid refresh above, who doesn't let me do a simple save)
            ICollectionView view = CollectionViewSource.GetDefaultView(StudentsListView.ItemsSource);
            view.Refresh();


            //System.Collections.IEnumerable temp = StudentsListView.ItemsSource;
            //StudentsListView.ItemsSource = null;
            //StudentsListView.ItemsSource = temp;


        }


    }
}
