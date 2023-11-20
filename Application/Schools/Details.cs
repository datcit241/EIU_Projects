using Application.Core;
using Application.Interfaces;
using Application.Students;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.MockDomain;
using Domain.School;
using Domain.Student;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Schools
{
    public class Details
    {

        public class Query : IRequest<School>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, School>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<School> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Schools.FindAsync(request.Id);
            }
        }
    }
}

