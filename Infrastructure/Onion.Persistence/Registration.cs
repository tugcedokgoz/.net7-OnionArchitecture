﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistence
{
	public static class Registration
	{
		public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
		}
	}
}
