using CubeRealm.Network.Base.API.PacketsBase;
using NetworkAPI.Protocol.Util;

namespace CubeRealm.Network.Version765.Packets.Play.ToClient;

public class Ping : Packet<Ping>, IToClient
{
    public override int PacketId => 0x04;
    
    public int Id { get; set; }
    
    public override void Read(IMinecraftStream stream)
    {
        Id = stream.ReadInt();
    }

    public override void Write(IMinecraftStream stream)
    {
        stream.WriteInt(Id);
    }
}