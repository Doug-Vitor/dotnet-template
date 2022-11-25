public class Pagination
{
  public int? CurrentPage { get; set; }
  public int? ItemsPerPage { get; set; }
  public int? TotalPages { get; set; }
  public bool HasPreviousPage { get; set; }
  public bool HasNextPage { get; set; }

  public Pagination(int currentPage, int itemsPerPage, int totalItems)
  {
    int totalPages = (int)Math.Round((double)totalItems / itemsPerPage, MidpointRounding.AwayFromZero);
    (CurrentPage, ItemsPerPage, TotalPages, HasPreviousPage, HasNextPage) =
    (currentPage, itemsPerPage, totalPages, currentPage > 1, currentPage < totalPages);
  }
}