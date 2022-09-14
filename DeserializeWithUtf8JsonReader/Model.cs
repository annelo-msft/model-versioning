using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ReadFromDeserializable
{
    public partial class Model
    {
        public Model() { }

        public string Foo { get; internal set; }
        public string Bar { get; internal set; }

        public Model ModelProperty { get; internal set; }

        internal IDictionary<string, JsonNode> UnknownProperties { get; set; }
    }
}
