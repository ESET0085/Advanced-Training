using College_App.Model.Mylogger;

namespace College_App.Model.Mylogger
{
    public class LogtoFile : IMylogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogtoFile");
        }
    }
   
        
}
