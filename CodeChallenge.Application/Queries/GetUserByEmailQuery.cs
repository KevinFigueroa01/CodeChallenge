using CodeChallenge.Domain.Entities.Users;
using CodeChallenge.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Application.Queries
{
    public record GetUserByEmailQuery(string Email) : IRequest<User>;

    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUsersRepository _repository;

        public GetUserByEmailQueryHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmail(request.Email);

            return user;
        }
    }
}
