using Application.Core;
using Domain.Student;
using MediatR;
using Persistence;

namespace Application.Students
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Student Student { get; set; }
        }


        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;


            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var student = await _context.Students.FindAsync(request.Student.Id);

                if (student == null) return null;

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update student");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}