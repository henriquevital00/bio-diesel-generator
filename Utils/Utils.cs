using System;

public static class Utils
{
    public  static double RandomNumber(double min, double max)
    {
        Random rand = new Random();
        return (rand.NextDouble() * (max - min) + min);
    }

    public static T GetValueByProperty<T>(object obj, string property)
    {
        return (T) obj.GetType().GetProperty(property).GetValue(obj, null);
        //return (T)Convert.ChangeType(obj.GetType().GetProperty(property).GetValue(obj, null), typeof(T));
    }
}
