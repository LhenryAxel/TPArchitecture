using Logic;
using System;
using System.Data.SQLite;

namespace Storage
{
    /// <summary>
    /// Classe ExamDao
    /// </summary>
    public class ExamDao : IExamDao
    {
        private SQLiteConnection connection;

        /// <summary>
        /// constructeur de la classe
        /// </summary>
        /// <param name="file"></param>
        public ExamDao(string file) 
        {
            this.connection = new SQLiteConnection(@"DataSource=" + file);
        }

        /// <summary>
        /// cree les exams dans la bdd
        /// </summary>
        /// <param name="exam"></param>
        public void Create(Exam exam)
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = String.Format("INSERT INTO Exam(Score, Teacher, Date, Coef, CourseCode) VALUES({0},'{1}','{2}',{3},'{4}');",
                                                exam.Score, exam.Teacher, exam.DateExam, exam.Coef, exam.Course.Code);
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// List des exams
        /// </summary>
        /// <returns></returns>
        public Exam[] ListAll()
        {
            connection.Open();
            List<Exam> exams = new List<Exam>();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Exam JOIN Course ON Course.Code = Exam.CourseCode;";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    exams.Add(Reader2Exam(reader));
                }
            }
            connection.Close();
            return exams.ToArray();
        }

        /// <summary>
        /// Méthode update qui met a jour la table exam
        /// </summary>
        /// <param name="t"></param>
        public void Update(Exam t)
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Exam SET Score='" + t.Score + "', Teacher = " + t.Teacher.ToString() + "', DateExam = " + t.DateExam + "', Coef = " + t.Coef + " WHERE CourseCode='" + t.Course + "';";
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// reader de Exam
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Exam Reader2Exam(SQLiteDataReader reader)
        {
            Course course = new Course(new CourseDao("C:/Users/al425221/source/repos/TPArchitecture/BDD.db"), true);
            Exam exam = new Exam(course);
            exam.Score = Convert.ToSingle(reader["Score"]);
            exam.Coef = Convert.ToInt16(reader["Coef"]);
            exam.Teacher = reader["Teacher"].ToString();
            //exam.DateExam = DateTime.Parse(reader.GetDateTime(3).ToString());
            return exam;
        }
    }
}