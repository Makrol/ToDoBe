using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Queries.GetById
{
    public class GetByIdQuery<TResponse> : BaseRequest<TResponse>   
        where TResponse : class
    {
        public Guid Id { get; set; }
    }
}
