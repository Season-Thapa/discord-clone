namespace Pin.Discord.Blazor.Models
{
    public class ChatMessage
    {
        public string UserName { get; set; }
        public string MessageContent { get; set; }
        public string? ChannelId { get; set; }
    }
}
