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
        // This should be internal so users can't access it publicly
        internal Model()
        {
        }

        internal Model(string requiredString, int requiredInt, long requiredLong, float requiredFloat, double requiredDouble, DateTimeOffset requiredDateTime, TimeSpan requiredDuration, bool requiredBoolean, List<string> requiredStringArray, List<int> requiredIntArray, List<ChildModel> requiredChildModelArray)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredLong = requiredLong;
            RequiredFloat = requiredFloat;
            RequiredDouble = requiredDouble;
            RequiredDateTime = requiredDateTime;
            RequiredDuration = requiredDuration;
            RequiredBoolean = requiredBoolean;
            RequiredStringArray = requiredStringArray;
            RequiredIntArray = requiredIntArray;
            RequiredChildModelArray = requiredChildModelArray;
        }

        public string RequiredString { get; internal set; }

        public int RequiredInt { get; internal set; }

        public long RequiredLong { get; internal set; }

        public float RequiredFloat { get; internal set; }

        public double RequiredDouble { get; internal set; }

        public bool RequiredBoolean { get; internal set; }

        public DateTimeOffset RequiredDateTime { get; internal set; }

        public TimeSpan RequiredDuration { get; internal set; }

        public IList<string> RequiredStringArray { get; internal set; }

        public IList<int> RequiredIntArray { get; internal set; }

        public IList<ChildModel> RequiredChildModelArray { get; internal set; }

        //public Model ModelProperty { get; internal set; }
    }
}
