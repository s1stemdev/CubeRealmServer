namespace CubeRealm.Network.Base.API;

public enum ConnectionState
{
    Handshake = 0,
    Status = 1, 
    Login = 2,
    Configuration = 3,
    Play = 4
}