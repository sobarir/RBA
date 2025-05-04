using RBA.Domain.AD;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace RBA.Api.EndPoints.AD;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
public class ADUserProvider : IADUserProvider
{

  public ADUser? CurrentUser { get; set; }
  public bool Initialized { get; set; }

  private string? DomainName { get; set; }

  public async Task Create(HttpContext context, IConfiguration config)
  {
    ArgumentNullException.ThrowIfNull(context);

    DomainName = config.GetValue<string>("AD:Domain");

    CurrentUser = await GetADUser(context.User.Identity!);
    Initialized = true;
  }

  public Task<ADUser> GetADUser(IIdentity identity)
  {
    return Task.Run(() =>
    {
      try
      {
        PrincipalContext context = new(ContextType.Domain, DomainName);
        UserPrincipal principal = new(context);

        if (context != null)
        {
          principal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, identity.Name);
        }

        return ADUser.CastToADUser(principal);
      }
      catch (Exception ex)
      {
        throw new Exception("Error retrieving AD User", ex);
      }
    });
  }

  public Task<ADUser> GetADUser(string samAccountName)
  {
    return Task.Run(() =>
    {
      try
      {
        PrincipalContext context = new(ContextType.Domain, DomainName);
        UserPrincipal principal = new(context);

        if (context != null)
        {
          principal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, samAccountName);
        }

        return ADUser.CastToADUser(principal);
      }
      catch (Exception ex)
      {
        throw new Exception("Domain unreachable. Error retrieving AD User", ex);
      }
    });
  }

  public Task<ADUser> GetADUser(Guid guid)
  {
    return Task.Run(() =>
    {
      try
      {
        PrincipalContext context = new(ContextType.Domain, DomainName);
        UserPrincipal principal = new(context);

        if (context != null)
        {
          principal = UserPrincipal.FindByIdentity(context, IdentityType.Guid, guid.ToString());
        }

        return ADUser.CastToADUser(principal);
      }
      catch (Exception ex)
      {
        throw new Exception("Domain unreachable. Error retrieving AD User", ex);
      }
    });
  }

  public Task<List<ADUser>> GetDomainUsers()
  {
    return Task.Run(() =>
    {
      PrincipalContext context = new(ContextType.Domain, DomainName);
      UserPrincipal principal = new(context)
      {
        UserPrincipalName = "*@*",
        Enabled = true
      };
      PrincipalSearcher searcher = new(principal);

      var users = searcher
        .FindAll()
        .AsQueryable()
        .Cast<UserPrincipal>()
        .FilterUsers()
        .SelectADUsers()
        .OrderBy(x => x.Surname)
        .ToList();

      return users;
    });
  }

  public Task<List<ADUser>> FindDomainUser(string search)
  {
    return Task.Run(() =>
    {
      PrincipalContext context = new(ContextType.Domain, DomainName);
      UserPrincipal principal = new(context)
      {
        SamAccountName = $"*{search}*",
        Enabled = true
      };
      PrincipalSearcher searcher = new PrincipalSearcher(principal);

      var users = searcher
        .FindAll()
        .AsQueryable()
        .Cast<UserPrincipal>()
        .FilterUsers()
        .SelectADUsers()
        .OrderBy(x => x.Surname)
        .ToList();

      return users;
    });
  }

}
