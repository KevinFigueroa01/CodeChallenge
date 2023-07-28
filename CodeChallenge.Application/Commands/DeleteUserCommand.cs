using CodeChallenge.Domain.Entities.Users;
using CodeChallenge.Infrastructure.Repositories;
using MediatR;

namespace CodeChallenge.Application.Commands
{
    public record DeleteUserCommand(string Email):IRequest<int>;

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUsersRepository _repository;

        public DeleteUserCommandHandler(IUsersRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Delete(request.Email);

            return result;
        }
    }
}
