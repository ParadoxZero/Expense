using System;

namespace Expense.Data
{
    public abstract class AbstractEntity
    {
        public Guid id { get; set; }
        public string DocumentType { get; set; }
        // TODO: Consistancy Field to be added.
        public AbstractEntity(string documentType)
        {
            DocumentType = documentType;
        }
    }
}