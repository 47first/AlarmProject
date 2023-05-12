using AlarmProject;

// Set On
Alarm.SetOn(DateTime.Now + TimeSpan.FromSeconds(1), () => Console.WriteLine("Action after 1 second"));
Alarm.SetOn(TimeSpan.FromSeconds(2), () => Console.WriteLine("Action after 2 seconds"));
Alarm.SetOn(3000, () => Console.WriteLine("Action after 3 seconds"));

ClearOnEnter();

// Change time
var alarmEvent = Alarm.SetOn(1000, () => Console.WriteLine("Action after 1 second"));

alarmEvent.ChangeTime(DateTime.Now + TimeSpan.FromSeconds(2));
alarmEvent.Action = () => Console.WriteLine("Action after 2 seconds");

ClearOnEnter();

// Disable
alarmEvent = Alarm.SetOn(1000, () => Console.WriteLine("--- Line to not show ---"));
alarmEvent.Disable();

ClearOnEnter();

// Change Action in time
alarmEvent = Alarm.SetOn(1000, () => Console.WriteLine("Old action"));
alarmEvent.Action = () => Console.WriteLine("New action");

ClearOnEnter();

static void ClearOnEnter()
{
    Console.ReadLine();
    Console.Clear();
}
