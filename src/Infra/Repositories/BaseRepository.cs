using System.Net;
using Microsoft.EntityFrameworkCore;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
  protected readonly ApplicationContext Context;

  public BaseRepository(ApplicationContext context) => Context = context;

  public virtual async Task<SuccessResponseDTO<T>> InsertAsync(T entity)
  {
    await Context.AddAsync(entity);
    await Context.SaveChangesAsync();
    return new((int)HttpStatusCode.Created, entity);
  }

  public virtual async Task<SuccessResponseDTO<T>> GetByIdAsync(int? id)
  {
    RepositoryHelpers.ValidateId(id);
    return new((int)HttpStatusCode.OK, await Context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id) ?? throw new NotFoundException());
  }

  public virtual async Task<SuccessResponseDTO<IEnumerable<T>>> GetAllAsync(int? page, int? itemsPerPage)
  {
    page = page ?? 1;
    itemsPerPage = itemsPerPage ?? 25;

    IQueryable<T> results = (from entity in Context.Set<T>()
                                    orderby entity.Id
                                    select entity).AsNoTracking();

    return new(
      (int)HttpStatusCode.OK, await results.Skip((page.Value - 1) * itemsPerPage.Value).Take(itemsPerPage.Value).ToListAsync(),
      new(page.Value, itemsPerPage.Value, await results.CountAsync())
    );
  }

  public virtual async Task<SuccessResponseDTO<T>> UpdateAsync(int? id, T entity)
  {
    entity.Id = id;
    Context.Update(entity);
    await Context.SaveChangesAsync();
    return new((int)HttpStatusCode.OK, entity);
  }

  public virtual async Task RemoveAsync(int? id)
  {
    Context.Remove(await GetByIdAsync(id));
    await Context.SaveChangesAsync();
  }
}