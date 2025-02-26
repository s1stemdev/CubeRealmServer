using World.API.Content;
using World.API.Coords;

namespace World.API.Block.Implementation;

public class SimpleBlock : IBlock
{
    public SimpleBlock(Material type, Location location)
    {
        Type = type;
        Location = location;
    }

    public Material Type { get; set; }
    public Location Location { get; set; }
}