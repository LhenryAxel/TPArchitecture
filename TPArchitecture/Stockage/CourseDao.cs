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
        /// Reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Course Reader2Course(SQLiteDataReader reader)
        {
            Course prof = new Course(this, true);
            prof.Code = reader["Code"].ToString();
            prof.Name = reader["Name"].ToString();
            prof.Weight = Convert.ToString(reader["Weight"]);
            return prof;
        }

        /// <summary>
        /// Recupere toutes les courses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Course> GetAll()
        {
            connection.Open();
            List<Course> courses = new List<Course>();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Course";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    courses.Add(Reader2Course(reader));
                }
            }
            connection.Close();
            return courses;
        }

        /// <summary>
        /// Méthode create
        /// </summary>
        /// <param name="course"></param>
        public void Create(Course course)
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Course(Code,Name,Weight) VALUES('" + course.Code + "','" + course.Name + "'," + course.Weight.ToString() + ");";
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Methode read
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Course Read(string code)
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = code;
            return Reader2Course(command.ExecuteReader());
        }

        /// <summary>
        /// Méthode update 
        /// </summary>
        /// <param name="t"></param>
        public void Update(Course t)
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Course SET Name='" + t.Name + "', Weight = " + t.Weight.ToString() + " WHERE Code='" + t.Code + "';";
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Méthode Suprimme qui supprime un cour
        /// </summary>
        /// <param name="t"></param>
        public void Delete(Course t)
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Course WHERE Code='" + t.Code + "';";
            command.ExecuteNonQuery();
            connection.Close();
        }


        /// <summary>
        /// Liste les cours 
        /// </summary>
        /// <returns></returns>
        public Course[] ListAll()
        {
            connection.Open();
            List<Course> courses = new List<Course>();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Course";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    courses.Add(Reader2Course(reader));
                }
            }
            connection.Close();
            return courses.ToArray();
        }
    }
}
