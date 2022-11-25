public class NotFoundException : Exception
{
  public NotFoundException() : base("Não foi possível encontrar resultados correspondentes à sua pesquisa.") { }
  public NotFoundException(string message) : base(message) { }
}