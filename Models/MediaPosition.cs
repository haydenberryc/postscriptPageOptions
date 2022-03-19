using Ardalis.SmartEnum;

namespace csbatcher.Models;

public sealed class MediaPosition : SmartEnum<MediaPosition>
{
    public static readonly MediaPosition Tray1 = new(nameof(Tray1), 1,0);
    public static readonly MediaPosition Tray2 = new(nameof(Tray2), 2,1);
    public static readonly MediaPosition Tray3 = new(nameof(Tray3), 3,2);
    public static readonly MediaPosition Tray4 = new(nameof(Tray4), 4,3);
    public static readonly MediaPosition Tray5 = new(nameof(Tray5), 5,4);
    public int Position { get; }
    public MediaPosition(string name, int value, int position) : base(name, value)
    {
        Position = position;
    }
}