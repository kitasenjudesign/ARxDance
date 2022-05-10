using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class InteractiveLines2 : MonoBehaviour
{

    [SerializeField] private LineRenderer _line;
    private Vector3[] _positions;
    private int NUM = 300;
    private float _startRad = 0;

    [SerializeField] private BallVel _head;
    [SerializeField] private BallVel _handL;
    [SerializeField] private BallVel _handR;
    [SerializeField] private BallVel _footL;
    [SerializeField] private BallVel _footR;
    [SerializeField] private float _ampZ = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        _line=GetComponent<LineRenderer>();
        _line.positionCount=NUM;
        _positions = new Vector3[NUM];
    }

    // Update is called once per frame
    void Update()
    {
        var d1 = Vector3.Distance(
            _handR.transform.position,
            _handL.transform.position
        );
        var d2 = Vector3.Distance(
            _handR.transform.position,
            _footR.transform.position
        )+Vector3.Distance(
            _handL.transform.position,
            _footL.transform.position
        );
        d2*=0.3f;

        var d3 = Vector3.Distance(
            _footL.transform.position,
            _handR.transform.position
        );
        var d4 = Vector3.Distance(
            _footR.transform.position,
            _handL.transform.position
        );

        d3 = Mathf.Max(d3*2f,1f);
        d4 = Mathf.Max(d4*2f,1f);

        _startRad += _handR.smoothVelocityMag;
        _startRad += _handL.smoothVelocityMag;
        

        for(int i=0;i<NUM;i++){
            
            var rad = (float)i/(float)(NUM-1) * 2f * Mathf.PI;

            var ampX = d1*0.5f;//*Mathf.Sin(rad*d3);// + d3*0.2f * Mathf.PerlinNoise(Time.time*_positions[i].x,10f*_positions[i].y);
            var ampY = d2*0.5f;//*Mathf.Sin(rad*d3);// + d3*0.2f * Mathf.PerlinNoise(Time.time*_positions[i].x,10f*_positions[i].y);

            _positions[i] = new Vector3(
                ampX*Mathf.Cos(rad*d3+_startRad),
                ampY*Mathf.Sin(rad*d4+_startRad),
                _ampZ * Mathf.Sin(rad)
            );
        }

        _line.SetPositions(_positions);

    }
}
