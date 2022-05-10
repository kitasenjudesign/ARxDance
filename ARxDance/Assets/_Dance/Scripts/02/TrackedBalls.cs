using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallData {
    public string name;
    public GameObject source;
    public GameObject target;
}

public class TrackedBalls : MonoBehaviour
{
    [Header("球体を体の各部位に表示する")]
    [SerializeField] public BallData[] _balls;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<_balls.Length;i++){
            
            if(_balls[i].source==null){
                _balls[i].source = GameObject.Find(_balls[i].name);
            }else{
                _balls[i].target.transform.position
                +=(_balls[i].source.transform.position-_balls[i].target.transform.position)/2f;
            }

        }
    }
}
