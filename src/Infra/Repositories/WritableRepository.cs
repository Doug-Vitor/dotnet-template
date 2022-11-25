using System.Net;
using Microsoft.EntityFrameworkCore;

public class WritableRepository<T> : IWritableRepository<T> where T : BaseEntity
{
  protected readonly ApplicationContext WritableContext;

  public WritableRepository(ApplicationContext context) => WritableContext = context;

  public virtual async Task<SuccessResponseDTO<T>> InsertAsync(T entity)
  {
    await WritableContext.AddAsync(entity);
    await WritableContext.SaveChangesAsync();
    return new((int)HttpStatusCode.Created, entity);
  }

  public virtual async Task<SuccessResponseDTO<T>> UpdateAsync(int? id, T entity)
  {
    entity.Id = id;
    WritableContext.Update(entity);
    await WritableContext.SaveChangesAsync();
    return new((int)HttpStatusCode.OK, entity);
  }

  public virtual async Task RemoveAsync(int? id)
  {
    RepositoryHelpers.ValidateId(id);
    WritableContext.Remove(await WritableContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id));
    await WritableContext.SaveChangesAsync();
  }
}