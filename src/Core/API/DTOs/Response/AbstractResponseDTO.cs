using System.Net;

public abstract class AbstractResponseDTO
{
  public HttpStatusCode StatusCode { get; set; }
  public AbstractResponseDTO(int code) => StatusCode = (HttpStatusCode)code;
}