using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Application.Mapping;
using MediatR;

namespace AuthServer.Application.CQRS.User.Queries.GetUserByName
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, GetUserByNameQueryResponse>
    {

        private readonly IUserRepository _userRepository;

        public GetUserByNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByNameQueryResponse> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            return ObjectMapper.Mapper.Map<GetUserByNameQueryResponse>(await _userRepository.GetUserByNameAsync(request));
        }
    }
}
