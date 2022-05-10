using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Particles : MonoBehaviour {

    [SerializeField] protected Mesh _mesh;
    [SerializeField] protected Material _mat;
    [SerializeField] private BallVel[] _ballVel;
    [SerializeField] private float _lim;
    [SerializeField] private float _spd=0.05f;
    [SerializeField] private bool _isNormalize=false;
    
    protected Matrix4x4[] _matrices;
    protected Vector4[] _colors;
    protected MaterialPropertyBlock _propertyBlock;
    protected int _count = 400;
    private PieceData[] _data;
    private Vector3 _target = Vector3.zero;
    private Vector3 _center;
    public const int MAX = 1023;

    void Start(){

        Application.targetFrameRate=60;

        _propertyBlock = new MaterialPropertyBlock();
        _matrices = new Matrix4x4[MAX];
        _data = new PieceData[MAX];
        _colors = new Vector4[MAX];
        //_uvs = new Vector4[MAX];

        _count=0;
        for(int i=0;i<MAX;i++){

            _matrices[_count] = Matrix4x4.identity;
            _data[_count] = new PieceData();

            _data[_count].pos.x = 2f * ( Random.value-0.5f );
            _data[_count].pos.y = 2f * ( Random.value-0.5f );
            _data[_count].pos.z = 2f * ( Random.value-0.5f );

            _data[_count].rot = Quaternion.Euler(
                0,0,0//Random.value * 360f,
                //Random.value * 360f,
                //Random.value * 360f
            );
            //_uvs[_count] = SpriteUV.GetUv(Mathf.FloorToInt(Random.value*6),4,4);
            _colors[_count] = new Vector4(
                Random.value,
                Random.value,
                Random.value,
                1f
            );
            _count++;
            
        }

    }


    void Update(){

        //var vv = _ballVel[0].velocity;
        //_target+=(_ballVel.velocity-_target)/10f;

        _center = 
        0.5f*(_ballVel[0].transform.position+_ballVel[1].transform.position);

        for (int i = 0; i < _count; i++)
        {

            for(int j=0;j<_ballVel.Length;j++){
                var d = _ballVel[j].transform.position-_data[i].pos;
                var dd = d.magnitude;//d.sqrMagnitude;
                dd = (_lim - dd)/_lim;
                if(dd<0)dd=0f;
                if(dd>1f) dd=1f;                
                _data[i].velocity += _ballVel[j].smoothVelocity*_spd*dd;
            }

            //_colors[i]=

            /*
            var d1 = _ballVel[0].transform.position-_data[i].pos;
            var d2 = _ballVel[1].transform.position-_data[i].pos;

            var v = d1.sqrMagnitude<d2.sqrMagnitude ? _ballVel[0] : _ballVel[1];
            _colors[i] = d1.sqrMagnitude<d2.sqrMagnitude ? Color.red : Color.blue;

            var vv = v.smoothVelocityMag;

            if( vv > _lim){
                if(_isNormalize) _data[i].velocity += v.normalizedSmoothVel*_spd;
                else _data[i].velocity += v.smoothVelocity*_spd;
            }*/

            _data[i].velocity *= _data[i].masatsu;
            _data[i].center = _center;
            _data[i].Update();


            _matrices[i].SetTRS(
                _data[i].pos,
                _data[i].rot,
                _data[i].scale
            );
            //_matrices[i] = transform.localToWorldMatrix * _matrices[i];

        }

        _propertyBlock.SetVectorArray("_Color", _colors);
        //_propertyBlock.SetVectorArray("_Uv", _uvs);

        Graphics.DrawMeshInstanced(
                _mesh, 
                0, 
                _mat, 
                _matrices, 
                _count, 
                _propertyBlock, 
                ShadowCastingMode.On, 
                false, 
                gameObject.layer
        );

    }

}