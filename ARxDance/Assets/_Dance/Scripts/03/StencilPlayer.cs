using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(MeshRenderer))]

public class StencilPlayer : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    private RenderTexture _renderTexture;
    private MeshRenderer _meshRenderer;
    private Material _mat;
    void Start()
    {
        
        _renderTexture=new RenderTexture(512,512,0);
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.targetTexture = _renderTexture;

        _meshRenderer = GetComponent<MeshRenderer>();
        _mat = new Material(_meshRenderer.sharedMaterial);
        _mat.SetTexture("_MainTex",_renderTexture);
        _meshRenderer.sharedMaterial=_mat;
    }

    void Update()
    {
        


    }
}
