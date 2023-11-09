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
			CategoryId = categoryId;
			Title = title;
			Description = description;
		}
        public  string Title { get; set; }
        public  string Description { get; set; }
        public  int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
