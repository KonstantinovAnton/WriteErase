using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User_NN_Lib
{
    public class Calculations
    {
        public string[] AvailablePeriods( TimeSpan[] startTimes, int[] durations,
            TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            if (consultationTime <= 0)
            {
                string[] ex = new string[1];
                ex[0] = "consultationTime is negative";
                return ex;
            }
               

            string[] freeTime = new string[0];
            TimeSpan[] tsFreeTime = new TimeSpan[0];

            TimeSpan drv = new TimeSpan(0, consultationTime, 0);

            for (;;)
            {
                if (beginWorkingTime >= endWorkingTime)
                    break;

                TimeSpan timeSpan = checkTime(beginWorkingTime, beginWorkingTime.Add(drv), startTimes, durations);
                if (timeSpan == new TimeSpan())
                {
                    Array.Resize(ref tsFreeTime, tsFreeTime.Length + 1);
                    tsFreeTime[tsFreeTime.Length - 1] = beginWorkingTime;
                }

                else
                {
                    TimeSpan timeSpanEnd = timeSpan.Add(-drv);
                    if (timeSpanEnd > beginWorkingTime)
                    {
                        Array.Resize(ref tsFreeTime, tsFreeTime.Length + 1);
                        tsFreeTime[tsFreeTime.Length - 1] = timeSpan.Add(-drv);
                    }
                }

                beginWorkingTime = beginWorkingTime.Add(drv);
            }


            foreach (var item in tsFreeTime)
            {
                Array.Resize(ref freeTime, freeTime.Length + 1);
                freeTime[freeTime.Length - 1] = " " + item + " - " + item.Add(drv);
            }

            return freeTime;
        }
        public static TimeSpan checkTime(TimeSpan startTime, TimeSpan endTime,
            TimeSpan[] startTimePeriod, int[] durationPeriod)
        {
            for (int i = 0; i < startTimePeriod.Length; i++)
            {
                TimeSpan startSession = startTimePeriod[i];
                TimeSpan timeAdd = new TimeSpan(0, durationPeriod[i], 0);
                TimeSpan endSession = startTimePeriod[i].Add(timeAdd);

                if (startTime < startSession.Add(new TimeSpan(0, 0, 1)))
                     if (endTime >= endSession.Add(new TimeSpan(0, 0, 1)))
                        return startSession;             
            }
            return new TimeSpan();
        }
    }
}
