using System;

namespace UserDefinedException
{
    class TestTemperature
    {
        static void Main(string[] args)
        {
            Temperature temp = new Temperature();
            try
            {
                temp.showTemp();
            }
            catch (TempIsZeroException e)
            {
                Console.WriteLine("TempIsZeroException: {0}", e.Message);
            }
        }
    }
}
public class TempIsZeroException : Exception
{
    public TempIsZeroException(string message) : base(message)
    {
    }
}
public class Temperature
{
    int temperature = 0;

    public void showTemp()
    {

        if (temperature == 0)
        {
            throw (new TempIsZeroException("Zero Temperature found"));
        }
        else
        {
            Console.WriteLine("Temperature: {0}", temperature);
        }
    }
}