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

        /// <summary>
        /// constructeur de la classe NoteBook
        /// </summary>
        /// <param name="dao"></param>
        public Notebook(ICourseDao dao)
        {
            this.dao = dao;
        }

    }
}
