using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class AbstractController<T> : ControllerBase where T : BaseEntity
{
  protected virtual List<string> GetModelStateErrors() => ModelState.Values.SelectMany(state => state.Errors).Select(message => message.ErrorMessage).ToList();
  protected virtual IActionResult OnSuccess(SuccessResponseDTO<T> response) => StatusCode((int)response.StatusCode, response);
  protected virtual IActionResult OnInvalidModelState(int statusCode = 413) => StatusCode(statusCode, new ErrorResponseDTO(statusCode, GetModelStateErrors()));
}