using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnabler : MonoBehaviour
{
    [SerializeField] GameObject _roboto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _roboto = GameObject.Find("ace_PLY");
        if(_roboto != null){
            var g = _roboto.GetComponent<SkinnedMeshRenderer>();
            g.enabled=true;
        }
       
    }
}
