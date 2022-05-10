using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSwitcher : MonoBehaviour
{

    [SerializeField] private Material _bgMat;

    // Start is called before the first frame update
    void Start()
    {
        _bgMat.SetColor("_Color",Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        //タップされた
        if(Input.GetMouseButtonDown(0)){
            var col = _bgMat.GetColor("_Color");
            _bgMat.SetColor("_Color", 
                col==Color.white ? Color.black : Color.white
            );
        }
    }
}
