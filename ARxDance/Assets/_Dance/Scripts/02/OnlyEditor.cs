using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyEditor : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Awake()
    {
        #if !UNITY_EDITOR
            Destroy(gameObject);
        #endif
    }

   
}
