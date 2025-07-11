using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Application.Resources;
using Microsoft.Extensions.Configuration;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Services
{
	public class CloudService : BaseService, ICloudService
	{
		private readonly IContainerService containerService;

		public CloudService(
			IContainerService containerService,
			IConfiguration configuration
		) : base(configuration)
		{
			this.containerService = containerService;
		}

		public Task SendContainerStatusReport(ContainerStatusRecord record)
		{
			throw new NotImplementedException();
		}

		public async Task<ContainerRegistrationResource> RegisterContainer(string uiid)
		{
			try
				{
				var resource = new { uiid = uiid };
				var client = new HttpClient();
				var response = await client.PostAsJsonAsync($"{BaseUrl}/container/register-container", resource);
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadFromJsonAsync<ContainerRegistrationResource>();
					await containerService.CreateContainer(result.Uiid, result.Id);
					return result;
				}
				else
				{
					Console.WriteLine($"Failed to register container: {response.StatusCode}. {response.Content}. \n\n {resource} ");
					throw new Exception("Failed to register container");
				}
			}
			catch
			{
				throw new Exception("Failed to register container");
			}
		}
	}
}
