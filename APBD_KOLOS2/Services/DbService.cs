using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APBD_KOLOS2.DTOs;
using APBD_KOLOS2.Models;

namespace APBD_KOLOS2.Services
{
    public class DbService : IDbService
    {
        private readonly DatabaseContext _context;

        public DbService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<OwnerInfoDTO> GetOwnerWithItemsAsync(int ownerId)
        {
            var owner = await _context.Owners
                .Where(o => o.ID == ownerId)
                .Include(o => o.ObjectOwners)
                .ThenInclude(oo => oo.Object)
                .FirstOrDefaultAsync();

            if (owner == null)
            {
                return null;
            }

            var ownerInfoDto = new OwnerInfoDTO
            {
                ID = owner.ID,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PhoneNumber = owner.PhoneNumber,
                Objects = owner.ObjectOwners.Select(oo => new ObjectDTO
                {
                    ID = oo.Object.ID,
                    Warehouse_ID = oo.Object.Warehouse_ID,
                    Object_Type_ID = oo.Object.Object_Type_ID,
                    Width = oo.Object.Width,
                    Height = oo.Object.Height
                }).ToList()
            };

            return ownerInfoDto;
        }

        public async Task<bool> IfOwnerExistsAsync(int ownerId)
        {
            return await _context.Owners.AnyAsync(o => o.ID == ownerId);
        }

        public async Task AddOwnerAsync(OwnerInfoDTO ownerDto, List<int> objectIds)
        {
            var owner = new Owner
            {
                FirstName = ownerDto.FirstName,
                LastName = ownerDto.LastName,
                PhoneNumber = ownerDto.PhoneNumber
            };

            _context.Owners.Add(owner);

          
            if (objectIds != null && objectIds.Any())
            {
                foreach (var objectId in objectIds)
                {
                    var @object = await _context.Objects.FindAsync(objectId);
                    if (@object != null)
                    {
                        var objectOwner = new Object_Owner
                        {
                            Owner = owner,
                            Object = @object
                        };
                        _context.ObjectOwners.Add(objectOwner);
                    }
                    else
                    {
                        throw new ArgumentException($"Object with ID {objectId} not found.");
                    }
                }
            }

            await _context.SaveChangesAsync();
        }
        public async Task<bool> ObjectExistsAsync(int objectId)
        {
            return await _context.Objects.AnyAsync(o => o.ID == objectId);
        }


    }
}
