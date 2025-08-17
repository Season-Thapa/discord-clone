namespace Pin.Discord.Blazor.Models
{
    public class ChatMessage
    {
        public int SenderId { get; set; } 
        public string Username { get; set; }
        public string Message { get; set; }
        public string? ChannelId { get; set; }
        public bool IsReported { get; set; } = false;
    }
}
