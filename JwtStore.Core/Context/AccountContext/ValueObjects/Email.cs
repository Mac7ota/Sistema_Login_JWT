using JwtStore.Core.Context.AccountContext.ValueObjects;
using JwtStore.Core.Context.SharedContext.Extensions;
using JwtStore.Core.Context.SharedContext.ValueObjects;
using Microsoft.AspNetCore.Rewrite.Internal;
using System.Text.RegularExpressions;

namespace JwtStore.Core.AccountContext.ValueObjects;

public partial class Email : ValueObject
{
    private const string Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

    public Email(string address)
    {
        if (!EmailRegex().IsMatch(address))
            throw new ArgumentException("E-mail inválido");

        Address = address;
    }
    public string Address { get;  }
    public string Hash => Address.ToBase64();
    public Verification Verification { get; private set; } = new Verification();

    public void ResendVerification() => Verification = new Verification();
    


    public static implicit operator string(Email email) => email.ToString();
    public static implicit operator Email(string address) => new Email(address);
    public override string ToString() => Address;

    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
}

