using Microsoft.Extensions.Logging;

namespace RBA.Repository;

public class ApplicationRepository(IFreeSql sql, ILogger<ApplicationRepository> logger) 
  : RepositoryBase<Domain.Entities.Application>(sql, logger), IApplicationRepository
{

}
