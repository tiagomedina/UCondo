using System.Threading.Tasks;

namespace UCondo.Domain.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}