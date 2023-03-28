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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HMI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Notebook notebook;
        private CourseDao courseDao;
        private ExamDao examDao;

        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            courseDao = new CourseDao("C:/Users/al425221/source/repos/TPArchitecture/BDD.db");
            examDao = new ExamDao("C:/ Users / al425221 / source / repos / TPArchitecture / BDD.db");
            notebook = new Notebook(courseDao, examDao);
        }

        /// <summary>
        /// Ouvre la fenetre CoursesScreen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Course(object sender, RoutedEventArgs e)
        {
            CoursesScreen coursesScreen = new CoursesScreen(this.notebook);
            coursesScreen.Show();
            this.Close();
        }

        /// <summary>
        /// ouvre le ExamsScreen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenExamsScreen(object sender, RoutedEventArgs e)
        {
            ExamsScreen screen = new ExamsScreen(this.notebook);
            screen.Show();
            this.Close();
        }

        /// <summary>
        /// Permet d'appeler la méthode Calculate de notebook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculate(object sender, RoutedEventArgs e)
        {
            double average = notebook.Calculate();
            MessageBox.Show(average.ToString());
        }
    }
}
