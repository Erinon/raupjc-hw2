using System;
using System.Collections.Generic;

namespace Razredi.Zad2
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted => DateCompleted.HasValue;
        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            Text = text;
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }

            return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || obj?.GetType() != GetType())
            {
                return false;
            }

            return ((TodoItem)obj).Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            var hashCode = -555332867;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 + IsCompleted.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime?>.Default.GetHashCode(DateCompleted);
            hashCode = hashCode * -1521134295 + DateCreated.GetHashCode();
            return hashCode;
        }

    }
}