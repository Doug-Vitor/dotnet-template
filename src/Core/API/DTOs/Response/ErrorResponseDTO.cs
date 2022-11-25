public class ErrorResponseDTO : AbstractResponseDTO
{
  public List<string> Messages { get; set; }

  public ErrorResponseDTO(int statusCode) : base(statusCode) => Messages = new();
  public ErrorResponseDTO(int statusCode, List<string> messages) : base(statusCode) => Messages = messages;

  public void AddMessage(string message) => Messages.Add(message);
}