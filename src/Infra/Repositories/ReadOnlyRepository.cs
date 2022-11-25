using System.Net;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
{
  protected readonly ApplicationContext ReadOnlyContext;

  public ReadOnlyRepository(ApplicationContext context) => ReadOnlyContext = context;

  public virtual async Task<SuccessResponseDTO<T>> GetByIdAsync(int? id)
  {
    RepositoryHelpers.ValidateId(id);
    return new((int)HttpStatusCode.OK, await ReadOnlyContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id) ?? throw new NotFoundException());
  }

  public virtual async Task<SuccessResponseDTO<IEnumerable<T>>> GetAllAsync(int? page, int? itemsPerPage)
  {
    page = page ?? 1;
    itemsPerPage = itemsPerPage ?? 25;

    IOrderedQueryable<T> results = (from entity in ReadOnlyContext.Set<T>()
                                    orderby entity.Id
                                    select entity);

    return new(
      (int)HttpStatusCode.OK, await results.AsNoTracking().Skip((page.Value - 1) * itemsPerPage.Value).Take(itemsPerPage.Value).ToListAsync(),
      new(page.Value, itemsPerPage.Value, await results.CountAsync())
    );
  }
}