using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string jsonFilePath = @"Data.json";
        string jsonString = File.ReadAllText(jsonFilePath);

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        RoomData roomData = JsonSerializer.Deserialize<RoomData>(jsonString, options);

        string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        string[] timeSlots = { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00" };

        CreateRandomReservations(roomData, daysOfWeek, timeSlots);

        Console.WriteLine("Initial Reservations:");
        roomData.PrintSchedule(daysOfWeek, timeSlots);

        // Example of removing the first 5 reservations
        roomData.Reservations.RemoveRange(0, Math.Min(5, roomData.Reservations.Count));
        
        Console.WriteLine("\nAfter Removing First 5 Reservations:");
        roomData.PrintSchedule(daysOfWeek, timeSlots);
    }

    static void CreateRandomReservations(RoomData roomData, string[] daysOfWeek, string[] timeSlots)
    {
        var rand = new Random();
        foreach (var room in roomData.Rooms.Take(15)) // Assuming at least 15 rooms are available
        {
            var day = daysOfWeek[rand.Next(daysOfWeek.Length)];
            var time = timeSlots[rand.Next(timeSlots.Length)];
            var reservation = new Reservation(room, day, time, "Example Event");
            roomData.AddReservation(reservation);
        }
    }
}