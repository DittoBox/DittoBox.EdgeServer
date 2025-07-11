using Microsoft.Extensions.Configuration;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Services
{
    public abstract class BaseService
    {
        protected string BaseUrl { get; set; }

        protected BaseService(IConfiguration configuration)
        {
            // Try to get from Application:DefaultGateway, fallback to http://localhost:5007
            BaseUrl = configuration["Application:DefaultGateway"] ?? "http://localhost:5007";
        }
    }
}
