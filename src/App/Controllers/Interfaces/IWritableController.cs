using Microsoft.AspNetCore.Mvc;

public interface IWritableController<TCreateModel, TUpdateModel>
{
  public Task<IActionResult> Create([FromBody] TCreateModel model);
  public Task<IActionResult> Update(int? id, [FromBody] TUpdateModel model);
  public Task<IActionResult> Delete(int? id);
}