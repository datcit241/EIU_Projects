using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.MockDomain;
using Domain.Student;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Students
{
    public class List
    {
        public class Query : IRequest<List<Student>>
        {
            public PagingParams QueryParams { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Student>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Student>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await _context.Students.ToListAsync();

                return students;
            }
        }
    }
}
