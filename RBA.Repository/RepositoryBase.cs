using Microsoft.Extensions.Logging;

using FreeSql.DataAnnotations;

using RBA.Domain;

namespace RBA.Repository;

public class RepositoryBase<T>(IFreeSql sql, ILogger<RepositoryBase<T>> logger) : IRepositoryBase<T> where T : class
{

  protected ILogger _logger = logger;
  protected IFreeSql _sql = sql;

  public virtual async Task<T> CreateAsync(T entity)
  {
    _logger.LogInformation("CreateAsync {entity}", entity.ToJson());
    SetCreatedDateColumn(entity);
    await _sql.Insert(entity).ExecuteAffrowsAsync();
    return entity;
  }

  protected async Task<T> CreateIdentityAsync(T entity)
  {
    _logger.LogInformation("CreateAsync {entity}", entity.ToJson());
    SetCreatedDateColumn(entity);
    var id = await _sql.Insert(entity).ExecuteIdentityAsync();
    var col = GetKeyColumn();
    col.SetValue(entity, Convert.ChangeType(id, col.PropertyType));
    return entity;
  }

  public async Task<IEnumerable<T>> GetAllAsync()
  {
    return await _sql.Select<T>().ToListAsync();
  }

  public virtual async Task<T?> GetAsync(object? id)
  {
    var wheres = ComposeWheres(id);
    return await _sql.Select<T>().Where(wheres.Item1, wheres.Item2).ToOneAsync();
  }

  public virtual async Task<bool> DeleteAsync(object? id)
  {
    _logger.LogInformation("DeleteAsync {id}", id);
    //var wheres = ComposeWheres(id);
    return await _sql.Delete<T>()
      //.Where(wheres.Item1, wheres.Item2)
      .ExecuteAffrowsAsync() > 0;
  }

  public virtual async Task<bool> UpdateAsync(T entity)
  {
    _logger.LogInformation("UpdateAsync {entity}", entity.ToJson());

    //var col = GetKeyColumn();
    //var id = col.GetValue(entity);

    //var wheres = ComposeWheres(col, id);
    return await _sql.Update<T>()
      .SetSourceIgnore(entity, col => col == null)
      //.Where(wheres.Item1, wheres.Item2)
      .ExecuteAffrowsAsync() > 0;
  }

  private static (string, object?) ComposeWheres(object? id)
  {
    var col = GetKeyColumn();
    var val = new Dictionary<string, object?>
    {
      { col.Name, Convert.ChangeType(id, col.PropertyType) }
    };
    return ($"{col.Name} = @{col.Name}", val);
  }

  /*
  private static (string, object?) ComposeWheres(System.Reflection.PropertyInfo col, object? id)
  {
    var val = new Dictionary<string, object?>
    {
      { col.Name, Convert.ChangeType(id, col.PropertyType) }
    };
    return ($"{col.Name} = @{col.Name}", val);
  }
  */

  private static System.Reflection.PropertyInfo GetKeyColumn()
  {
    System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
    foreach (System.Reflection.PropertyInfo property in properties)
    {
      object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), false);
      foreach (object attribute in columnAttributes)
      {
        ColumnAttribute columnAttribute = (ColumnAttribute)attribute;
        if (!columnAttribute.IsPrimary) continue;
        return property;
      }
    }
    throw new InvalidOperationException($"{typeof(T).FullName} doesn't have key!");
  }

  private static void SetCreatedDateColumn(T entity)
  {
    System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
    foreach (System.Reflection.PropertyInfo property in properties)
    {
      if (property.Name == "created_date")
      {
        property.SetValue(null, null, null);
      }
      object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), false);
      foreach (object attribute in columnAttributes)
      {
        ColumnAttribute columnAttribute = (ColumnAttribute)attribute;
        if (columnAttribute.Name != "created_date") continue;
        if ((property.GetValue(entity) == null) || 
          (Convert.ToDateTime(property.GetValue(entity)) == DateTime.MinValue)
        )
        {
          property.SetValue((T)entity, DateTime.Now);
        }
      }
    }
  }

}
