using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class BaseRequest
    {
    }

    public class BaseRequest<TResponse>
    {
    }

    public abstract class BaseRequest<TRequest, TResponse>
    where TRequest : BaseRequest<TResponse>
    {
        public abstract Task<TResponse?> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
