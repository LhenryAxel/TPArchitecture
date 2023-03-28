using Logic;
using Storage;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HMI
{
    /// <summary>
    /// Logique d'interaction pour CoursesScreen.xaml
    /// </summary>
    public partial class CoursesScreen : Window
    {
        private Notebook notebook;

        /// <summary>
        /// constructeur de la fenetre 
        /// </summary>
        /// <param name="notebook"></param>
        public CoursesScreen(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            DrawCourses();
        }

        /// <summary>
        /// affichage des Cours
        /// </summary>
        private void DrawCourses()
        {
            Course[] courses = this.notebook.ListAll();
            foreach (Course course in courses)
            {
                coursesList.Items.Add(course);
            }
        }

        /// <summary>
        /// Suprimmer un Cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveCourse(object sender, RoutedEventArgs e)
        {
            if (coursesList.SelectedItem != null)
            {
                this.notebook.RemoveCourse((Course)coursesList.SelectedItem);
            }
            coursesList.Items.Remove(coursesList.SelectedItem);
        }

        /// <summary>
        /// Ajouter un cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add(object sender, RoutedEventArgs e)
        {
            Course course = new Course(new CourseDao("C:/Users/al425221/source/repos/TPArchitecture/BDD.db"), false);
            course = this.notebook.AddCourse(course);
            EditCourse courseScreen = new EditCourse(course);
            courseScreen.Show();
            this.Close();
        }


        /// <summary>
        /// Modifier un Cour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyCourse(object sender, RoutedEventArgs e)
        {
            if (coursesList.SelectedItem != null)
            {
                Course courseSelected = (Course)coursesList.SelectedItem;
                EditCourse courseScreen = new EditCourse(courseSelected);
                courseScreen.Show();
            }
        }

        /// <summary>
        /// Update les infos d'un cour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInfo(object sender, EventArgs e)
        {
            coursesList.Items.Clear();
            notebook.UpdateCourse(((EditCourse)sender).course);
            this.DrawCourses();
        }

    }
}
