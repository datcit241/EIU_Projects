using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.MockDomain;
using Domain.School;
using Domain.Student;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Schools
{
    public class List
    {
        public class Query : IRequest<List<School>>
        {
            public PagingParams QueryParams { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<School>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<School>> Handle(Query request, CancellationToken cancellationToken)
            {
                var schools = await _context.Schools.ToListAsync();

                return schools;
            }
        }
    }
}
