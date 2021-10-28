using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Values
{
    public class LimitedValue
    {
        private float _Value;
        public float Value { 
            get { return _Value; } 
            set {
                if (Max < value)
                    value = Max;
                _Value = value;
            } 
        }

        public float Max { get; set; }

        public LimitedValue(float max = 0, float value = 0)
        {
            Max = max;
            Value = value;
        }
    }
}
