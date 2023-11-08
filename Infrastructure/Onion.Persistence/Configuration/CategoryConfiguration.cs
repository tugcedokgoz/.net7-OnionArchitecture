using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistence.Configuration
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			Category category1 = new()
			{
				Id = 1,
				Name = "Electronic",
				Priorty = 1,
				ParentId = 0,
				IsDeleted = false,
				CreatedDate = DateTime.Now,
			};
			Category category2 = new()
			{
				Id = 2,
				Name = "Clothes",
				Priorty = 1,
				ParentId = 0,
				IsDeleted = false,
				CreatedDate = DateTime.Now,
			};
			Category parent1 = new()
			{
				Id = 3,
				Name = "Computer",
				Priorty = 1,
				ParentId = 1,
				IsDeleted = false,
				CreatedDate = DateTime.Now,
			};
			Category parent2 = new()
			{
				Id = 4,
				Name = "Women",
				Priorty = 1,
				ParentId = 2,
				IsDeleted = false,
				CreatedDate = DateTime.Now,
			};
			builder.HasData(category1, category2,parent1,parent2);
		}
	}
}
