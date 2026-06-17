using System.Text.RegularExpressions;

namespace FlowboardAPI.Shared.Infrastructure.Interfaces.AspNetCore.Configuration.Extensions;

public static class StringExtensions
{
    public static string ToKebabCase(string? value)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        
        return Regex.Replace(value, "(?<!^)([A-Z])", "-$1").ToLower();
    }
}