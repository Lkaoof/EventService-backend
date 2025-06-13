using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Application.Interfaces.Infrastructure;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.DeleteUserById
{
    public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdCommand>
    {
        private readonly IDatabaseContext _context;

        public DeleteUserByIdHandler(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id, cancellationToken);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
