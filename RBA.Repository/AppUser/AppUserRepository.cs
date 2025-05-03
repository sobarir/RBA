using Microsoft.Extensions.Logging;

namespace RBA.Repository;

public class UserMesRepository(IFreeSql sql, ILogger<UserMesRepository> logger) 
  : RepositoryBase<Domain.Entities.UserMes>(sql, logger), IUserMesRepository
{

}
