using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SkinnedMeshEnabler : MonoBehaviour
{
    private SkinnedMeshRenderer _meshRenderer;
    private GUIStyle _style;
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<SkinnedMeshRenderer>();

    }

    private void OnGUI(){
        
        if(_style==null){
            _style = new GUIStyle(GUI.skin.button);
            _style.fontSize = 22;
            _style.normal.textColor = Color.white;
        }
        if( GUI.Button(new Rect(0f, Screen.height-300f, 100f, 100f),"SKIN",_style) ){
            _meshRenderer.enabled = !_meshRenderer.enabled;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
