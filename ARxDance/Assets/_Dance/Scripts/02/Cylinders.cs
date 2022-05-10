using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinders : MonoBehaviour
{
    [SerializeField] private GameObject[] _target;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private List<GameObject> _okTarget;

    private int _frame = 0;
    // Start is called before the first frame update
    void Start()
    {
        

        _okTarget=new List<GameObject>();
        _prefabs = new List<GameObject>();
        for(int i=0;i<_target.Length-1;i++){
            _prefabs.Add(Instantiate(_prefab,transform,false));
        }
            for(int i=0;i<_target.Length;i++){
                _target[i].SetActive(false);
            }        
        _loop();
    }

    private void _loop(){

            for(int i=0;i<_target.Length;i++){
                int idx1 = Mathf.FloorToInt(Random.value * (_target.Length-1));
                int idx2 = Mathf.FloorToInt(Random.value * (_target.Length-1));

                var tmp = _target[idx1];
                _target[idx1] = _target[idx2];
                _target[idx2] = tmp;
                
            }
            for(int i=0;i<_target.Length;i++){
                _target[i].SetActive(false);
            }

            _okTarget=new List<GameObject>();
            int num = _target.Length;//Mathf.FloorToInt( 4 + (_target.Length-4)*Random.value );
            for(int i=0;i<num;i++){
                _target[i].SetActive(true);
                _okTarget.Add(_target[i]);
            }

            Invoke("_loop",2f);

    }

    // Update is called once per frame
    void Update()
    {



        //cylinder
        for(int i=0;i<_prefabs.Count;i++){
            _prefabs[i].SetActive(false);
        }

        for(int i=0;i<_okTarget.Count-1;i++){
            var p1 = _okTarget[i].transform.position;
            var p2 = _okTarget[i+1].transform.position;

            _prefabs[i].SetActive(true);
            _prefabs[i].transform.position = p1;
            var d = p2 - p1;

            _prefabs[i].transform.localScale=new Vector3(
                0.1f,
                0.1f,
                Vector3.Magnitude(d)
            );

            _prefabs[i].transform.rotation = Quaternion.LookRotation(-d,Vector3.up);
        }

    }
}
