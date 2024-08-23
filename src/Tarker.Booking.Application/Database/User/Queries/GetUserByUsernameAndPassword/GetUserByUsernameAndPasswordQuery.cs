using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.Database.User.Queries.GetUserByUsernameAndPassword
{
    public class GetUserByUsernameAndPasswordQuery: IGetUserByUsernameAndPasswordQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        public GetUserByUsernameAndPasswordQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByUsernameAndPasswordModel> Execute
            (string username, string password)
        {
            var entity = await _databaseService.User.FirstOrDefaultAsync(x => 
                x.Username == username && x.Password == password
            );

            return _mapper.Map<GetUserByUsernameAndPasswordModel>(entity);
        }
    }
}
