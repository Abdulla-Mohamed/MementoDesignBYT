using MementoDesignBYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MementoDesignBYT
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain c1 = new InvalidSign();
            Chain c2 = new AdditionCalculation();
            Chain c3 = new SubtractionCalculations();
            Chain c4 = new MultiplicationCalculation();
            Chain c5 = new DivisionCalculation();

            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker(originator);

            c1.setNext(c2);
            c2.setNext(c3);
            c3.setNext(c4);
            c4.setNext(c5);

            Calculation calculation = new Calculation(5, 5, "+");
            Console.WriteLine(originator.Calculate(calculation,c1).result);
            caretaker.Backup();
            calculation = new Calculation(8, 6, "-");
            Console.WriteLine(originator.Calculate(calculation,c1).result);
            caretaker.Backup();

            calculation = caretaker.Undo();
            Console.WriteLine(calculation.Arg1 + calculation.OperationSign + calculation.Arg2 + " = " + calculation.result);
            calculation = caretaker.Undo();
            Console.WriteLine(calculation.Arg1 + calculation.OperationSign + calculation.Arg2 + " = " + calculation.result);
            calculation = caretaker.Undo();
            Console.WriteLine(calculation.Arg1 + calculation.OperationSign + calculation.Arg2 + " = " + calculation.result);

        }

        class Originator
        {
            private Calculation _state;

            public Originator()
            {
                Calculation calculation = new Calculation();
                _state = calculation;
            }

            public Calculation Calculate(Calculation calclation, Chain chain)
            {
                Calculation result = chain.calculate(calclation);
                _state = result;
                return result;
            }

            // Saves the current state inside a memento.
            public IMemento Save()
            {
                return new ConcreteMemento(_state);
            }

            // Restores the Originator's state from a memento object.
            public void Restore(IMemento memento)
            {
                if (!(memento is ConcreteMemento))
                {
                    throw new Exception("Unknown memento class " + memento.ToString());
                }

               _state = memento.GetState();
            }
        }

        public interface IMemento
        {

            Calculation GetState();

        }

        public class ConcreteMemento : IMemento
        {
            private Calculation _state;


            public ConcreteMemento(Calculation state)
            {
                _state = state;
            }

            public Calculation GetState()
            {
                return _state;
            }

            public string GetName()
            {
                return _state.result.ToString();
            }
        }

        class Caretaker
        {
            private List<IMemento> _mementos = new List<IMemento>();

            private Originator _originator = null;

            public Caretaker(Originator originator)
            {
                _originator = originator;
            }

            public void Backup()
            {
                _mementos.Add(_originator.Save());
            }

            public Calculation Undo()
            {
                if (_mementos.Count == 0)
                {
                    return new Calculation();
                }

                var memento = _mementos.Last();

                _mementos.Remove(memento);

                try
                {
                    _originator.Restore(memento);
                }
                catch (Exception)
                {
                    Undo();
                }
                return memento.GetState();
            }
        }
    }

}
