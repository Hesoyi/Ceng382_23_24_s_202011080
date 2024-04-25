using System.Text.Json.Serialization;

public record Room
{
    [JsonPropertyName("roomId")]
    public string RoomId { get; init; }

    [JsonPropertyName("roomName")]
    public string RoomName { get; init; }

    [JsonPropertyName("capacity")]
    public string Capacity { get; init; }
}
