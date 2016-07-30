using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Core.Data.Entity.Auditing
{
    public abstract class AuditorFactoryBase
    {
        private readonly Dictionary<Type, Type> auditors;

        protected AuditorFactoryBase()
        {
            this.auditors = new Dictionary<Type, Type>();
        }

        public IAuditor MakeAuditor(Type type)
        {
            if (!this.auditors.ContainsKey(type))
            {
                return new AuditorBase();
            }

            Type objectType = this.auditors[type];
            return (IAuditor)Activator.CreateInstance(objectType);
        }

        protected void AddAuditor(Type type, Type auditor)
        {
            if (auditor.GetInterfaces().All(x => x.FullName != typeof(IAuditor).FullName))
            {
                throw new ArgumentException("'auditor' must implement IAuditor.", "auditor");
            }

            if (!this.auditors.ContainsKey(type))
            {
                this.auditors.Add(type, auditor);
            }
        }

        protected void RemoveAuditor(Type type)
        {
            if (!this.auditors.ContainsKey(type))
            {
                throw new ArgumentOutOfRangeException("type", "Auditor not found.");
            }

            this.auditors.Remove(type);
        }
    }
}
