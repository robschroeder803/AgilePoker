using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using AgilePoker.Server.Room;
using AgilePoker.Shared;
using ILogger = AgilePoker.Shared.ILogger;

namespace AgilePoker.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private static readonly Random Random = new();
    private Hashids HashIds { get; }
    private IRoomManager RoomManager { get; }
    private ILogger textLogger = new TextLogger();
    private ILogger sqlLogger = new SqlLogger();

    public RoomController(Hashids hashIds, IRoomManager roomManager)
    {
        HashIds = hashIds ?? throw new ArgumentNullException(nameof(hashIds));
        RoomManager = roomManager ?? throw new ArgumentNullException(nameof(roomManager));
    }


    [HttpGet("Generate")]
    public string Generate()
    {
        // create a new room
        string roomHash = HashIds.Encode(Random.Next());
        // make log of room being created
        textLogger.Log(Enums.LogLevel.Information, $"Room created: {roomHash}");
        sqlLogger.Log(Enums.LogLevel.Information, $"Room created: {roomHash}");
        return roomHash;
    }

    [HttpGet("GetNewUserRole/{RoomId}")]
    public Task<Role> GetNewUserRole(string roomId)
    {
        Task<Role> role = RoomManager.GetNewUserRoleAsync(roomId);
        return role;
    }
}
