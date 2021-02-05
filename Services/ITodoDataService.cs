using System.Collections.Generic;
using System.Threading.Tasks;
using TodoClient.Models;

namespace TodoClient.Services
{
    public interface ITodoDataService
    {
        Task<IEnumerable<ItemData>> GetAllItems();

        Task<ItemData> GetItemDetail(int id);
    }
}