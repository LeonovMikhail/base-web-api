using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Domain.Models;

namespace WebApp.DAL.Repository
{
    public interface IUserRepository : IRepository<UserModel>
    {
        Task<IEnumerable<UserModel>> GetAll();
    }
}