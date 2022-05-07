using System.Runtime.CompilerServices;

namespace App.Base;

public class LangStr : Dictionary<string, string>
{
    private const string DefaultCulture = "en";
    
    public LangStr()
    {
    }

    public LangStr(string str): this(str, Thread.CurrentThread.CurrentUICulture.Name) 
    {
    }

    public LangStr(string value, string culture)
    {
        this[culture] = value;
    }

    public string? Translate(string? culture = null)
    {
        if (Count == 0) return null;

        culture = culture?.Trim() ?? Thread.CurrentThread.CurrentUICulture.Name;
        if (ContainsKey(culture))
        {
            return this[culture];
        }

        var neutralCulture = culture.Split("-")[0];
        if (ContainsKey(neutralCulture))
        {
            return this[neutralCulture];
        }

        if (ContainsKey(DefaultCulture))
        {
            return this[DefaultCulture];
        }

        return null;
    }

    public override string ToString()
    {
        return Translate() ?? "???";
    }

    public static implicit operator string(LangStr? langStr) => langStr?.ToString() ?? "null";
    public static implicit operator LangStr(string str) => new LangStr(str);
    
}