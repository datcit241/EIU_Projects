using Domain.MockDomain;
using MediatR;
using Persistence;

namespace Application.MockDomains;

public class Create
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
         _context.MockDomains.Add(request.MockDomain);
         await _context.SaveChangesAsync();

         return Unit.Value;
      }
   }
}