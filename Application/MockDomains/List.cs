using Application.Core;
using Domain.MockDomain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.MockDomains;

public class List
{
   public class Query : IRequest<List<MockDomain>>
   {
      public PagingParams QueryParams { get; set; }
   }
   
   public class Handler : IRequestHandler<Query, List<MockDomain>>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<List<MockDomain>> Handle(Query request, CancellationToken cancellationToken)
      {
        var mockDomains = await _context.MockDomains.ToListAsync();

        return mockDomains;
      }
   }
}