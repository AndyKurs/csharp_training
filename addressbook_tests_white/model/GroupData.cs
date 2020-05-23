using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace addressbook_tests_white
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public string Name { get; set;  }

        public int CompareTo([AllowNull] GroupData other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals([AllowNull] GroupData other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
