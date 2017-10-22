using System.Collections.Generic;
using System.Data.Entity;

namespace Sample.Domain.Entities
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base ("Sample") { }

        public virtual IDbSet<SampleData> SampleData { get; set; }
    }
}
