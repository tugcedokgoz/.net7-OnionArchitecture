using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Onion.Mapper
{
	public static class Registration
	{
		public static void AddCustomMapper(this IServiceCollection services)
		{
			services.AddSingleton<Application.Interfaces.AutoMapper.IMapper, AutoMapper.Mapper>();
		}
	}
}
