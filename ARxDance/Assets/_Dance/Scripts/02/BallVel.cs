using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVel : MonoBehaviour
{

    private Vector3 _pastPos;
    public Vector3 velocity=Vector3.zero;
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

        /*
        Debug.DrawLine(
            transform.position, 
            transform.position + velocity.normalized,
            Color.red
        );*/

        var p = transform.position;
        velocity = p - _pastPos;
        smoothVelocity+=(velocity-smoothVelocity)/10f;
        normalizedSmoothVel=smoothVelocity.normalized;
        smoothVelocityMag=smoothVelocity.magnitude;
        
        _pastPos = p;

    }
}
