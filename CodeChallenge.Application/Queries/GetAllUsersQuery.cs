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
    public record GetAllUsersQuery():IRequest<List<User>>;

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUsersRepository _repository;

        public GetAllUsersQueryHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAll();

            return user;
        }
    }
}
