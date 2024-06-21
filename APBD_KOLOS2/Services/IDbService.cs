using APBD_KOLOS2.DTOs;
using APBD_KOLOS2.Models;

namespace APBD_KOLOS2.Services;

public interface IDbService
{
    Task<List<OwnerInfoDTO>> GetAllOwnersWithItemsAsync();
    Task AddOwnerAsync(OwnerInfoDTO ownerDto);
}