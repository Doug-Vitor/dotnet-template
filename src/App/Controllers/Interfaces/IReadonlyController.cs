using Microsoft.AspNetCore.Mvc;

public interface IReadonlyController<T> where T : BaseEntity
{
  public Task<IActionResult> GetById(int? id);
  public Task<IActionResult> GetAll([FromQuery] int? page, [FromQuery] int? itemsPerPage);
}