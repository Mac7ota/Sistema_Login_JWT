

using JwtStore.Core.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects;

public class Verification : ValueObject
{
    public string Code { get; } = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
    public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
    public DateTime? VerifiedAt { get; private set; } = null;
    public bool IsActive => VerifiedAt != null && ExpiresAt == null;
    public void Verifyy(string code)
    {
        if (IsActive)
            throw new ArgumentException("Este item já foi ativado");

        if (ExpiresAt < DateTime.UtcNow)
            throw new ArgumentException("Este código já expirou");

        if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new ArgumentException("Código de verificação inválido");

        ExpiresAt = null;
        VerifiedAt = DateTime.UtcNow;
    }
}
