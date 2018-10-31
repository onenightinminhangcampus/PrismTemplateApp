using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Model
{
    class Item
    {
        private string _property = "Property";
        private string _value = "Value";

        public string Property
        {
            get
            {
                return _property;
            }
            set
            {
                _property = value;
            }
        }
    }
}
