using Logging;

namespace LoggerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            logger.LogInfo("Je mets une info.");
            logger.LogError("J'ai eu une erreur.");
        }
    }
}
