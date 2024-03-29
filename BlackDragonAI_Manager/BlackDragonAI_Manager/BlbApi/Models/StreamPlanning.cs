using System;

namespace BlackDragonAI_Manager.BlbApi.Models
{
    public class StreamPlanning
    {
        public long Id { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;
        public string TimeSlot { get; set; } = string.Empty;
        public string Game { get; set; } = string.Empty;
        public string StreamType { get; set; } = string.Empty;
        public string GameType { get; set; } = string.Empty;
        public string TrailerUri { get; set; } = string.Empty;
    }
}