using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Reminders14
{
    class Program
    {
        private static readonly ReminderManager Reminders = new ReminderManager(new Timer());

        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (string.IsNullOrEmpty(command)) continue;

                switch (command)
                {
                    case "status":
                        Console.WriteLine(
                            JsonConvert.SerializeObject(Reminders.Status, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            })
                        );
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
