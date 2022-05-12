using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ファイル名と以下のクラス名(InstantiateObjects)が一致するようにする
public class Objects : MonoBehaviour
{
    
    [Header("interval秒ごとにオブジェクトを生成する")]
    
    //複製するprefab
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _interval = 0.5f;
    
    //カウントアップする時間
    private float _time = 0;

    //最初に１回呼ばれる
    void Start()
    {
        
    }

    //毎フレーム呼ばれる
    void Update()
    {
        //deltaTime（フレームとフレームの間の時間をカウントする）
        _time += Time.deltaTime;

        //timeが_interval秒を超えたら
        if(_time>_interval){

            _time = 0;

            //prefabを１個、インスタンス化する
            var newPrefab = Instantiate(_prefab,transform,false);

            //その位置を設定
            newPrefab.transform.localPosition=new Vector3(
                3f*(Random.value-0.5f),
                Random.value,
                3f*(Random.value-0.5f)
            );

            //そのスケールを設定
            var scale = Random.value*0.5f + 0.5f;
            newPrefab.transform.localScale=new Vector3(
                scale,
                scale,
                scale
            );

            //10秒後に消す処理
            Destroy(newPrefab.gameObject,10f);

        }
    }

}
