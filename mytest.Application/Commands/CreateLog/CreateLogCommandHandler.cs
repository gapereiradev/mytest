using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mytest.Application.Commands.CreateLog
{
    public class CreateLogCommandHandler : IRequestHandler<CreateLogCommand, Unit>
    {
        public CreateLogCommandHandler()
        {

        }

        public Task<Unit> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
