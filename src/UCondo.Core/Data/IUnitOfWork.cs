using System.Threading.Tasks;

namespace UCondo.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}