using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DeserializeArray
{
    public partial class Model
    {
        public Model() { }

        public string RequiredString { get; set; }

        public int RequiredInt { get; set; }

        public long RequiredLong { get; set; }
                
        public float RequiredFloat { get; set; }
        
        public double RequiredDouble { get; set; }

        public bool RequiredBoolean { get; set; }

        public DateTimeOffset RequiredDateTime { get; set; }

        public TimeSpan RequiredDuration { get; set; }

        public BinaryData RequiredBytes { get; set; }

        //public IList<ChildModel> Children { get; internal set; }

        //public IList<int> Values { get; internal set; }

        //public Model ModelProperty { get; internal set; }

        internal IDictionary<string, JsonNode> UnknownProperties { get; set; }
    }
}
