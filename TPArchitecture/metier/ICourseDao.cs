using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// interface ICourseDao
    /// </summary>
    public interface ICourseDao
    {
        /// <summary>
        /// interface Create
        /// </summary>
        /// <param name="course"></param>
        void Create(Course course);

        /// <summary>
        /// interface Read
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Course Read(string code);

        /// <summary>
        /// interface Update
        /// </summary>
        /// <param name="t"></param>
        void Update(Course t);

        /// <summary>
        /// interface Delete
        /// </summary>
        /// <param name="t"></param>
        void Delete(Course t);

    }
}
