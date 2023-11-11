using Domain.MockDomain;
using MediatR;
using Persistence;

namespace Application.MockDomains;

public class Edit
{
    public class Command : IRequest<Unit>
    {
        public MockDomain MockDomain { get; set; }
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
            var mockDomain = await _context.MockDomains.FindAsync(request.MockDomain.Id);

            mockDomain.Name = request.MockDomain.Name ?? mockDomain.Name;
            
            await _context.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}