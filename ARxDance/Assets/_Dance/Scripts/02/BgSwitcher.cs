using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSwitcher : MonoBehaviour
{

    [SerializeField] private Material _bgMat;
    private GUIStyle _style;

    // Start is called before the first frame update
    void Start()
    {
        _bgMat.SetColor("_Color",Color.white);
    }

    private void OnGUI(){
        
        if(_style==null){

            _style = new GUIStyle(GUI.skin.button);
            _style.fontSize = 22;
            _style.normal.textColor = Color.white;
            
        }

        var col = _bgMat.GetColor("_Color");
        if( GUI.Button(new Rect(0, Screen.height-200, 100, 100),"BG\n"+(col==Color.white),_style) ){
             
            _bgMat.SetColor("_Color", 
                col==Color.white ? Color.black : Color.white
            );
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
