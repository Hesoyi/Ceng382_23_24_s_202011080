using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

public class Room
{
    [JsonPropertyName("roomId")]
    public string RoomId { get; set; }

    [JsonPropertyName("roomName")]
    public string RoomName { get; set; }

    [JsonPropertyName("capacity")]
    public string Capacity { get; set; } 
}


public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[] Rooms { get; set; }

    public void PrintSchedule(Dictionary<(string day, string time), Room> schedule, string[] daysOfWeek, string[] timeSlots)
    {
        Console.Write(new string(' ', 9));
        foreach (var time in timeSlots)
        {
            Console.Write($"| {time} ");
        }
        Console.WriteLine("|");

        PrintLine(timeSlots.Length);

        foreach (var day in daysOfWeek)
        {
            Console.Write($"{day,-9}");
            foreach (var time in timeSlots)
            {
                if (schedule.TryGetValue((day, time), out var room))
                    Console.Write($"| {room.RoomName,-6} ");
                else
                    Console.Write("|        ");
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

        var schedule = CreateRandomSchedule(roomData.Rooms.Take(15).ToArray(), daysOfWeek, timeSlots);
        
        Console.WriteLine("İlk 15 Rezervasyon:");
        roomData.PrintSchedule(schedule, daysOfWeek, timeSlots);

        var keysToRemove = schedule.Keys.Take(5).ToList();
        foreach (var key in keysToRemove)
        {
            schedule.Remove(key);
        }

        Console.WriteLine("\n5 Rezervasyon Silindikten Sonra Kalanlar:");
        roomData.PrintSchedule(schedule, daysOfWeek, timeSlots);
    }

    static Dictionary<(string day, string time), Room> CreateRandomSchedule(Room[] rooms, string[] daysOfWeek, string[] timeSlots)
    {
        var schedule = new Dictionary<(string day, string time), Room>();
        var rand = new Random();
        foreach (var room in rooms)
        {
            var day = daysOfWeek[rand.Next(daysOfWeek.Length)];
            var time = timeSlots[rand.Next(timeSlots.Length)];
            var key = (day, time);

            while (schedule.ContainsKey(key))
            {
                day = daysOfWeek[rand.Next(daysOfWeek.Length)];
                time = timeSlots[rand.Next(timeSlots.Length)];
                key = (day, time);
            }
            schedule[key] = room;
        }
        return schedule;
    }
}