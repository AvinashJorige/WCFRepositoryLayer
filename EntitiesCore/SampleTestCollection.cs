using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EntitiesCore
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public string streetAddress { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string postalCode { get; set; }
    }

    [DataContract]
    public class PhoneNumber
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string number { get; set; }
    }

    [DataContract]
    public class SampleTestCollection : EntityBase
    {
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public int age { get; set; }
        [DataMember]
        public Address address { get; set; }
        [DataMember]
        public List<PhoneNumber> phoneNumber { get; set; }
    }
}
