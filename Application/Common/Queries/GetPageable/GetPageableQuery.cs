using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Queries.GetPageable
{
    public class GetPageableQuery<TResponse> : BaseRequest<PaginationResult<TResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
