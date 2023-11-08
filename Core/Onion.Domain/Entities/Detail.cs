using Onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Entities
{
	public class Detail : EntityBase
	{
        public Detail()
        {
            
        }
        public Detail(string title, string description,int categoryId)
        {
            CatgeoryId = categoryId;
			Title = title;
			Description = description;
		}
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CatgeoryId { get; set; }
        public Category Category { get; set; }
    }
}
