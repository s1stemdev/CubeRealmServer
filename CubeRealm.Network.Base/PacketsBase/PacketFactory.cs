using CubeRealm.Network.Base.PacketsBase.Packets;
using CubeRealm.Network.Base.PacketsBase.Packets.Status.ToBoth;
using CubeRealm.Network.Base.PacketsBase.Packets.Status.ToClient;
using CubeRealm.Network.Base.PacketsBase.Packets.Status.ToServer;
using CubeRealm.Network.Packets;
using Network;
using NetworkAPI;

namespace CubeRealm.Network.Base.PacketsBase;

public class PacketFactory : IPacketFactory
{
    //<version, Packet>
    private IDictionary<int, PacketsDictionary> PacketsToServer { get; }
    private IDictionary<int, PacketsDictionary> PacketsToClient { get; }
    
    public PacketFactory()
    {
        PacketsDictionary toServer = new PacketsDictionary
        {
            Handshake = [new Handshake()],
            Status = [new StatusRequest(), new Ping()]
        };
        PacketsDictionary toClient = new PacketsDictionary
        {
            Status = [new StatusResponse(), new Ping()]
        };
        
        PacketsToServer = new Dictionary<int, PacketsDictionary>
        {
            { 0, toServer },
            { 765, toServer }
        };
        
        PacketsToClient = new Dictionary<int, PacketsDictionary>
        {
            { 0, toClient },
            { 765, toClient }
        };
        
    }
    
    public T GetToClient<T>(ConnectionState connectionState, int packetId, int version) where T : IPacket
    {
        IPacket packetType = PacketsToClient[version].GetByConnectionState(connectionState)[packetId];
        return (T)packetType.CreateNew();
    }
    
    public T GetToServer<T>(ConnectionState connectionState, int packetId, int version) where T : IPacket
    {
        IPacket packetType = PacketsToServer[version].GetByConnectionState(connectionState)[packetId];
        return (T)packetType.CreateNew();
    }
}