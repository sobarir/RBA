using Microsoft.Extensions.Logging;

namespace RBA.Repository;

public class ActionRepository(IFreeSql sql, ILogger<ActionRepository> logger) 
  : RepositoryBase<Domain.Entities.Action>(sql, logger), IActionRepository
{

  public override Task<Domain.Entities.Action> CreateAsync(Domain.Entities.Action entity)
  {
    return CreateIdentityAsync(entity);
  }

}
