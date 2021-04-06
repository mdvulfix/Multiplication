using UnityEngine;

public static class HandlerSceneObject
{

    public static GameObject Create(string name, string parent = null, GameObject prefab = null)
    {
        
        GameObject obj;
        
        if(prefab!=null)
        {
            obj =  GameObject.Instantiate(prefab);
            obj.name = name;
        }
        else
            obj =  new GameObject(name);

        if(parent!=null)
        {
            var objParent = GameObject.Find(parent);
            obj.transform.SetParent(objParent.transform);
        }

        return obj;
    }


}
