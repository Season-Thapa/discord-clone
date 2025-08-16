namespace Pin.Discord.Blazor.State
{
    public class UserState
    {
        public int CurrentUserId { get; set; }
        public bool IsLoggedIn => CurrentUserId > 0;
    }
}
