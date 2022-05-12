using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PieceData {

    public Vector3 pos = new Vector3(
        6f * ( Random.value-0.5f ),
        6f * ( Random.value-0.5f ),
        6f * ( Random.value-0.5f )       
    );
    public Quaternion rot =Quaternion.Euler(0,0,0);
    public Vector3 scale = new Vector3(0.005f,0.005f,0.25f);
    public Vector3 baseScale = new Vector3(0.005f,0.005f,0.25f);
    public Vector4 uv = new Vector4();
    public Vector3 velocity = Vector3.zero;
    public float masatsu = 0.99f + 0.008f * Random.value;
    public Vector3 center = Vector3.zero;
    public float time = 0;
    public void Update(){

        pos += velocity;
        //velocity*=0.99f;
        //var mag = velocity.magnitude;
        
        var mag = velocity.sqrMagnitude;
        if(mag>0.001f*0.001f){
            rot = Quaternion.LookRotation(velocity,Vector3.up);
        }
        
        
        time+=Time.deltaTime;
        if(time>5f){
            
            scale.x*=(0-scale.x)/20f;
            scale.y*=(0-scale.y)/20f;
            scale.z*=(0-scale.z)/20f;

        }else{

            scale.x = baseScale.x;
            scale.y = baseScale.y;
            scale.z = Mathf.Min( 0.1f + mag*200f, 1f);
            
        }

        /*
        float lim = 2f;
        
        if(pos.x > center.x + lim)  pos.x = center.x  -lim;
        if(pos.x < center.x - lim)  pos.x = center.x  +lim;
        if(pos.y > center.y + lim)  pos.y = center.y  -lim;
        if(pos.y < center.y - lim)  pos.y = center.y  +lim;
        if(pos.z > center.z + lim)  pos.z = center.z  -lim;
        if(pos.z < center.z - lim)  pos.z = center.z  +lim;
        */
    }

}