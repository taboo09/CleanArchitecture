using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Clean.Data.Entities;
using Clean.Infrastructure.Persistence;

namespace Clean.API.Tests.Data
{
    public class SeedDatabase
    {
        public static void Initialize<T>(CareHomeContext context) where T : class
        {
            if (context.Set<T>().Any())
            {
                return;
            }

            Seed<T>(context);
        }

        private static void Seed<T>(CareHomeContext context) where T : class
        {
            switch (typeof(T).GetTypeInfo().Name)
            {
                case "Homes":
                    context.Homes.AddRange(FakeListHomes());
                    break;
                
                case "Staffs":
                    context.Staffs.AddRange(FakeListStaffs());
                    break;

                case "Qualifications":
                    context.Qualifications.AddRange(FakeListQualifications());
                    break;
                
                default:
                    break;
            }
            
            context.SaveChanges();
        }

        private static List<Homes> FakeListHomes()
        {
            return new List<Homes> 
            {
                new Homes 
                {
                    Id = 1,
                    Name = "Test Name 1",
                    City = "Liverpool",
                    Address = "4 Local Road",
                    Email = "test@test.com",
                    Rating = 4
                },
                new Homes
                {
                    Id = 2,
                    Name = "Test Name 2",
                    City = "Bath",
                    Address = "12 Legion Road",
                    Email = "test@test.com",
                    Rating = 3
                },
                new Homes
                {
                    Id = 3,
                    Name = "Test Name 3",
                    City = "Oxford",
                    Address = "1 University Road",
                    Email = "test@test.com",
                    Rating = 2
                }
            };
        }

        private static List<Staffs> FakeListStaffs()
        {
            return new List<Staffs>() {};
        }

        private static List<Qualifications> FakeListQualifications()
        {
            return new List<Qualifications>() {};
        }
    }
}