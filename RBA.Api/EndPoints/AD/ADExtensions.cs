namespace RBA.Api.EndPoints.AD;

using RBA.Domain.AD;
using System.DirectoryServices.AccountManagement;
using System.Linq;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
public static class ADExtensions
{
  public static IQueryable<UserPrincipal> FilterUsers(this IQueryable<UserPrincipal> principals) =>
      principals.Where(x => x.Guid.HasValue);

  public static IQueryable<ADUser> SelectADUsers(this IQueryable<UserPrincipal> principals) =>
      principals.Select(x => ADUser.CastToADUser(x));
}
