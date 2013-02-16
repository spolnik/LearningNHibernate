namespace ACME.Repository
{
    public interface IRepository<TD, in TK> where TD : class 
    {
        TD GetById(TK id);
        void Save(TD saveObj);
        void Delete(TD delObj);
    }
}