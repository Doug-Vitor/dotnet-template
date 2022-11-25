public interface IWritableRepository<T> where T : BaseEntity
{
  Task<SuccessResponseDTO<T>> InsertAsync(T entity);
  Task<SuccessResponseDTO<T>> UpdateAsync(int? id, T entity);
  Task RemoveAsync(int? id);
}