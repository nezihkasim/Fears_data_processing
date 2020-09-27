using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Q3
{
    class Person_Information
    {
        public string Fear;
        public string Greatest;
        public string Impact;
        public string Past;
        public string Encounter;
        public string Overcome;
        public string Embarrased;

        public Person_Information(string _Fear, string _Greatest, string _Impact, string _Past, string _Encounter, string _Overcome, string _Embarrased)
        {
            this.Fear = _Fear;
            this.Greatest = _Greatest;
            this.Impact = _Impact;
            this.Past = _Past;
            this.Encounter = _Encounter;
            this.Overcome = _Overcome;
            this.Embarrased = _Embarrased;
        }
    }
}
