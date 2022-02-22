namespace Countdown.Model
{
    public class Information
    {
        public bool ShowMessage { get; set; } = false;

        public string Message { get; set; } = string.Empty;

        public bool ShowCountdown { get; set; } = false;

        public bool ShowClock { get; set; } = true;

        public string ApplicationUrl { get; set; } = string.Empty;
    }
}
