using AlarmProject;

Alarm.SetOn(DateTime.Now + TimeSpan.FromSeconds(1), () => Console.WriteLine("Action after 1 second"));
Alarm.SetOn(TimeSpan.FromSeconds(2), () => Console.WriteLine("Action after 2 seconds"));
Alarm.SetOn(3000, () => Console.WriteLine("Action after 3 seconds"));

var task = Alarm.SetOn(DateTime.Now + TimeSpan.FromSeconds(3), () => Console.WriteLine("Hello world not to show"));

task.Cancel();

Console.WriteLine(((DateTime.Now + TimeSpan.FromSeconds(6)) - DateTime.Now).TotalMilliseconds);

Thread.Sleep(7000);