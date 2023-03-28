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
    /// Logique d'interaction pour EditExam.xaml
    /// </summary>
    public partial class EditExam : Window
    {
        public Exam exam;
        private Notebook notebook;
        public EditExam(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            foreach (Course course in notebook.ListAll())
            {
                listCourse.Items.Add(course);
            }
            
        }

        /// <summary>
        /// bouton close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, RoutedEventArgs e)
        {
            if (listCourse.SelectedItem != null)
            {
                Exam exam = new Exam((Course)listCourse.SelectedItem);
                exam.Teacher = teacherName.Text;
                exam.Score = Convert.ToInt16(score.Text);
                exam.Coef = Convert.ToInt16(coef.Text);
                exam.DateExam = (DateTime)dateBox.SelectedDate;
                this.notebook.CreateExam(exam);
                this.Close();
            }
        }
    }
}
