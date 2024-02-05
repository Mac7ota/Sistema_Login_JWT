
namespace JwtStore.Core.AccountContext.ValueObjects;

public class Password
{
    private string Valid = "abcdefghijlmnopqrstuvxzwykABCDEFGHIJKLMNOPQRSTUVXZWYK";
    private string Special = "!@#$%&*()_+{}[]^~?;:.,-=<>|/\\";
    
    public string Hash { get;  } = string.Empty;
    public string ResetCode { get; } = Guid.NewGuid().ToString("N")[..8].ToString();
}

