namespace AlarmProject
{
    public static class Alarm
    {
        public static CancellationTokenSource SetOn(int milliseconds, Action action)
        {
            var tokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = tokenSource.Token;

            Task.Delay(milliseconds, cancellationToken)
                .ContinueWith(t => action(), cancellationToken);

            return tokenSource;
        }

        public static CancellationTokenSource SetOn(DateTime time, Action action)
        {
            if (IsDateTimePassed(time))
                throw new ArgumentOutOfRangeException();

            int millisecondsToCall = Convert.ToInt32((time - DateTime.Now).TotalMilliseconds);

            return SetOn(millisecondsToCall, action);
        }

        public static CancellationTokenSource SetOn(TimeSpan timeSpan, Action action)
        {
            int millisecondsToCall = Convert.ToInt32(timeSpan.TotalMilliseconds);

            return SetOn(millisecondsToCall, action);
        }

        private static bool IsDateTimePassed(DateTime dateTime) => DateTime.Now > dateTime;
    }
}
