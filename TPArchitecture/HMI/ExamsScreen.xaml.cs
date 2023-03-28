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
    /// Logique d'interaction pour ExamsScreen.xaml
    /// </summary>
    public partial class ExamsScreen : Window
    {
        private Notebook notebook;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="notebook"></param>
        public ExamsScreen(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            DrawExams();
        }
        
        /// <summary>
        /// DrawExams
        /// </summary>
        private void DrawExams()
        {
            examsList.Items.Clear();
            Exam[] exams = this.notebook.GetExams();
            foreach (Exam exam in exams)
            {
                examsList.Items.Add(exam);
            }
        }


        /// <summary>
        /// cree un exam
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateExam(object sender, RoutedEventArgs e)
        {
            EditExam screen = new EditExam(this.notebook);
            screen.Show();
            screen.Closed += UpdateInfo;
        }

        /// <summary>
        /// Update les infos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInfo(object sender, EventArgs e)
        {
            examsList.Items.Clear();
            this.DrawExams();
        }
    }
}
