using Microsoft.Extensions.Logging;

namespace RBA.Repository;

public class AppUserRepository(IFreeSql sql, ILogger<AppUserRepository> logger) 
  : RepositoryBase<Domain.Entities.AppUser>(sql, logger), IAppUserRepository
{

}
