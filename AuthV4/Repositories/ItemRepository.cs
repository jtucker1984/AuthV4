using AuthV4.Data;
using AuthV4.Models.Domain;
using AuthV4.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace AuthV4.Repositories
{
    public class ItemRepository : IItemRepository
    {
       
        private readonly BuzzDbContextXl buzzDbContext;

        public ItemRepository( BuzzDbContextXl buzzDbContext)
        {
            this.buzzDbContext = buzzDbContext; 
           
        }
       
        public async Task<Item?> CreateItemAsync(Item itemModel)
        {
            await buzzDbContext.Items.AddAsync(itemModel);
            await buzzDbContext.SaveChangesAsync();
            return itemModel;
        }

        public async Task<Item?> DeleteItemAsync(string id)
        {
            var existingItem = await buzzDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (existingItem == null) 
            {

                return null;
            }
            buzzDbContext.Items.Remove(existingItem);
            await buzzDbContext.SaveChangesAsync();
            return existingItem;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await buzzDbContext.Items.ToListAsync();
        }

        public Task<Item?> GetByIdAsync(string id)
        {
            return buzzDbContext.Items.FirstOrDefaultAsync(x=>x.Id == id);  
        }

        public async Task<Item?> UpdateItemAsync(string id, UpdateItemDto updateItemDto)
        {
            var existingItem = await buzzDbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(existingItem == null) 
            {

                return null;
            }
           
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;
            existingItem.ItemUrl = updateItemDto.ItemUrl;
            existingItem.Weight = updateItemDto.Weight;
            existingItem.Type = updateItemDto.Type;
            existingItem.Name = updateItemDto.Name;
            await buzzDbContext.SaveChangesAsync();
            return existingItem;
        }
    }
}
