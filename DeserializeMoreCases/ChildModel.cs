using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DeserializeArray
{
    public partial class ChildModel
    {
        public ChildModel() { }

        public int Qux { get; internal set; }

        public bool Thud { get; internal set; }
        
        internal IDictionary<string, JsonNode> UnknownProperties { get; set; }
    }
}
