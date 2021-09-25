using FNS.CRUDService.Model;
using System.Threading.Tasks;

namespace FNS.CRUDService.Interfaces
{
    public interface IBaseDomainService<T>
    {
        Task<ServiceResponse<T>> Create(T entity);
        Task<ServiceResponse<PagingResult>> List(PagingQuery pagingQuery);
        Task<ServiceResponse<T>> Get(int id);
        Task<ServiceResponse<int>> Update(T entity);
        Task<ServiceResponse<int>> Delete(int id);
    }
}
