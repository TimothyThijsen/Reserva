using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ComboBoxItem
    {
        string displayValue;
        string hiddenValue;

        // Constructor
        public ComboBoxItem(string displayValue, string hiddenValue)
        {
            this.displayValue = displayValue;
            this.hiddenValue = hiddenValue;
        }

        // Accessor
        public string HiddenValue
        {
            get
            {
                return hiddenValue;
            }
        }

        // Override ToString method
        public override string ToString()
        {
            return displayValue;
        }
    }
}
