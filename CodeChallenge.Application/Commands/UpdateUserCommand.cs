using CodeChallenge.Domain.Entities.Users;
using CodeChallenge.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Application.Commands
{
    public record UpdateUserCommand(User User):IRequest<int>;

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUsersRepository _repository;

        public UpdateUserCommandHandler(IUsersRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Update(request.User);

            return result;
        }
    }
}
