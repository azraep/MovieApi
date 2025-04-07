using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery
    {
        public int CategoryId { get; set; }
    }
}
