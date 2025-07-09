using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IActionRepository : IRepositoryBase<Domain.Entities.Action>
{

  Task<IEnumerable<Domain.Entities.Action>> GetByAppIdAsync(string application_cd);

}
