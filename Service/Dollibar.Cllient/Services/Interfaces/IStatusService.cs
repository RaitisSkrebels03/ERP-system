using Dollibar.Cllient.Dtos.LoginDto;
using Dollibar.Cllient.Dtos.StatusDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IStatusService
    {
        Task<StatusResponseDto> GetStatus();
    }
}

