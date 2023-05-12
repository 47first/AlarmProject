namespace AlarmProject
{
    public class AlarmEvent
    {
        public DateTime Time { get; private set; }
        public Action Action { get; set; }
        internal CancellationTokenSource CancellationTokenSource { get; set; }

        public AlarmEvent(DateTime time, Action action)
        {
            Time = time;
            Action = action;
        }

        internal void Invoke() => Action();

        public void ChangeTime(DateTime newTime)
        {
            Time = newTime;

            Disable();

            Alarm.SetOn(this);
        }

        public void Disable() => CancellationTokenSource?.Cancel();
    }
}
