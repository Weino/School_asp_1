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
            using (var scope = host.Services.CreateScope())
            {
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
                    new Event(){Title="IFK - MMF", Description="Omgång 1 Allsvenskan", Place="Gamla Ullevi" , Date=new DateTime(2022,4,1),SpotsAvailable=100},
                    new Event(){Title="IFK - KFF", Description="Omgång 2 Allsvenskan", Place="Gamla Ullevi", Date=new DateTime(2022,4,7), SpotsAvailable=1203},
                    new Event(){Title="AIK - IFK", Description="Omgång 3 Allsvenskan", Place="Friends Arena", Date=new DateTime(2022,4,7), SpotsAvailable=1203}
                });

                context.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
