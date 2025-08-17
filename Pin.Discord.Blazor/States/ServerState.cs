using Pin.Discord.Core.Entities;

namespace Pin.Discord.Blazor.State
{
    public class ServerState
    {
        public event Action OnChange;
        private List<Server> _servers = new();

        public List<Server> Servers
        {
            get => _servers;
            set
            {
                _servers = value;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
