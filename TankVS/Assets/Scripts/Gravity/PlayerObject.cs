using UnityEngine;

public class PlayerObject : GavityObject
{
    [SerializeField, Tooltip("インスタンスする弾")] private BulletObject bullet;

    [SerializeField, Tooltip("移動速度")] private float speed = 10;

    [SerializeField, Tooltip("弾発射キー")] private KeyCode bulletKey = KeyCode.Return;
    [SerializeField, Tooltip("上入力キー")] private KeyCode upKey = KeyCode.UpArrow;
    [SerializeField, Tooltip("下入力キー")] private KeyCode downKey = KeyCode.DownArrow;
    [SerializeField, Tooltip("左入力キー")] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField, Tooltip("右入力キー")] private KeyCode rightKey = KeyCode.RightArrow;

    private string enemyTag;

    private void Start()
    {
        if (gameObject.CompareTag("RedSide"))
        {
            enemyTag = "BlueSideBullet";
        }
        else
        {
            enemyTag = "RedSideBullet";
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool input = false; // 複数入力防止用変数

        if (Input.GetKeyDown(bulletKey))           // Enterキー入力
        {
            // 弾をインスタンスする
            BulletObject instance = Instantiate(bullet, transform.position + transform.forward + Vector3.up, Quaternion.identity);
            instance.transform.rotation = transform.rotation;
            instance.direction = transform.forward;                             // インスタンスした弾の方向を自身と同じものにする
            instance.tag = gameObject.tag + "Bullet";
            input = true;                                                       // 入力済みに変更
        }

        if (Input.GetKey(upKey) && !input)      // 上入力
        {
            transform.position += transform.forward * speed * Time.deltaTime;   // 向きに速度をかけた量移動する
            input = true;
        }

        if (Input.GetKey(downKey) && !input)    // 下入力
        {
            transform.position -= transform.forward * speed * Time.deltaTime;   // 逆向きに速度をかけた量移動する
            input = true;
        }

        if (Input.GetKey(leftKey) && !input)    // 左入力
        {
            transform.Rotate(0, -1f, 0);                                        // y軸に逆回転
            input = true;
        }

        if (Input.GetKey(rightKey) && !input)   // 右入力
        {
            transform.Rotate(0, 1f, 0);                                         // y軸に回転
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {

        }
    }
}
