using Utils;
//using UTILS = Utils.Utils;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_CurrentAmount;
        protected readonly float r_MaxAmount;

        public EnergySource(float i_MaxAmount)
        {
            m_CurrentAmount = 0f;
            r_MaxAmount = i_MaxAmount;
        }

        public float CurrentAmount
        {
            get { return m_CurrentAmount; }
            set
            {
                handleAmountAboveTheLimit(0f, value);
                m_CurrentAmount = value;
            }
        }

        private void handleAmountAboveTheLimit(float i_CurrentAmount, float i_AmountToAdd)
        {
            ThrowIfOutOfRange(i_CurrentAmount, r_MaxAmount, i_AmountToAdd);
        }

        public float MaxAmount
        {
            get { return r_MaxAmount; }
        }

        public void Fill(float i_AmountToAdd)
        {
            handleAmountAboveTheLimit(this.m_CurrentAmount, i_AmountToAdd);
            CurrentAmount += i_AmountToAdd;
        }
    }
}
