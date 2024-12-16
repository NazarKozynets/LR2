namespace secondTask;

public class MyTime
{
    private int hour, minute, second;

    public MyTime(int h, int m, int s)
    {
        hour = h;
        minute = m;
        second = s;
    }

    public int Hour => hour;
    public int Minute => minute;
    public int Second => second;

    public override string ToString()
    {
        return $"{hour}: {minute}: {second}";
    }

    public int ToSecSinceMidnight()
    {
        return this.hour * 3600 + this.minute * 60 + this.second;
    }

    public static MyTime FromSecSinceMidnight(int t)
    {
        int h = (t / 3600) % 24;
        int m = (t % 3600) / 60;
        int s = t % 60;
        return new MyTime(h, m, s);
    }

    public MyTime AddOneSecond()
    {
        int totalSeconds = this.ToSecSinceMidnight() + 1;
        return FromSecSinceMidnight(totalSeconds);
    }

    public MyTime AddOneMinute()
    {
        int totalSeconds = this.ToSecSinceMidnight() + 60;
        return FromSecSinceMidnight(totalSeconds);
    }

    public MyTime AddOneHour()
    {
        int totalSeconds = this.ToSecSinceMidnight() + 3600;
        return FromSecSinceMidnight(totalSeconds);
    }

    public MyTime AddSeconds(int s)
    {
        int totalSeconds = this.ToSecSinceMidnight() + s;
        return FromSecSinceMidnight(totalSeconds);
    }

    public static int Difference(MyTime mt1, MyTime mt2)
    {
        return mt1.ToSecSinceMidnight() - mt2.ToSecSinceMidnight();
    }

    public static bool IsInRange(MyTime start, MyTime finish, MyTime t)
    {
        int startSec = start.ToSecSinceMidnight();
        int finishSec = finish.ToSecSinceMidnight();
        int tSec = t.ToSecSinceMidnight();

        if (startSec > finishSec)
        {
            return tSec >= startSec || tSec < finishSec;
        }

        return tSec >= startSec && tSec <= finishSec;
    }

    public string WhatLesson()
    {
        int totalSeconds = this.ToSecSinceMidnight();

        if (totalSeconds < new MyTime(8, 0, 0).ToSecSinceMidnight())
            return "пари ще не почалися";
        if (totalSeconds < new MyTime(9, 40, 0).ToSecSinceMidnight())
            return "1-а пара";
        if (totalSeconds < new MyTime(11, 20, 0).ToSecSinceMidnight())
            return "перерва між 1-ю та 2-ю парами";
        if (totalSeconds < new MyTime(13, 0, 0).ToSecSinceMidnight())
            return "2-а пара";
        if (totalSeconds < new MyTime(14, 40, 0).ToSecSinceMidnight())
            return "перерва між 2-ю та 3-ю парами";
        if (totalSeconds < new MyTime(16, 20, 0).ToSecSinceMidnight())
            return "3-я пара";
        if (totalSeconds < new MyTime(18, 0, 0).ToSecSinceMidnight())
            return "перерва між 3-ю та 4-ю парами";
        if (totalSeconds < new MyTime(19, 40, 0).ToSecSinceMidnight())
            return "4-а пара";
        if (totalSeconds < new MyTime(21, 20, 0).ToSecSinceMidnight())
            return "перерва між 4-ю та 5-ю парами";
        if (totalSeconds < new MyTime(23, 0, 0).ToSecSinceMidnight())
            return "5-а пара";
        if (totalSeconds < new MyTime(0, 40, 0).ToSecSinceMidnight())
            return "перерва між 5-ю та 6-ю парами";
        if (totalSeconds < new MyTime(2, 20, 0).ToSecSinceMidnight())
            return "6-а пара";
        return "пари вже скінчилися";
    }

}