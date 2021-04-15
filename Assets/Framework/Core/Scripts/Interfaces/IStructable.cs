namespace Framework.Core
{
    public interface IStructable<TCacheable> where TCacheable: ICacheable
    {
        DataStruct<TCacheable> DataStruct {get; set;}
        
        void SetData(DataStruct<TCacheable> data);

    }

}
