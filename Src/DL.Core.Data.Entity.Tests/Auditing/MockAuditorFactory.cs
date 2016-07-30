using DL.Core.Data.Entity.Auditing;

namespace DL.Core.Data.Entity.Tests.Auditing
{
    internal class MockAuditorFactory : AuditorFactoryBase
    {
        private static readonly object threadLock = new object();

        private static MockAuditorFactory instance;

        private MockAuditorFactory()
        {
            this.AddAuditor(typeof(MockObject), typeof(AuditorBase));
        }

        public static MockAuditorFactory Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new MockAuditorFactory();
                    }
                }

                return instance;
            }
        }
    }
}
