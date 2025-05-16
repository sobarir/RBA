using RBA.Domain.AD;
using System.Security.Principal;

namespace RBA.Api.EndPoints.AD;

public interface IADUserProvider
{
  ADUser? CurrentUser { get; set; }
  bool Initialized { get; set; }
  Task Create(HttpContext context, IConfiguration config);
  Task<ADUser> GetADUser(IIdentity identity);
  Task<ADUser> GetADUser(string samAccountName);
  Task<ADUser> GetADUser(Guid guid);
  Task<List<ADUser>> GetDomainUsers();
  Task<List<ADUser>> FindDomainUser(string search);

  Task<string> CurrentDomainUser(HttpContext context);
}
