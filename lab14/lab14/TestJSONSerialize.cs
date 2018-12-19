using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace lab14
{
    [DataContract]
    public class TestJSONSerialize
    {
        [DataMember]
        public int IntProperty { get; set; }
        [DataMember]
        public string StrProperty { get; set; }
    }
}
