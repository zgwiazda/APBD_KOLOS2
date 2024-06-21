
using APBD_KOLOS2.DTOs;
using APBD_KOLOS2.Models;
using APBD_KOLOS2.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace kolokwium1.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly IDbService _ownerRepository;
 
        public OwnersController(IDbService ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwner(int id)
        {
            if (!await _ownerRepository.IfOwnerExistsAsync(id))
                return NotFound($"Owner with id = {id} doesn't exist!");
 
            var owner = await _ownerRepository.GetOwnerWithItemsAsync(id);
 
            return Ok(owner);
        }
 
        [HttpPost]
        public async Task AddOwnerAsync(OwnerInfoDTO ownerDto, List<int> objectIds)
        {
            var owner = new Owner
            {
                FirstName = ownerDto.FirstName,
                LastName = ownerDto.LastName,
                PhoneNumber = ownerDto.PhoneNumber
            };

            _ownerRepository.AddOwnerAsync(ownerDto);

            if (ownerDto.Objects != null && ownerDto.Objects.Any())
            {
                foreach (var objectDto in ownerDto.Objects)
                {
                    var objectOwner = new Object_Owner
                    {
                        Owner = owner,
                        Object_ID = objectDto.ID
                    };
                    _ownerRepository.AddOwnerAsync(ownerDto);                }
            }
            
        }


    }
}