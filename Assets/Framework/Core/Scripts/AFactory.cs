using System;
using System.Collections.Generic;

namespace Core
{
    public interface IFactory
    {
        T Get<T>(params object[] args);

    }

    public abstract class AFactory : IFactory
    {
        public abstract T Get<T>(params object[] args);




    }
}