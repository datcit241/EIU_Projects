﻿using Domain.Student;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students
{
    public class Create
    {
        public class Command : IRequest
        {
            public Student Student { get; set; }
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
                _context.Students.Add(request.Student);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
