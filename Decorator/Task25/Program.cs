namespace Task25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var paymentSystem = new ElectronicPaymentSystem();
            var loyaltyProgram = new LoyaltyProgramDecorator(paymentSystem);
            var rewardsProgram = new RewardsProgramDecorator(loyaltyProgram);

            Console.WriteLine(rewardsProgram.MakePayment());

        }
    }
    public abstract class PaymentSystem
    {
        public abstract string MakePayment();
    }

    class ElectronicPaymentSystem : PaymentSystem
    {
        public override string MakePayment()
        {
            return "Payment made with Electronic Payment System";
        }
    }

    abstract class PaymentSystemDecorator : PaymentSystem
    {
        protected PaymentSystem _paymentSystem;

        public PaymentSystemDecorator(PaymentSystem paymentSystem)
        {
            this._paymentSystem = paymentSystem;
        }

        public void SetPaymentSystem(PaymentSystem paymentSystem)
        {
            this._paymentSystem = paymentSystem;
        }

        public override string MakePayment()
        {
            if (this._paymentSystem != null)
            {
                return this._paymentSystem.MakePayment();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    class LoyaltyProgramDecorator : PaymentSystemDecorator
    {
        public LoyaltyProgramDecorator(PaymentSystem paymentSystem) : base(paymentSystem)
        {
        }

        public override string MakePayment()
        {
            return $"{base.MakePayment()} and loyalty points awarded";
        }
    }

    class RewardsProgramDecorator : PaymentSystemDecorator
    {
        public RewardsProgramDecorator(PaymentSystem paymentSystem) : base(paymentSystem)
        {
        }

        public override string MakePayment()
        {
            return $"{base.MakePayment()} and rewards points awarded";
        }
    }

}
