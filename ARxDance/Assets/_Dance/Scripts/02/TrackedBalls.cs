using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallData {
    public string name;
    public GameObject source;
    public GameObject target;
}

public class TrackedBalls : MonoBehaviour
{
    [Header("球体を体の各部位に表示する")]
    [SerializeField] public BallData[] _balls;
    [SerializeField] public MeshRenderer[] _objs;
    private GUIStyle _style;
    private bool _enabled=false;

    void Start()
    {

    }


    private void OnGUI(){
        
        if(_style==null){

            _style = new GUIStyle(GUI.skin.button);
            _style.fontSize = 22;
            _style.normal.textColor = Color.white;
            
        }

        if( GUI.Button(new Rect(0, Screen.height-100, 100, 100),"BALL\n"+_objs[0].enabled,_style) ){
            for(int i=0;i<_objs.Length;i++){
                _objs[i].enabled = !_objs[i].enabled;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<_balls.Length;i++){
            
            if(_balls[i].source==null){
                
                _balls[i].source = GameObject.Find(_balls[i].name);

            }else{
                _balls[i].target.transform.position
                +=(_balls[i].source.transform.position-_balls[i].target.transform.position)/2f;
            }

        }
    }
}
