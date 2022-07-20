using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPropertyAccessor.Tests
{
    internal class Model
    {
        public string? Name { get; set; }

        public bool IsActive { get; set; }

        public int Value { get; set; }

        public long ValueInt64 { get; set; }

        public DateTime Date { get; set; }
    }
}
