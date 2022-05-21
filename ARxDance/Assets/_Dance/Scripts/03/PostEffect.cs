using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PostEffect : MonoBehaviour
{
    
    [SerializeField] private Shader _shader;
    [SerializeField] private AROcclusionManager occlusionManager;
    [SerializeField] private RenderTexture _outputTex;
    [SerializeField] private Material _outputMat;
    private Material _material;

    void Awake()
    {
        _material = new Material(_shader);
    }

    private void OnGUI(){
        if(occlusionManager && occlusionManager.humanStencilTexture){
            GUI.DrawTexture(
                new Rect(120, 120, 200, 200),
                occlusionManager.humanStencilTexture,
                ScaleMode.StretchToFill
            );
            GUI.DrawTexture(
                new Rect(120, 320, 200, 200),
                _outputTex,
                ScaleMode.StretchToFill
            );            
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        
        if(occlusionManager!=null){
            _material.SetTexture("_StencilTex",occlusionManager.humanStencilTexture);     
        }
        
        //書き込む
        Graphics.Blit(source, _outputTex, _material);

        //出力する
        Graphics.Blit(source, destination, _outputMat);

    }

}