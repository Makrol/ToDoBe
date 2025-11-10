using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class PaginationResult<TViewModel>
    {
        public PaginationResult(IEnumerable<TViewModel> result, int total)
        {
            Result = result;
            Total = total;
        }

        public IEnumerable<TViewModel> Result { get; }

        public int Total { get; set; }
    }
}
