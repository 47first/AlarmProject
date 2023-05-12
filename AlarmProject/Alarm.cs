namespace AlarmProject
{
    public static class Alarm
    {
        public static void AddEvent(DateTime time, Action action)
        {
            if (IsDateTimePassed(time))
                return;

            int milisecondsToCall = (time - DateTime.Now).Milliseconds;

            Task.Delay(milisecondsToCall).ContinueWith(t => action());
        }

        private static bool IsDateTimePassed(DateTime dateTime) => DateTime.Now < dateTime;
    }
}