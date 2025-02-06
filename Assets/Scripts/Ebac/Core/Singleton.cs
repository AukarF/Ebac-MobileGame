using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ebac.Core.Singleton
{
   public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
   {
    public static T Instance;

    public void Awake()
    {
        if (Instance == null)
            Instance = GetComponent<T>();
        else
            Destroy(gameObject);
    }
   }

}
