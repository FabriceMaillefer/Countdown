namespace Countdown.Model
{
    public class DownTimer
    {
        #region Constructors

        public DownTimer()
        {
            _lastRun = DateTime.UtcNow;
            _timer = new Timer(_ => tick(), null, 0, 1000);
        }

        #endregion Constructors

        #region Properties

        public TimeSpan Duration
        {
            get => _duration;
            set { _duration = value; }
        }

        public TimeSpan RemainingTime
        {
            get
            {
                if (!Elapsed)
                    return _duration - _elapsedTime;
                else
                    return TimeSpan.Zero;
            }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                return _elapsedTime;
            }
        }

        public bool Elapsed
        {
            get { return ElapsedTime >= _duration; }
        }

        public bool IsRunning => _running;

        #endregion Properties

        #region Methods

        private void tick()
        {
            if (_running)
            {
                _elapsedTime = _elapsedTime.Add(DateTime.UtcNow - _lastRun);
            }
            _lastRun = DateTime.UtcNow;
        }

        public void Stop()
        {
            _running = false;
        }

        public void Start()
        {
            _lastRun = DateTime.UtcNow;
            _running = true;
        }

        public void Restart()
        {
            _lastRun = DateTime.UtcNow;
            _elapsedTime = TimeSpan.Zero;
            _running = true;
        }

        #endregion Methods

        #region Fields

        private DateTime _lastRun = DateTime.UtcNow;
        private bool _running = false;
        private TimeSpan _elapsedTime = TimeSpan.Zero;

        private TimeSpan _duration;

        private System.Threading.Timer _timer;

        #endregion Fields
    }
}