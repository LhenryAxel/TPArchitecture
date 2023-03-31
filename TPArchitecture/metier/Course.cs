using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Classe Course
    /// </summary>
    public class Course
    {
        private string name;
        private string weight;
        private string code;
        private ICourseDao courseDao;
        private bool exist;


        /// <summary>
        /// nom de la matiere
        /// </summary>
        public string Name   // property
        {
            get { return name; }   // get method
            set   // set method
            {
                if (value == null)
                {
                    throw new Exception("attention valeur null");
                }
                else
                {
                    name = value;
                }
            }
        }

        /// <summary>
        /// code de la matiere
        /// </summary>
        public string Code   // property
        {
            get { return code; }   // get method
            set  // set method
            {
                if(value == null)
                {
                    throw new Exception("attention valeur null");
                }
                else
                {
                    code = value;
                }
            }  
        }

        /// <summary>
        /// Coefficient de la matiere
        /// </summary>
        public string Weight   // property
        {
            get { return code; }   // get method
            set   // set method
            {
                if (Convert.ToInt32(value) < 1 || Convert.ToInt32(value) > 100)
                {
                    throw new Exception("Attention la valeur doit etre compris entre 1 et 100");
                }
                else
                {
                    weight = value;
                }
            }
        }

        /// <summary>
        /// To string de l'affichage
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Code + "." + Name + "(" + Weight + ")";
        }

        /// <summary>
        /// Méthode qui permet de vérfier que la course existe bien
        /// </summary>
        /// <param name="dao"></param>
        /// <param name="exist"></param>
        public Course(ICourseDao dao, bool exist)
        {
            this.courseDao = dao;
            this.exist = exist;
        }

        /// <summary>
        /// Si existe deja alors on appelle update, sinon on appelle create
        /// </summary>
        public void Update()
        {
            if (exist)
            {
                this.courseDao.Update(this);
            }
            else
            {
                this.courseDao.Create(this);
            }
        }

        // <summary>
        // Calcul de la moyenne des exams
        // </summary>
        // <param name = "exams" ></ param >
        // < returns ></ returns >
        public double Calculate(Exam[] exams)
        {
            double sum = 0;
            int count = 0;
            foreach (Exam exam in exams)
            {
                count = count + exam.Coef;
                sum = sum + exam.Score * exam.Coef;
            }
            return sum / count;
        }
    }
}
