using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObject : GavityObject
{
    [SerializeField, Tooltip("�C���X�^���X����e")] private BulletObject bullet;
    [SerializeField, Tooltip("�����G�t�F�N�g1")] private GameObject exploisonEffect1;
    [SerializeField, Tooltip("�����G�t�F�N�g2")] private GameObject exploisonEffect2;
    [SerializeField, Tooltip("�n��")] private GameObject ground;
    [SerializeField, Tooltip("�ˌ�UI")] private BulletUI bulletUI;
    [SerializeField, Tooltip("�ړ����x")] private float speed = 200;
    [SerializeField, Tooltip("��]���x")] private float ySpeed = 2;

    [SerializeField, Tooltip("�e���˃L�[")] private KeyCode bulletKey = KeyCode.Return;
    [SerializeField, Tooltip("����̓L�[")] private KeyCode upKey = KeyCode.UpArrow;
    [SerializeField, Tooltip("�����̓L�[")] private KeyCode downKey = KeyCode.DownArrow;
    [SerializeField, Tooltip("�����̓L�[")] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField, Tooltip("�E���̓L�[")] private KeyCode rightKey = KeyCode.RightArrow;

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
        //����ł����珈�����s��Ȃ�
        if (isDead == true) return;
        bool input = false; // �������͖h�~�p�ϐ�
        float moveSpeed = 0;
        Vector3 Inputdir = Vector3.zero;

        if (Input.GetKeyDown(bulletKey))           // Enter�L�[����
        {
            if (bulletUI.GetBulletsCount() > 0)                          //���e���c���Ă�ꍇ
            {
                Debug.Log($"bullet={bulletUI.GetBulletsCount()}");
                // �e���C���X�^���X����
                BulletObject instance = Instantiate(bullet, transform.position + transform.forward + Vector3.up, Quaternion.identity);
                instance.GetComponent<BulletObject>().shooterName = enemyTag;
                instance.transform.rotation = transform.rotation;
                instance.direction = transform.forward;                             // �C���X�^���X�����e�̕��������g�Ɠ������̂ɂ���
                                                                                    //instance.tag = gameObject.tag + "Bullet";
                bulletUI.UseBullets(1);                                             //�G�l���M�[�g�p
                                                                                    //input = true;                                                       // ���͍ς݂ɕύX
            }
        }
        if (Input.GetKey(upKey) && !input)      // �����
        {
            //transform.position += transform.forward * speed * Time.deltaTime;   // �����ɑ��x���������ʈړ�����
            //input = true;
            moveSpeed = speed;
        }
        else if (Input.GetKey(downKey) && !input)    // ������
        {
            //transform.position -= transform.forward * speed * Time.deltaTime;   // �t�����ɑ��x���������ʈړ�����
            //input = true;
            moveSpeed = -speed;
        }
        else if (Input.GetKey(leftKey) && !input)    // ������
        {
            //transform.Rotate(0, -1f, 0);                                        // y���ɋt��]
            //input = true;
            Inputdir = new Vector3(0, -ySpeed * Time.deltaTime, 0);

        }
        else if (Input.GetKey(rightKey) && !input)   // �E����
        {
            //transform.Rotate(0, 1f, 0);                                         // y���ɉ�]
            Inputdir = new Vector3(0, ySpeed * Time.deltaTime, 0);
        }
        // ��]�̃N�H�[�^�j�I���쐬
        Quaternion addAngle = Quaternion.AxisAngle(transform.up, Inputdir.y);
        var angleAxis = Quaternion.AngleAxis(moveSpeed * Time.deltaTime, transform.right) * addAngle;
        // �~�^���̈ʒu�v�Z
        var pos = transform.position;
        pos -= centerPos;
        pos = angleAxis * pos;
        pos += centerPos;
        transform.position = pos;
        //�����X�V
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
                Debug.Log("����");
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
