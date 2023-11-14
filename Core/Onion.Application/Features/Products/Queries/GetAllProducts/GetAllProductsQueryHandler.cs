using MediatR;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Products.Queries.GetAllProducts
{
	public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
	{
		private readonly IUnitOfWorks unitOfWorks;
		public GetAllProductsQueryHandler(IUnitOfWorks unitOfWorks)
		{
			this.unitOfWorks = unitOfWorks;
		}
		public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await unitOfWorks.GetReadRepository<Product>().GetAllAsync();

			List<GetAllProductsQueryResponse> response = new List<GetAllProductsQueryResponse>();
			foreach (var product in products)
			{
				response.Add(new GetAllProductsQueryResponse
				{
					Title = product.Title,
					Description = product.Description,
					Discount = product.Discount,
					Price = product.Price - (product.Price * product.Discount / 100),
				});
			}
			return response;
		}
	}
}
