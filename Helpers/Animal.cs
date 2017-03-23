using System;
using System.Collections.Generic;
using System.Text;

namespace Cs7.Helpers
{
    public abstract class Animal
    {
        public virtual void Exist() { }
    }

    public class Hamster : Animal
    {
        public bool IsTired { get; set; }

        public void Run() { }

        public void Rest() { }
    }

    public class Duck : Animal
    {
        public void Quack() { }
    }
}
