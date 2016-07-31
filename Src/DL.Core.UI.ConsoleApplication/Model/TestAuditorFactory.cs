using System.Data.Entity;
using DL.Core.Data.Entity.Auditing;

namespace DL.Core.UI.ConsoleApplication.Model
{
    public class TestAuditorFactory : AuditorFactoryBase
    {
        public TestAuditorFactory(DbContext contextToUse) : base(contextToUse)
        {
        }
    }
}
