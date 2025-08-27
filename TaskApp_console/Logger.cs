namespace TaskApp_console
{
    /// <summary>
    /// Определения метовод логгера
    /// </summary>
    public interface ILogger
    {
        public void Information(string info);
        public void Error(string error);
        public void Warning(string warning);
    }

    /// <summary>
    /// Реализация методов Логгера
    /// </summary>
    public class Logger : ILogger
    {
        public void Information(string info)
        {
            Console.WriteLine($"\n- [INFORMATION] - {info}");
        }

        public void Error(string error)
        {
            Console.WriteLine($"\n- [ERROR] - {error}");
        }

        public void Warning(string warning)
        {
            Console.WriteLine($"\n - [WARNING] - {warning}");
        }
    }
}

