using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private string[] _sceneNames;
    private bool _isSelect=false;
    private GUIStyle _style;
    // Start is called before the first frame update
    void Start()
    {
        //Params.Init();
    }
    private void OnGUI()
    {

       // GUI.contentColor = Color.red;  // Apply Red color to Button
        //GUI.backgroundColor = Color.black;

        if(_style==null){

            _style = new GUIStyle(GUI.skin.button);
            _style.fontSize = 42;
            _style.normal.textColor = Color.white;
            
        }

        if (GUI.Button(new Rect(Screen.width-150, Screen.height-150, 150, 150),"X")){
            Application.Quit();
        }

        if(!_isSelect){
            for(int i=0;i<_sceneNames.Length;i++){

                if (GUI.Button(new Rect(400, 100+150*i, 400, 140),_sceneNames[i],_style)){
                    _isSelect=true;
                    SceneManager.LoadScene(_sceneNames[i],LoadSceneMode.Additive);
                    //gameObject.SetActive(false);
                }  

            }
        }

    }       

}