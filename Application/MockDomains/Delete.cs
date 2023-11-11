using Application.Core;
using MediatR;
using Persistence;

namespace Application.MockDomains;

public class Delete
{
    public class Command : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
    
    public class Handler: IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var mockDomain = await _context.MockDomains.FindAsync(request.Id);
            _context.Remove(mockDomain);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}