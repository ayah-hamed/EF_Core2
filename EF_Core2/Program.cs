
namespace EF_Core2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Create Database

            // create an instance of the database context
            using EventHubContext context = new EventHubContext();

            // create the database and tables if they don't exist
            bool created = context.Database.EnsureCreated();

            // display database creation result
            if (created)
            {
                Console.WriteLine("EventHub database created successfully!");
            }
            else
            {
                Console.WriteLine("EventHub database already exists!");
            }

            #endregion

            #region Display Records

            // display the number of records in each table
            Console.WriteLine($"Organizers: {context.Organizers.Count()}");
            Console.WriteLine($"Profiles: {context.OrganizerProfiles.Count()}");
            Console.WriteLine($"Events: {context.Events.Count()}");
            Console.WriteLine($"Attendees: {context.Attendees.Count()}");
            Console.WriteLine($"Badges: {context.Badges.Count()}");

            #endregion
        }
    }
}
