namespace TaskApp_console
{
    /// <summary>
    /// Определение методов работы с задачами
    /// </summary>
    public interface ITaskMethods
    {
        public void PrintTasks(List<string> taskList);
        public void AddTasks(List<string> taskList, string taskName);
        public void RemoveTask(List<string> taskList, int? taskId);
    }

    /// <summary>
    /// Реализация методов работы с задачами
    /// </summary>
    public class TaskMethods : ITaskMethods
    {

        private readonly ILogger _logger;

        public TaskMethods(ILogger logger)
        {
            _logger = logger;
        }
        public void PrintTasks(List<string> TaskList)
        {
            int i = 0;
            System.Console.WriteLine();
            foreach (var task in TaskList)
            {
                i++;
                System.Console.WriteLine($"{i}: {task}");
            }
            System.Console.WriteLine();
        }

        public void AddTasks(List<string> taskList , string taskName)
        {
            try
            {
                if (string.IsNullOrEmpty(taskName)) throw new ArgumentException("String is Empty or null!");
                ArgumentNullException.ThrowIfNull(taskList);

                taskList.Add(taskName);
            }
            catch (Exception ex)
            {
                _logger.Error($"AddTask Exception: {ex.Message}");
            }
        }

        public void RemoveTask(List<string> taskList, int? taskId)
        {
            try
            {
                if (taskList.Count == 0 || taskList is null) throw new ArgumentException("Task List is null or empty!");
                if (taskId is null || taskId == 0) throw new ArgumentNullException("Task ID is null or equal to zero!");

                taskList.Remove(taskList[(int)taskId - 1]);
            }
            catch (Exception ex)
            {
                _logger.Error($"RemoveTask Exception: {ex.Message}");
            }
        }
    }
}