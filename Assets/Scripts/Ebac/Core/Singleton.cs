using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ebac.Core.Singleton
{
   public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
   {
    public static T instance;

    public void Awake()
    {
        if (instance == null)
            instance = GetComponent<T>();
        else
            Destroy(gameObject);
    }
   }

}
