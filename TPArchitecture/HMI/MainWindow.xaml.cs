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

        /// <summary>
        /// Constructeur de la fenetre
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            courseDao = new CourseDao("C:/Users/al425221/source/repos/TPArchitecture/BDD.db");
            notebook = new Notebook(courseDao);
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
    }
}
