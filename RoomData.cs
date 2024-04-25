using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

public record RoomData
{
    [JsonPropertyName("Room")]
    public Room[] Rooms { get; init; }

    public List<Reservation> Reservations { get; init; } = new List<Reservation>();

    public void AddReservation(Reservation reservation)
    {
        Reservations.Add(reservation);
    }

    public void PrintSchedule(string[] daysOfWeek, string[] timeSlots)
    {
        Console.Write(new string(' ', 9));
        foreach (var time in timeSlots)
        {
            Console.Write($"| {time,-6} ");
        }
        Console.WriteLine("|");
        PrintLine(timeSlots.Length);

        foreach (var day in daysOfWeek)
        {
            Console.Write($"{day,-9}");
            foreach (var time in timeSlots)
            {
                var roomName = Reservations.FirstOrDefault(r => r.Day == day && r.Time == time)?.Room.RoomName ?? "";
                Console.Write($"| {roomName,-6} ");
            }
            Console.WriteLine("|");
            PrintLine(timeSlots.Length);
        }
    }

    private void PrintLine(int timeSlotCount)
    {
        Console.Write(new string(' ', 9));
        for (int i = 0; i < timeSlotCount; i++)
        {
            Console.Write("+--------");
        }
        Console.WriteLine("+");
    }
}
