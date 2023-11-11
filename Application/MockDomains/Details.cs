using Domain.MockDomain;
using MediatR;
using Persistence;

namespace Application.MockDomains;

public class Details
{
   public class Query : IRequest<MockDomain>
   {
      public Guid Id { get; set; }
   } 
   
   public class Handler : IRequestHandler<Query, MockDomain>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<MockDomain> Handle(Query request, CancellationToken cancellationToken)
      {
         return await _context.MockDomains.FindAsync(request.Id);
      }
   }
}