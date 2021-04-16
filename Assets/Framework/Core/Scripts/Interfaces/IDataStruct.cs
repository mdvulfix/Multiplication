namespace Framework
{
    
    public interface IDataStruct<T>
    {
        void SetData(IDataStruct<T> datasSruct);


    }






}

namespace Framework.Prototype
{
    public interface ICacheable
    {



    }    
    
    public interface IData
    {



    }
    
    public interface IDataStats: IData
    {
        int ID {get; set;}

    }
    
    public interface IDataAnimation: IData
    {
        bool            UseAnimation    {get; set;}
        AnimationState  CurrentState    {get; set;}
        AnimationState  TargetState     {get; set;} 


    }
    
    public interface IDataStruct<T>
    {
        void SetData(IDataStruct<T> datasSruct);


    }

    public interface IPageDataStruct: IDataStruct<IPage>
    {
        IDataStats DataStats    {get; }
        IDataAnimation DataAnimation {get; }
        
    
        
        void SetData(IDataStats dataStats, IDataAnimation dataAnimation);
    
    }



       
    
    
    public interface IPage: IPageDataStruct
    {


    
    
    }

    public abstract class APage: IPage
    {

        public IDataStats DataStats {get; set;}
        public IDataAnimation DataAnimation {get; set;}


        public abstract void SetData(IDataStruct<IPage> datasSruct);
        public abstract void SetData(IDataStats dataStats, IDataAnimation dataAnimation);




    }













}
