using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	/// <summary>
	/// Classe qui réprésente l'exam
	/// </summary>
    public class Exam
    {
		private float score;

		/// <summary>
		/// avoir le score
		/// </summary>
		public float Score
		{
			get { return score; }
			set 
			{
				if (value >= 0 && value <= 20)
					score = value;
				else
					throw new Exception("Le score doit être compris entre 0 et 20");
			}
		}
		private string teacher;

		/// <summary>
		/// avoir le prof
		/// </summary>
		public string Teacher
		{
			get { return teacher; }
			set { teacher = value; }
		}
		private DateTime dateExam;

		/// <summary>
		/// avoir la date
		/// </summary>
		public DateTime DateExam
		{
			get { return dateExam; }
			set 
			{
				if (value == null || value.CompareTo(DateTime.Today) > 0)
					throw new Exception("La date n'est pas valide");
				else
					dateExam = value;
			}
		}
		private int coef;

		/// <summary>
		/// avoir le coef
		/// </summary>
		public int Coef
		{
			get { return coef; }
			set 
			{
				if (value >= 1 && value <= 100)
					coef = value;
				else
					throw new Exception("Le coefficient n'est pas valide");
			}
		}
		private Course course;
		public Course Course => course;

		/// <summary>
		/// constructeur de la classe
		/// </summary>
		/// <param name="c"></param>
		public Exam(Course c)
		{
			this.course = c;
		}

		/// <summary>
		/// ToString pour l'affichage 
		/// </summary>
		/// <returns></returns>
        public override string ToString()
        {
			return String.Format("({0}) {1} - {2} | {3}", coef.ToString(), score.ToString(), teacher, dateExam.ToString());
        }
    }
}
