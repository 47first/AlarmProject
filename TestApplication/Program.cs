using AlarmProject;

Alarm.AddEvent(DateTime.Now + TimeSpan.FromSeconds(1), () => Console.WriteLine("Hello world"));