using Logic;
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
    /// Logique d'interaction pour EditCourse.xaml
    /// </summary>
    public partial class EditCourse : Window
    {
        public Course course;

        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        /// <param name="course"></param>
        public EditCourse(Course course)
        {
            InitializeComponent();
            this.course = course;
            this.DataContext = course;
            course.Update();
        }

        /// <summary>
        /// Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
            course.Update();
        }

        /// <summary>
        /// Bouton Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok(object sender, RoutedEventArgs e)
        {
            course.Code = this.Code.Text;
            course.Name = this.Name.Text;
            course.Weight = this.Weight.Text;
            this.Close();
        }
    }
}
