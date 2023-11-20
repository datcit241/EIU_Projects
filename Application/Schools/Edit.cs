using Application.Core;
using Domain.School;
using Domain.Student;
using MediatR;
using Persistence;

namespace Application.Schools
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public School School { get; set; }
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
                var school = await _context.Schools.FindAsync(request.School.Id);

                if (school == null) return null;

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update school");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}