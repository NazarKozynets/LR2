using Xunit;
namespace secondTask;
public class tests
    {
        [Fact]
        public void ToSecSinceMidnight_ShouldReturnCorrectSeconds()
        {
            var time = new MyTime(1, 2, 3);

            int result = time.ToSecSinceMidnight();

            Assert.Equal(3723, result);  
        }

        [Fact]
        public void FromSecSinceMidnight_ShouldReturnCorrectTime()
        {
            int totalSeconds = 3723;  

            MyTime result = MyTime.FromSecSinceMidnight(totalSeconds);

            Assert.Equal(1, result.Hour);
            Assert.Equal(2, result.Minute);
            Assert.Equal(3, result.Second);
        }

        [Fact]
        public void AddOneSecond_ShouldIncreaseTimeByOneSecond()
        {
            var time = new MyTime(1, 2, 3);

            MyTime result = time.AddOneSecond();

            Assert.Equal(1, result.Hour);
            Assert.Equal(2, result.Minute);
            Assert.Equal(4, result.Second);  
        }

        [Fact]
        public void AddOneMinute_ShouldIncreaseTimeByOneMinute()
        {
            var time = new MyTime(1, 2, 3);

            MyTime result = time.AddOneMinute();

            Assert.Equal(1, result.Hour);
            Assert.Equal(3, result.Minute);  
            Assert.Equal(3, result.Second);
        }

        [Fact]
        public void AddOneHour_ShouldIncreaseTimeByOneHour()
        {
            var time = new MyTime(1, 2, 3);

            MyTime result = time.AddOneHour();

            Assert.Equal(2, result.Hour);  
            Assert.Equal(2, result.Minute);
            Assert.Equal(3, result.Second);
        }

        [Fact]
        public void AddSeconds_ShouldCorrectlyAddSeconds()
        {
            var time = new MyTime(1, 2, 3);

            MyTime result = time.AddSeconds(3600);  

            Assert.Equal(2, result.Hour);  
            Assert.Equal(2, result.Minute);
            Assert.Equal(3, result.Second);
        }

        [Fact]
        public void Difference_ShouldReturnCorrectDifference()
        {
            var time1 = new MyTime(2, 0, 0);  
            var time2 = new MyTime(1, 0, 0);  

            int result = MyTime.Difference(time1, time2);

            Assert.Equal(3600, result); 
        }

        [Fact]
        public void IsInRange_ShouldReturnTrueForTimeInRange()
        {
            var start = new MyTime(8, 0, 0);  
            var finish = new MyTime(10, 0, 0); 
            var time = new MyTime(9, 0, 0);  

            bool result = MyTime.IsInRange(start, finish, time);

            Assert.True(result);  
        }

        [Fact]
        public void IsInRange_ShouldReturnFalseForTimeOutOfRange()
        {
            var start = new MyTime(8, 0, 0);
            var finish = new MyTime(10, 0, 0); 
            var time = new MyTime(7, 30, 0);   

            bool result = MyTime.IsInRange(start, finish, time);

            Assert.False(result);  
        }

        [Fact]
        public void WhatLesson_ShouldReturnCorrectLesson()
        {
            var time = new MyTime(9, 30, 0);  

            string result = time.WhatLesson();

            Assert.Equal("1-а пара", result);  
        }

        [Fact]
        public void WhatLesson_ShouldReturnNoLessonBefore8AM()
        {
            var time = new MyTime(7, 30, 0);  

            string result = time.WhatLesson();

            Assert.Equal("пари ще не почалися", result);  
        }
    }