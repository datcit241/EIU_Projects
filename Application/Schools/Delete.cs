using Application.Core;
using MediatR;
using Persistence;

namespace Application.Schools
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var school = await _context.Schools.FindAsync(request.Id);

                if (school == null) return null;

                _context.Remove(school);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the school");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}