using System.Collections.Generic;
using System;

namespace Expense.Data
{
    public class Metadata : AbstractEntity
    {
        public Dictionary<string, string> Configuration { get; set; }
        public Metadata() : base(nameof(Metadata))
        {
            this.id = Guid.Empty;
        }
    }
}