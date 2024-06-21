using System.Collections.Generic;
using System.Threading.Tasks;
using APBD_KOLOS2.DTOs;

namespace APBD_KOLOS2.Services
{
    public interface IDbService
    {
       
        Task<OwnerInfoDTO> GetOwnerWithItemsAsync(int ownerId);
        Task<bool> IfOwnerExistsAsync(int ownerId);
        Task AddOwnerAsync(OwnerInfoDTO ownerDto, List<int> objectIds);
        Task<bool> ObjectExistsAsync(int objectId);
    }
}