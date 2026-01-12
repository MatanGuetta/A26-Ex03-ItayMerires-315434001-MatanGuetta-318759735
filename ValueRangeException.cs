
namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;

        public ValueRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("Value out of range. Please enter a value between {0} and {1}", i_MinValue, i_MaxValue))
        {
            r_MinValue= i_MinValue;
            r_MaxValue= i_MaxValue;
        }

        public float MinValue
        {
            get { return r_MinValue; }
        }

        public float MaxValue
        {
            get { return r_MaxValue; }
        }

    }
}
