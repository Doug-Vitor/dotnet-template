using Microsoft.AspNetCore.Mvc;

[ApiVersion("1.0")]
public abstract class BaseController<TEntity>
  : AbstractController<TEntity>, IReadonlyController<TEntity>, IWritableController<TEntity, TEntity> where TEntity : BaseEntity
{
  protected readonly IReadOnlyRepository<TEntity> ReadOnlyRepository;
  protected readonly IWritableRepository<TEntity> WritableRepository;

  public BaseController(IReadOnlyRepository<TEntity> readOnlyRepository, IWritableRepository<TEntity> writableRepository)
    => (ReadOnlyRepository, WritableRepository) = (readOnlyRepository, writableRepository);

  [ProducesResponseType(413, Type = typeof(ErrorResponseDTO))]
  [HttpPost]
  public async virtual Task<IActionResult> Create([FromBody] TEntity model) =>
    OnSuccess(await WritableRepository.InsertAsync(model));

  [ProducesResponseType(400, Type = typeof(ErrorResponseDTO))]
  [ProducesResponseType(404, Type = typeof(ErrorResponseDTO))]
  [HttpGet]
  public async virtual Task<IActionResult> GetById([FromQuery] int? id) => OnSuccess(await ReadOnlyRepository.GetByIdAsync(id));

  [HttpGet("All")]
  public async virtual Task<IActionResult> GetAll([FromQuery] int? page, [FromQuery] int? itemsPerPage) =>
    Ok(await ReadOnlyRepository.GetAllAsync(page, itemsPerPage));
    
  [ProducesResponseType(400, Type = typeof(ErrorResponseDTO))]
  [ProducesResponseType(404, Type = typeof(ErrorResponseDTO))]
  [ProducesResponseType(413, Type = typeof(ErrorResponseDTO))]
  [HttpPut]
  public async virtual Task<IActionResult> Update([FromQuery] int? id, [FromBody] TEntity model) =>
    ModelState.IsValid ? OnSuccess(await WritableRepository.UpdateAsync(id, model)) : OnInvalidModelState();

  public async virtual Task<IActionResult> Delete([FromQuery] int? id)
  {
    await WritableRepository.RemoveAsync(id);
    return NoContent();
  }
}