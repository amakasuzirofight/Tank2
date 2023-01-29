using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : GavityObject
{
    [SerializeField, Tooltip("インスタンスする弾")] private BulletObject bullet;

    [SerializeField, Tooltip("移動速度")] private float speed = 10;

    // Update is called once per frame
    void Update()
    {
        bool input = false; // 複数入力防止用変数

        if (Input.GetKeyDown(KeyCode.Return))           // Enterキー入力
        {
            // 弾をインスタンスする
            BulletObject instance = Instantiate(bullet, transform.position + transform.forward + Vector3.up, Quaternion.identity);
            instance.direction = transform.forward;                             // インスタンスした弾の方向を自身と同じものにする
            input = true;                                                       // 入力済みに変更
        }

        if (Input.GetKey(KeyCode.UpArrow) && !input)    // 上入力
        {
            transform.position += transform.forward * speed * Time.deltaTime;   // 向きに速度をかけた量移動する
            input = true;
        }

        if (Input.GetKey(KeyCode.DownArrow) && !input)  // 下入力
        {
            transform.position -= transform.forward * speed * Time.deltaTime;   // 逆向きに速度をかけた量移動する
            input = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !input)  // 左入力
        {
            transform.Rotate(0, -1f, 0);                                        // y軸に逆回転
            input = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !input) // 右入力
        {
            this.transform.Rotate(0, 1f, 0);                                    // y軸に回転
        }
    }
}
