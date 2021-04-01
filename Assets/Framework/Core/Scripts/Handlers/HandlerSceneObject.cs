using UnityEngine;

public static class HandlerSceneObject
{

    public static GameObject Create(string name, string parent = null)
    {
        var obj =  new GameObject(name);

        if(parent!=null)
        {
            var objParent = GameObject.Find(parent);
            obj.transform.SetParent(objParent.transform);
        }

        return obj;
    }


}
