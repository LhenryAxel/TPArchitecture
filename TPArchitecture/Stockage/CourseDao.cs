using Logic;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Classe CourseDao
    /// </summary>
    public class CourseDao : ICourseDao
    {
        private SQLiteConnection connection;

        /// <summary>
        /// Constructeur de la classe CourseDao
        /// </summary>
        /// <param name="fileName"></param>
        public CourseDao(string fileName)
        {
            connection = new SQLiteConnection(@"DataSource=" + fileName);
        }


        /// <summary>
        /// Méthode create
        /// </summary>
        /// <param name="course"></param>
        public void Create(Course course)
        {

        }

        /// <summary>
        /// Methode read
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Course Read(string code)
        {

        }

        /// <summary>
        /// Méthode update 
        /// </summary>
        /// <param name="t"></param>
        public void Update(Course t)
        {

        }

        /// <summary>
        /// Méthode Suprimme qui supprime un cour
        /// </summary>
        /// <param name="t"></param>
        public void Delete(Course t)
        {

        }
    }
}
