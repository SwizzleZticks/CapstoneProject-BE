using System.Text.Json.Serialization;

namespace Capstone_BE.Models;

public class TimeLine
{
    [JsonPropertyName("days")] 
    public List<Day> Days { get; set; } = new List<Day>();
}