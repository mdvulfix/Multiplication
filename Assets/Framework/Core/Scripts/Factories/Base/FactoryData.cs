namespace Framework.Core
{
    public interface IFactoryData: IFactory
    {
        T Get<T>() where T: IData, new();
    }
    
    public abstract class FactoryData : Factory, IFactoryData
    {

        public T Get<T>() where T: IData, new()
        {
            return new T();
        
        }
    }
}
