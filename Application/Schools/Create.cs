using Domain.School;
using Domain.Student;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Schools
{
    public class Create
    {
        public class Command : IRequest
        {
            public School School { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Schools.Add(request.School);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
