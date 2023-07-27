using CodeChallenge.Domain.Entities.Users;
using CodeChallenge.Infrastructure.Repositories;
using MediatR;

namespace CodeChallenge.Application.Queries
{
    public record GetUserQuery(string Email, string Password) : IRequest<User>;

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUsersRepository _repository;

        public GetUserQueryHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
           var user = await _repository.Get(request.Email, request.Password);

            return user;
        }
    }
}
