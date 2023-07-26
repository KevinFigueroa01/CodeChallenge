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
    public record CreateUserCommand(User User) : IRequest<int>;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,int>
    {
        private readonly IUsersRepository _repository;

        public CreateUserCommandHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Insert(request.User);

            return result;
        }
    }
}
