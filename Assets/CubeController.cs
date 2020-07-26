using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;
    // 消滅位置
    private float deadLine = -10;
    //AudioClipを取得
    public AudioClip block;
    //AudioSourceを入れる箱
    AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        //AudioSourceのComponentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter2D(Collision2D other)
    {

        //衝突したオブジェクトによって衝突音を再生
        if (other.gameObject.tag == "CubeTag" || other.gameObject.tag == "GroundTag")
        {
            //AudioClipeの音を再生
            audioSource.Play();
        }

    }
}