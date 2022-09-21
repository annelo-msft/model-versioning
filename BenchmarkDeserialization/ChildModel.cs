﻿using System;
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
        internal ChildModel() { }

        internal ChildModel (int qux, bool thud)
        {
            Qux = qux;
            Thud = thud;
        }

        public int Qux { get; internal set; }

        public bool Thud { get; internal set; }
    }
}
