using asp_assign_1.Data;
using asp_assign_1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assign_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            SeedingDb(host);
            host.Run();
        }

        static void SeedingDb(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<EventDbContext>();

            context.Attendees.AddRange(new List<Attendee>()
            {
                new Attendee(){Name ="wille", Email="wille@gmail.se", PhoneNumber="03034213"}
            });

            context.Organizers.AddRange(new List<Organizer>()
            {
                new Organizer(){Name ="Ifkgbg", Email="ifk@gbg.se"}
            });

            context.Events.AddRange(new List<Event>()
            {
                new Event(){Title="IFK - MMF", Description="Omg�ng 1 Allsvenskan", Place="Gamla Ullevi" , Date=new DateTime(2022,4,1),SpotsAvailable=23},
                new Event(){Title="IFK - KFF", Description="Omg�ng 3 Allsvenskan", Place="Gamla Ullevi", Date=new DateTime(2022,4,7), SpotsAvailable=44},
                new Event(){Title="IFK - AIK", Description="Omg�ng 5 Allsvenskan", Place="Friends Arena", Date=new DateTime(2022,4,7), SpotsAvailable=125},
                new Event(){Title="IFK - HAIF", Description="Omg�ng 7 Allsvenskan", Place="Gamla Ullevi" , Date=new DateTime(2022,4,1),SpotsAvailable=9},
                new Event(){Title="IFK - MAIF", Description="Omg�ng 8 Allsvenskan", Place="Gamla Ullevi", Date=new DateTime(2022,4,7), SpotsAvailable=456},
                new Event(){Title="IFK - VAR", Description="Omg�ng 10 Allsvenskan", Place="Gamla Ullevi" , Date=new DateTime(2022,4,1),SpotsAvailable=663},
                new Event(){Title="IFK - IFE", Description="Omg�ng 12 Allsvenskan", Place="Gamla Ullevi", Date=new DateTime(2022,4,7), SpotsAvailable=645},
                new Event(){Title="IFK - DEG", Description="Omg�ng 14 Allsvenskan", Place="Gamla Ullevi" , Date=new DateTime(2022,4,1),SpotsAvailable=1234},
                new Event(){Title="IFK - NOR", Description="Omg�ng 16 Allsvenskan", Place="Gamla Ullevi", Date=new DateTime(2022,4,7), SpotsAvailable=2133},
            });

            context.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
