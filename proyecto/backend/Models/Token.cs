namespace backend.Models;

public partial class Token
{
  public string token { get; set; } = null!;
  public DateTime expiration { get; set; }
}
