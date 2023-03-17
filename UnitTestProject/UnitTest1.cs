using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SF2022User_NN_Lib;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void negativeTest_FreePeriod_1()
        {
            TimeSpan beginWorkingTime = new TimeSpan(9, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(9, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 15;

            startTimes[1] = new TimeSpan(10, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 15;

            int consultationTime = 15;

            string notExpected =" 09:00:00 - 09:15:00";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(notExpected.Equals(actual[0]));
        }
        [TestMethod]
        public void negativeTest_FreePeriod_2()
        {
            TimeSpan beginWorkingTime = new TimeSpan(9, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(10, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 15;

            startTimes[1] = new TimeSpan(11, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 15;

            int consultationTime = 30;

            string notExpected = " 09:00:00 - 09:30:00";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(notExpected.Equals(actual[0]));
        }
        [TestMethod]
        public void negativeTest_FreePeriod_3()
        {
            TimeSpan beginWorkingTime = new TimeSpan(9, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(10, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 15;

            startTimes[1] = new TimeSpan(11, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 15;

            int consultationTime = 5;

            string notExpected = " 09:00:00 - 09:05:00";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(notExpected.Equals(actual[0]));
        }
        [TestMethod]
        public void negativeTest_insufficientTime_1()
        {
            TimeSpan beginWorkingTime = new TimeSpan(9, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(10, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 60;

            startTimes[1] = new TimeSpan(11, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 60;

            int consultationTime = 5;

            string notExpected = " 09:00:00 - 09:05:00";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(notExpected.Equals(actual[0]));
        }
        [TestMethod]
        public void negativeTest_insufficientTime_2()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(10, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 120;

            startTimes[1] = new TimeSpan(11, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 120;

            int consultationTime = 5;

            string notExpected = " 08:00:00 - 08:05:00";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(notExpected.Equals(actual[0]));
        }
        [TestMethod]
        public void negativeTest_insufficientTime_3()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(10, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 160;

            startTimes[1] = new TimeSpan(11, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 160;

            int consultationTime = 5;

            string notExpected = " 08:00:00 - 08:05:00";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(notExpected.Equals(actual[0]));
        }
        [TestMethod]
        public void negativeTest_negativeTimeConsultation_1()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(10, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 160;

            startTimes[1] = new TimeSpan(11, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 160;

            int consultationTime = -5;

            string notExpected = " 08:00:00 - 08:05:00";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(!actual.Equals(notExpected));
        }
        [TestMethod]
        public void negativeTest_negativeTimeConsultation_2()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(10, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 160;

            startTimes[1] = new TimeSpan(11, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 160;

            int consultationTime = -10;

            string notExpected = " 08:00:00 - 08:05:00";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(!actual.Equals(notExpected));
        }
        [TestMethod]
        public void positiveTest_negativeTimeConsultation_1()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(10, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 160;

            startTimes[1] = new TimeSpan(11, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 160;

            int consultationTime = -5;

            string notExpected = "consultationTime is negative";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(actual[0].Equals(notExpected));
        }
        [TestMethod]
        public void positiveTest_negativeTimeConsultation_2()
        {
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0); // 09:00 - 12:00 - время работы
            TimeSpan endWorkingTime = new TimeSpan(12, 0, 0);

            TimeSpan[] startTimes = new TimeSpan[2];
            int[] durations = new int[2];

            startTimes[0] = new TimeSpan(10, 00, 0); // занят с 09:00 - 09:15
            durations[0] = 160;

            startTimes[1] = new TimeSpan(11, 0, 0); // занят с 10:00 - 10:15
            durations[1] = 160;

            int consultationTime = -90;

            string notExpected = "consultationTime is negative";
            Calculations calculations = new Calculations();

            string[] actual = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.IsTrue(actual[0].Equals(notExpected));
        }
    }
}
