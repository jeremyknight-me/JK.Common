using System;
using System.Data.Entity;
using System.Linq;
using DL.Core.UI.ConsoleApplication.Model;

namespace DL.Core.UI.ConsoleApplication
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                TestCreationAudit();
                TestModificationAudit();
                TestDeletionAudit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static void TestCreationAudit()
        {
            var test = new EntityTest {Title = "Some title.", Name = "John Doe"};

            using (var context = GetContext())
            {
                context.EntityTests.Add(test);
                context.SaveChanges("jdoe");
            }
        }

        private static void TestModificationAudit()
        {
            using (var context = GetContext())
            {
                var entity = context.EntityTests.FirstOrDefault();
                entity.Title = "Some New Title";
                entity.Name = "Jane Deaux";
                context.SaveChanges("jdoe");
            }
        }

        private static void TestDeletionAudit()
        {
            using (var context = GetContext())
            {
                var entity = context.EntityTests.FirstOrDefault();
                context.EntityTests.Remove(entity);
                context.SaveChanges("jdoe");
            }
        }

        private static TestContext GetContext()
        {
            Database.SetInitializer<TestContext>(null);
            return new TestContext();
        }
    }
}
