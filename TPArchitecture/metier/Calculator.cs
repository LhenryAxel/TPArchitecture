using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Calculator
    {
        private List<Course> courses;
        private List<Exam> exams;

        /// <summary>
        /// avoir la moyenne 
        /// </summary>
        public double Average 
        {
            get
            {
                int count = 0;
                double avg = 0;
                //Calculer la moyenne
                foreach (var course in courses)
                {
                    List<Exam> exams = new List<Exam>();
                    foreach (var examen in exams)
                    {
                        if (examen.Course.Code == course.Code)
                        {
                            exams.Add(examen);
                        }
                    }
                    count += Convert.ToInt16(course.Weight);
                    avg += course.Calculate(exams.ToArray());
                }
                return avg / count;
            }
        }

        /// <summary>
        /// constructeur de la classe
        /// </summary>
        /// <param name="courses"></param>
        /// <param name="exams"></param>
        public Calculator(Course[] courses, Exam[] exams)
        {
            this.courses = courses.ToList();
            this.exams = exams.ToList();
            
        }
    }
}
