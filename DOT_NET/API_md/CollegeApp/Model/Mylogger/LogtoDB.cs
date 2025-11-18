namespace College_App.Model.Mylogger
{
    public class LogtoDB : IMylogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogtoDB");
        }
    }
}
