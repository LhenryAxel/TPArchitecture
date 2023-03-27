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
        }

        /// <summary>
        /// Suprimmer un Cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveCourse(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Ajouter un cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add(object sender, RoutedEventArgs e)
        {
        }

    }
}
