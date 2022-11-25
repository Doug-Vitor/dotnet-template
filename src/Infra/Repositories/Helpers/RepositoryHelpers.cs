internal static class RepositoryHelpers
{
  public static void ValidateId(int? id)
  {
    if (id is null) throw new ArgumentNullException("Por favor, forneça um número de identificação (ID) válido.");
  }
}
