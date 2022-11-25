public abstract class BaseEntity
{
  public int? Id { get; set; }
  public DateOnly? CreatedAt { get; set; }

  public BaseEntity() { }
}