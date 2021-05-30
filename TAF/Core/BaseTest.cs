using Serilog;

namespace Core
{
    public abstract class BaseTest
    {
        static BaseTest()
        {
            Logger.Log = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File("log.txt")
               .CreateLogger();
        }
    }
}
