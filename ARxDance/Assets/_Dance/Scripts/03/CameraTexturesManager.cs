using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
/// 
///カメラのテクスチャを管理する
public class CameraTexturesManager : MonoBehaviour
{
    [Header("カメラのテクスチャを管理する")]
    [SerializeField] private RenderTexture _camTex;
    [SerializeField] private ARCameraBackground _arBackground;
    [SerializeField] private Material _defaultMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        //Physics.gravity = new Vector3(0,-1f,0);
    }

    void OnGUI(){
        
        if(_camTex){
            GUI.DrawTexture(
                new Rect(50, 150, 100, 100), 
                _camTex, 
                ScaleMode.StretchToFill,
                false
            );              
        }

    }

    // Update is called once per frame
    void Update()
    {

        //_defaultBgMat.CopyPropertiesFromMaterial(_arBackground.material);
        if(_camTex && _arBackground){
            
            if(_arBackground.material){
            
                _defaultMaterial.CopyPropertiesFromMaterial(_arBackground.material);
                //_defaultMaterial.SetColor("_Color",Color.white);

                Graphics.Blit(
                    null,
                    _camTex,
                    _defaultMaterial
                );
            }
            
        }

    }

}
