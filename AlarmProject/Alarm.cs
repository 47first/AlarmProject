namespace AlarmProject
{
    public static class Alarm
    {
        public static AlarmEvent SetOn(AlarmEvent alarmEvent)
        {
            alarmEvent.CancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = alarmEvent.CancellationTokenSource.Token;

            int millisecondsToCall = Convert.ToInt32((alarmEvent.Time - DateTime.Now).TotalMilliseconds);

            Task.Delay(millisecondsToCall, cancellationToken)
                .ContinueWith(t => alarmEvent.Invoke(), cancellationToken);

            return alarmEvent;
        }

        public static AlarmEvent SetOn(int milliseconds, Action action)
        {
            AlarmEvent alarmEvent = new(DateTime.Now + TimeSpan.FromMilliseconds(milliseconds), action);

            return SetOn(alarmEvent);
        }

        public static AlarmEvent SetOn(DateTime time, Action action)
        {
            if (IsDateTimePassed(time))
                throw new ArgumentOutOfRangeException();

            AlarmEvent alarmEvent = new(time, action);

            return SetOn(alarmEvent);
        }

        private static bool IsDateTimePassed(DateTime dateTime) => DateTime.Now > dateTime;

        public static AlarmEvent SetOn(TimeSpan timeSpan, Action action)
        {
            AlarmEvent alarmEvent = new(DateTime.Now + timeSpan, action);

            return SetOn(alarmEvent);
        }
    }
}
