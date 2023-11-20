using MediatR;
using Onion.Application.Interfaces.AutoMapper;
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
		private readonly IMapper mapper;

		public GetAllProductsQueryHandler(IUnitOfWorks unitOfWorks,IMapper mapper)
		{
			this.unitOfWorks = unitOfWorks;
			this.mapper = mapper;
		}
		public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await unitOfWorks.GetReadRepository<Product>().GetAllAsync(include:x=>x.Include(b=>b.Brand));
			var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
			foreach (var item in map)
				item.Price -= (item.Price * item.Discount / 100);
			return map;
		}
	}
}
