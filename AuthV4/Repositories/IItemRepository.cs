using AuthV4.Models.Domain;
using AuthV4.Models.Dto;

namespace AuthV4.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItems();

        Task<Item?> GetByIdAsync(string id);

        Task<Item?> CreateItemAsync(Item itemModel);

        Task<Item?> UpdateItemAsync(string id, UpdateItemDto updateItemDto);

        Task<Item?> DeleteItemAsync(string id);
    }
}
