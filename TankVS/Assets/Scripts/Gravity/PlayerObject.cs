using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObject : GavityObject
{
    [SerializeField, Tooltip("インスタンスする弾")] private BulletObject bullet;
    [SerializeField, Tooltip("爆発エフェクト1")] private GameObject exploisonEffect1;
    [SerializeField, Tooltip("爆発エフェクト2")] private GameObject exploisonEffect2;
    [SerializeField, Tooltip("地面")] private GameObject ground;
    [SerializeField, Tooltip("射撃UI")] private BulletUI bulletUI;
    [SerializeField, Tooltip("移動速度")] private float speed = 200;
    [SerializeField, Tooltip("回転速度")] private float ySpeed = 2;

    [SerializeField, Tooltip("弾発射キー")] private KeyCode bulletKey = KeyCode.Return;
    [SerializeField, Tooltip("上入力キー")] private KeyCode upKey = KeyCode.UpArrow;
    [SerializeField, Tooltip("下入力キー")] private KeyCode downKey = KeyCode.DownArrow;
    [SerializeField, Tooltip("左入力キー")] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField, Tooltip("右入力キー")] private KeyCode rightKey = KeyCode.RightArrow;

    private Vector3 centerPos;
    private string enemyTag;
    private bool isDead;
    public bool is1p;
    private void Start()
    {
        isDead = false;
        if (is1p)
        {
            enemyTag = "BlueSideBullet";
        }
        else
        {
            enemyTag = "RedSideBullet";
        }
        centerPos = ground.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //死んでいたら処理を行わない
        if (isDead == true) return;
        bool input = false; // 複数入力防止用変数
        float moveSpeed = 0;
        Vector3 Inputdir = Vector3.zero;

        if (Input.GetKeyDown(bulletKey))           // Enterキー入力
        {
            if (bulletUI.GetBulletsCount() > 0)                          //撃つ弾が残ってる場合
            {
                Debug.Log($"bullet={bulletUI.GetBulletsCount()}");
                // 弾をインスタンスする
                BulletObject instance = Instantiate(bullet, transform.position + transform.forward + Vector3.up, Quaternion.identity);
                instance.GetComponent<BulletObject>().shooterName = enemyTag;
                instance.transform.rotation = transform.rotation;
                instance.direction = transform.forward;                             // インスタンスした弾の方向を自身と同じものにする
                                                                                    //instance.tag = gameObject.tag + "Bullet";
                bulletUI.UseBullets(1);                                             //エネルギー使用
                                                                                    //input = true;                                                       // 入力済みに変更
            }
        }
        if (Input.GetKey(upKey) && !input)      // 上入力
        {
            //transform.position += transform.forward * speed * Time.deltaTime;   // 向きに速度をかけた量移動する
            //input = true;
            moveSpeed = speed;
        }
        else if (Input.GetKey(downKey) && !input)    // 下入力
        {
            //transform.position -= transform.forward * speed * Time.deltaTime;   // 逆向きに速度をかけた量移動する
            //input = true;
            moveSpeed = -speed;
        }
        else if (Input.GetKey(leftKey) && !input)    // 左入力
        {
            //transform.Rotate(0, -1f, 0);                                        // y軸に逆回転
            //input = true;
            Inputdir = new Vector3(0, -ySpeed * Time.deltaTime, 0);

        }
        else if (Input.GetKey(rightKey) && !input)   // 右入力
        {
            //transform.Rotate(0, 1f, 0);                                         // y軸に回転
            Inputdir = new Vector3(0, ySpeed * Time.deltaTime, 0);
        }
        // 回転のクォータニオン作成
        Quaternion addAngle = Quaternion.AxisAngle(transform.up, Inputdir.y);
        var angleAxis = Quaternion.AngleAxis(moveSpeed * Time.deltaTime, transform.right) * addAngle;
        // 円運動の位置計算
        var pos = transform.position;
        pos -= centerPos;
        pos = angleAxis * pos;
        pos += centerPos;
        transform.position = pos;
        //向き更新
        transform.rotation = angleAxis * transform.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
          BulletObject bulletObject;
        Debug.Log($"hit={collision.gameObject.name}");
        if (collision.gameObject.TryGetComponent<BulletObject>(out bulletObject))
        {
            Debug.Log(bulletObject.shooterName);
            if (bulletObject.shooterName != enemyTag)
            {
                Debug.Log("爆発");
                var exp1 = Instantiate(exploisonEffect1);
                var exp2 = Instantiate(exploisonEffect2);
                exp1.transform.position = transform.position;
                exp2.transform.position = transform.position;
                StartCoroutine(ChangeScene());
            }

        }
        //if (other.gameObject.CompareTag(enemyTag))
    }
    IEnumerator ChangeScene()
    {
        isDead = true;
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("TitleScene");
    }
    protected override void Gravity()
    {

    }
}
