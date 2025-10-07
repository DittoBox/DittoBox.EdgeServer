namespace DittoBox.EdgeServer.ContainerManagement.Application.Services
{
    public abstract class BaseService
    {
        protected string BaseUrl { get; set; } = "https://dittobox-webservices.azurewebsites.net/api/v1/";
	
	}
}
