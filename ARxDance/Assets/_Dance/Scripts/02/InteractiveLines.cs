using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class InteractiveLines : MonoBehaviour
{

    [SerializeField] private LineRenderer _line;
    private Vector3[] _positions;
    private int NUM = 300;

    [SerializeField] private BallVel _head;
    [SerializeField] private BallVel _handL;
    [SerializeField] private BallVel _handR;
    [SerializeField] private BallVel _footL;
    [SerializeField] private BallVel _footR;
    

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
            _footR.transform.position,
            _handR.transform.position
        )+Vector3.Distance(
            _footL.transform.position,
            _handL.transform.position
        );
        d2*=0.3f;

        for(int i=0;i<NUM;i++){
            
            var rad = (float)i/(float)(NUM-1) * 2f * Mathf.PI;

            var ampX = d1;//*Mathf.Sin(rad*d3);// + d3*0.2f * Mathf.PerlinNoise(Time.time*_positions[i].x,10f*_positions[i].y);
            var ampY = d2;//*Mathf.Sin(rad*d3);// + d3*0.2f * Mathf.PerlinNoise(Time.time*_positions[i].x,10f*_positions[i].y);

            _positions[i] = new Vector3(
                ampX*Mathf.Cos(rad),
                ampY*Mathf.Sin(rad),
                0
            );
        }

        _line.SetPositions(_positions);

    }
}
