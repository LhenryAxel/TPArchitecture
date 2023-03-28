namespace Logic
{
    public interface IExamDao
    {
        /// <summary>
        /// permet de cree un exam
        /// </summary>
        /// <param name="exam"></param>
        void Create(Exam exam);
        /// <summary>
        /// Liste les exam
        /// </summary>
        /// <returns></returns>
        Exam[] ListAll();

        /// <summary>
        /// interface Update
        /// </summary>
        /// <param name="t"></param>
        void Update(Exam t);
    }
}