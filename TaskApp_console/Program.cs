// TODO: 
// Разогрев мозга. Проект по списку задач. 
//
// Возможности проекта: 
// 
// 1) Создание задачи
// 2) Просмотр списка задач
// 3) Удаление задач
using Microsoft.Extensions.DependencyInjection;


namespace TaskApp_console
{
    class Program
    {
        private readonly ITaskMethods? _methods;

        public Program(ITaskMethods? methods)
        {
            _methods = methods;
        }
        public static void Main(string[] args)
        {
            // Создаём коллекцию сервисов
            var services = new ServiceCollection();

            // Регистрируем метод задач через интерфейс как сервис
            // И так же регистрируем основой метода Main
            services.AddScoped<ITaskMethods, TaskMethods>();
            services.AddScoped<ILogger, Logger>();
            services.AddScoped<Program>();

            // Создаём поставщика сервисов коллекции через который создадим экземпляр класса Program
            var serviceProvider = services.BuildServiceProvider();

            // Теперь можем вызывать методы, которые подключены как DI через конструктор
            var program = serviceProvider.GetRequiredService<Program>();


            // DI работает потому что мы создали объект нашего основного класса
            // Для этого нужно было зарегистрировать коллекции сервисов
            // и уже через провайдера сервисов создать объект (экземпляр класса),
            // через который их можно будет вызывать 

            List<string> TestTaskList = [];
            program._methods?.AddTasks(TestTaskList, "this");
            program._methods?.AddTasks(TestTaskList, "is");
            program._methods?.AddTasks(TestTaskList, "test");
            program._methods?.AddTasks(TestTaskList, "tasks");

            System.Console.WriteLine("До удаления");
            program._methods?.PrintTasks(TestTaskList);
            
            program._methods?.RemoveTask(TestTaskList, 1);

            System.Console.WriteLine("После удаления");
            program._methods?.PrintTasks(TestTaskList);

        }
    }
}