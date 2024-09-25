using AuthV4.Models.Domain;
using AuthV4.Models.Dto;
using AuthV4.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthV4.Controllers
{
    [Route("api/itemController")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IItemRepository repository;
        public ItemController(IMapper mapper, IItemRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
           
        }
        [Authorize (Roles = "Reader")]
        [HttpGet]
       
        public async Task<IActionResult> GetAllItems() 
        {
            var itemsDomain = await repository.GetAllItems();

            var itemDto = mapper.Map<List<ItemDto>>(itemsDomain);

            return Ok(itemDto);
        
        }

        [HttpGet("{id:Guid}")]
        public async Task <IActionResult> GetItemById(string id) 
        {
            var itemDomain = await repository.GetByIdAsync(id);
            if(itemDomain == null) 
            {
                return NotFound();
            }
            return Ok(mapper.Map<ItemDto>(itemDomain));
        
        }

        [HttpPost]
        public async Task <IActionResult> CreateItem([FromBody] AddItemDto addItemDto) 
        {
            var itemDomain = mapper.Map<Item>(addItemDto);
            itemDomain = await repository.CreateItemAsync(itemDomain);
            var dto = mapper.Map<ItemDto>(itemDomain);

            return CreatedAtAction(nameof(GetItemById), new {id = dto.Id }, dto);   
        
        }
    }
}
