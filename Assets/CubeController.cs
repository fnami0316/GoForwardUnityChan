using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // audiosourceコンポーネント
    private AudioSource audioSource;

    // AudioClip
    public AudioClip se;

    // Use this for initialization
    void Start() {
        // AudioSourceコンポーネント取得
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if(transform.position.x < this.deadLine) {
            Destroy(gameObject);
        }
    }

    // 2Dオブジェクトの衝突検知
    private void OnCollisionEnter2D(Collision2D collision) {

        Debug.Log(collision.gameObject.name);

        // 衝突したオブジェクトがCubeもしくはGroundだった場合
        if(collision.gameObject.name == "CubePrefab(Clone)"
            || collision.gameObject.name == "ground") {

            // SEを鳴らす
            PlaySE();
        }
    }

    // SEを鳴らす
    private void PlaySE() {
        audioSource.PlayOneShot(se);
    }
}