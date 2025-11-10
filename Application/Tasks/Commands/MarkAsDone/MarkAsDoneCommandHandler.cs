using Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.MarkAsDone
{
    public class MarkAsDoneCommandHandler
    {
        protected readonly AppDbContext dbContext;
        public MarkAsDoneCommandHandler(AppDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        public async Task<BaseResponse> Handle(MarkAsDoneCommand command, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Tasks.FirstOrDefaultAsync(e => e.Id == command.Id,cancellationToken);

            if(entity!=null)
            {
                if(entity.IsDone)
                    return new BaseResponse(statusCode: System.Net.HttpStatusCode.NoContent);
                entity.IsDone = true;
                dbContext.SaveChanges();
                return new BaseResponse(statusCode: System.Net.HttpStatusCode.OK);
            }
            return new BaseResponse(statusCode: System.Net.HttpStatusCode.NotFound);
        }
    }
}
