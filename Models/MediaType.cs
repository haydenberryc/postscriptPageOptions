using Ardalis.SmartEnum;

namespace csbatcher.Models;

public sealed class MediaType : SmartEnum<MediaType>
{
    public static readonly MediaType Plain = new(nameof(Plain), 1, "Plain"); 
    public static readonly MediaType CardStock = new(nameof(CardStock), 2, "Card");
    public static readonly MediaType Perforated = new(nameof(Perforated), 3, "Perf");
    
    public string Type { get; }
    
    public MediaType(string name, int value, string type) : base(name, value)
    {
        Type = type;
    }
}