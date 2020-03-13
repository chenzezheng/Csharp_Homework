using System;
using System.Threading;

namespace Clock
{
    public delegate void TickerHandler(object sender, ClockEventArgs args);
    public delegate void AlarmerHandler(object sender, ClockEventArgs args);

    public class ClockEventArgs {
        public int currentTime { get; set; }
        public ClockEventArgs(int t)
        {
            currentTime = t;
        }
    }
    public class Clock
    {
        private int currentTime = 0;
        private int[] alarmTimes;
        public event TickerHandler Ticker;
        public event AlarmerHandler Alarmer;

        public void SetAlarmTime(params int[] times)
        {
            alarmTimes = times;
            Array.Sort(alarmTimes);
        }
        public void StartTimer(int interval)
        {
            currentTime = 0;
            int index = 0;
            for(; currentTime <= interval; currentTime ++)
            {
                ClockEventArgs args = new ClockEventArgs(currentTime);
                Ticker(this, args);
                if (index < alarmTimes.Length - 1)
                {
                    if (alarmTimes[index] == currentTime)
                    {
                        Alarmer(this, args);
                    }
                    if (alarmTimes[index] < currentTime) index ++;
                }
                Thread.Sleep(1000);
            }
            Console.WriteLine("Done.");
        }
    }

    public class Form
    {
        public Clock aclock = new Clock();

        public Form()
        {
            aclock.Ticker += OnTick;
            aclock.Alarmer += OnAlarm;
        }

        void OnTick(object sender, ClockEventArgs args)
        {
            Console.WriteLine($"Current Time:{args.currentTime}");
        }

        void OnAlarm(object sender, ClockEventArgs args)
        {
            Console.WriteLine($"Alarm!!! Current Time:{args.currentTime}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Form form1 = new Form();
            form1.aclock.SetAlarmTime(5, 25, 10, 20, 15);
            form1.aclock.StartTimer(30);
        }
    }
}
