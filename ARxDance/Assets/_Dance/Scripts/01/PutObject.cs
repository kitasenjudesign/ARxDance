using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// カメラの前にものを置く
public class PutObject : MonoBehaviour
{

    [Header("カメラの目の前にオブジェクトを置く")]
    [SerializeField] private float _Distance = 1.5f;

    void Start()
    {
        
    }

    void Update()
    {
        //画面がタッチされたら
        /*
        if(Input.touchCount >= 1){
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began){
                _SetPos();
            }
        }*/
        
        //マウスがクリックされたら
        if(Input.GetMouseButtonDown(0)){
            _SetPos();
        }
    }

    private void _SetPos(){

        Debug.Log("SetPos");

        //カメラの1.5m先におく
        var cam = Camera.main;
        transform.position
            = cam.transform.position + cam.transform.forward * _Distance;

        //カメラの方をむく
        transform.LookAt(cam.transform.position,Vector3.up);
    }



}
