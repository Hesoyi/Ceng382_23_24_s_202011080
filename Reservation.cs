public record Reservation
{
    public Room Room { get; init; }
    public string Day { get; init; }
    public string Time { get; init; }
    public string ReservedFor { get; init; }

    public Reservation(Room room, string day, string time, string reservedFor)
    {
        Room = room;
        Day = day;
        Time = time;
        ReservedFor = reservedFor;
    }
}
