public class SuccessResponseDTO<T> : AbstractResponseDTO
{
  public T Data { get; set; }
  public Pagination? Pagination { get; set; }

  public SuccessResponseDTO(int statusCode, T data) : base(statusCode) => Data = data;
  public SuccessResponseDTO(int statusCode, T data, Pagination pagination) : base(statusCode) =>
    (Data, Pagination) = (data, pagination);
}