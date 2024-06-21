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

        public async Task<List<OwnerInfoDTO>> GetAllOwnersWithItemsAsync()
        {
            return await _context.Owners
                .Include(o => o.ObjectOwners)
                .ThenInclude(oo => oo.Object)
                .Select(o => new OwnerInfoDTO
                {
                    ID = o.ID,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    PhoneNumber = o.PhoneNumber,
                    Objects = o.ObjectOwners.Select(oo => new ObjectDTO
                    {
                        ID = oo.Object.ID,
                        Warehouse_ID = oo.Object.Warehouse_ID,
                        Object_Type_ID = oo.Object.Object_Type_ID,
                        Width = oo.Object.Width,
                        Height = oo.Object.Height
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task AddOwnerAsync(OwnerInfoDTO ownerDto)
        {
            var owner = new Owner
            {
                FirstName = ownerDto.FirstName,
                LastName = ownerDto.LastName,
                PhoneNumber = ownerDto.PhoneNumber
            };

            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
        }
    }
}