using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Classe Notebook
    /// </summary>
    public class Notebook
    {
        private ICourseDao dao;
        private IExamDao examDao;

        /// <summary>
        /// constructeur de la Classe
        /// </summary>
        /// <param name="dao"></param>
        public Notebook(ICourseDao dao)
        {
            this.dao = dao;
        }

        /// <summary>
        /// permet de suprimmer un cour
        /// </summary>
        /// <param name="t"></param>
        public void RemoveCourse(Course t)
        {
            this.dao.Delete(t);
        }

        /// <summary>
        /// permet d'ajouter un cour 
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public Course AddCourse(Course course)
        {
            this.dao.Create(course);
            return course;
        }

        /// <summary>
        /// permet d'update un cour
        /// </summary>
        /// <param name="course"></param>
        public void UpdateCourse(Course course)
        {
            this.dao.Update(course);
        }

        /// <summary>
        /// permet de lister les cours
        /// </summary>
        /// <returns></returns>
        public Course[] ListAll()
        {
            return this.dao.ListAll();
        }

        /// <summary>
        /// permet de créer l'exam
        /// </summary>
        /// <param name="exam"></param>
        public void CreateExam(Exam exam)
        {
            this.examDao.Create(exam);
        }

        /// <summary>
        /// permet d'obtenir l'exam
        /// </summary>
        /// <returns></returns>
        public Exam[] GetExams()
        {
            return this.examDao.ListAll();
        }

        /// <summary>
        /// permet de calculer les moyennes de cours et exam
        /// </summary>
        /// <returns></returns>
        public double Calculate()
        {
            Exam[] exams = this.examDao.ListAll();
            Course[] courses = this.dao.ListAll();
            Calculator calculator = new Calculator(courses, exams);
            return calculator.Average;
        }
    }
}
