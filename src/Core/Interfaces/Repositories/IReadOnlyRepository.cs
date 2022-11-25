public interface IReadOnlyRepository<T> where T : BaseEntity
{
  Task<SuccessResponseDTO<T>> GetByIdAsync(int? id);
  Task<SuccessResponseDTO<IEnumerable<T>>> GetAllAsync(int? page, int? itemsPerPage);
}