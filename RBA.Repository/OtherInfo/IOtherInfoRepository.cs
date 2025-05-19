using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IOtherInfoRepository : IRepositoryBase<Domain.Entities.OtherInfo>
{

  Task<IEnumerable<OtherInfo>> GetAllAsync(string info_type, string info_name);

}
