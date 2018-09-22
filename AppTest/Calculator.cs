using System;

namespace AppTest
{
    public enum Op
    {
        Equals,
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public enum N
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine
    }

    public class Calculator
    {
        public Calculator()
        {
        }

        protected double PreviousNumber { get; set; } = 0;
        protected double CurrentNumber { get; set; } = 0;
        protected Op LastOperation { get; set; } = Op.Equals;

        public double EnterNumber(N newNumber)
        {
            CurrentNumber = CurrentNumber * 10 + (Math.Sign(CurrentNumber) >= 0 ? (int) newNumber : -(int) newNumber);
            return CurrentNumber;
        }
        public double EnterNumber(double newNumber)
        {
            if (newNumber == 0)
            {
                CurrentNumber *= 10;
                return CurrentNumber;
            }
            if (CurrentNumber == 0)
            {
                CurrentNumber = newNumber;
                return CurrentNumber;
            }

            int count = 0;
            for (; Math.Abs(newNumber) >= 1;count++)
                newNumber /= 10;

            if (Math.Sign(CurrentNumber) == Math.Sign(newNumber) || CurrentNumber == 0)
                CurrentNumber += newNumber;
            else
                CurrentNumber = Math.Sign(CurrentNumber) * 
                                Math.Sign(newNumber) *
                                (Math.Abs(CurrentNumber) + Math.Abs(newNumber));

            for (int i = 0; i < count; i++)
                CurrentNumber *= 10;

            return CurrentNumber;
        }

        public double SetOperation(Op newOperation)
        {
            switch (LastOperation)
            {
                case Op.Equals:
                    PreviousNumber = CurrentNumber;
                    break;
                case Op.Add:
                    PreviousNumber += CurrentNumber;
                    break;
                case Op.Subtract:
                    PreviousNumber -= CurrentNumber;
                    break;
                case Op.Multiply:
                    PreviousNumber *= CurrentNumber;
                    break;
                case Op.Divide:
                    if (CurrentNumber == 0)
                        throw new DivideByZeroException();
                    PreviousNumber /= CurrentNumber;
                    break;
            }

            CurrentNumber = 0;
            LastOperation = newOperation;
            
            return PreviousNumber;
        }

    }
}