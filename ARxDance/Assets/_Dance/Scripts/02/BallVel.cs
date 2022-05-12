using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVel : MonoBehaviour
{

    private Vector3 _pastPos;
    public Vector3 velocity=Vector3.zero;
    public float velocityMag = 0;
    public Vector3 smoothVelocity=Vector3.zero;
    public float smoothVelocityMag = 0;
    public Vector3 normalizedSmoothVel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        _pastPos = new Vector3();
    }



    // Update is called once per frame
    void Update()
    {

        var p = transform.position;

        velocity = p - _pastPos;

        if( Mathf.Abs(velocity.x) > 10f ) Debug.Log("error");
        if( Mathf.Abs(velocity.y) > 10f ) Debug.Log("error");
        if( Mathf.Abs(velocity.z) > 10f ) Debug.Log("error");
        
        /*
        if(float.IsInfinity(velocity.x) || float.IsNaN(velocity.x)){
            Debug.Log(velocity.x);
        }
        if(float.IsInfinity(velocity.y) || float.IsNaN(velocity.y)){
            Debug.Log(velocity.y);
        }
        if(float.IsInfinity(velocity.z) || float.IsNaN(velocity.z)){
            Debug.Log(velocity.z);
        }*/
                


        
        velocityMag = velocity.magnitude;
        
        smoothVelocity+=(velocity-smoothVelocity)/2f;
        normalizedSmoothVel=smoothVelocity.normalized;
        smoothVelocityMag=smoothVelocity.magnitude;
        
        _pastPos = p;

    }
}
