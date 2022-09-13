using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.Core;

namespace RoundTripJsonNode
{
    public partial class Model
    {
        // These are internal in client libraries.
        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("foo");
            writer.WriteStringValue(Foo);
            writer.WritePropertyName("bar");
            writer.WriteStringValue(Bar);

            if (UnknownProperties != null)
            {
                foreach (var property in UnknownProperties)
                {
                    writer.WriteObjectValue(property);
                }
            }

            writer.WriteEndObject();

            // Needed for sample
            writer.Flush();
        }

        // These are internal in client libraries.
        public static Model Deserialize(JsonElement element)
        {
            Model model = new Model();

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("foo"))
                {
                    model.Foo = property.Value.GetString();
                    continue;
                }
                else if (property.NameEquals("bar"))
                {
                    model.Bar = property.Value.GetString();
                    continue;
                }

                // handle unknown properties
                if (model.UnknownProperties == null)
                {
                    model.UnknownProperties = new List<JsonProperty>();
                    model.UnknownProperties.Add(property);
                }
            }

            return model;
        }
    }
}
