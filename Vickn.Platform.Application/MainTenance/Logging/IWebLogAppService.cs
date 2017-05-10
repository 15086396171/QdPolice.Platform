using Abp.Application.Services;
using Vickn.Platform.Dtos;
using Vickn.Platform.MainTenance.Logging.Dto;

namespace Vickn.Platform.MainTenance.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
