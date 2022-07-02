namespace Countdown.Model
{
    public class Information
    {
        public bool ShowMessage { get; set; } = false;

        public string Message { get; set; } = string.Empty;

        public bool ShowCountdown { get; set; } = false;

        public bool ShowClock { get; set; } = true;

        public bool AnimateBackground { get; set; } = false;

        public string ApplicationUrl { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public int TentativeLeft { get; set; } = 5;

    }
}
