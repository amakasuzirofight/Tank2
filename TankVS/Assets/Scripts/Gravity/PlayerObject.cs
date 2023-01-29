using UnityEngine;

public class PlayerObject : GavityObject
{
    [SerializeField, Tooltip("�C���X�^���X����e")] private BulletObject bullet;

    [SerializeField, Tooltip("�ړ����x")] private float speed = 10;

    [SerializeField, Tooltip("�e���˃L�[")] private KeyCode bulletKey = KeyCode.Return;
    [SerializeField, Tooltip("����̓L�[")] private KeyCode upKey = KeyCode.UpArrow;
    [SerializeField, Tooltip("�����̓L�[")] private KeyCode downKey = KeyCode.DownArrow;
    [SerializeField, Tooltip("�����̓L�[")] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField, Tooltip("�E���̓L�[")] private KeyCode rightKey = KeyCode.RightArrow;

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
        bool input = false; // �������͖h�~�p�ϐ�

        if (Input.GetKeyDown(bulletKey))           // Enter�L�[����
        {
            // �e���C���X�^���X����
            BulletObject instance = Instantiate(bullet, transform.position + transform.forward + Vector3.up, Quaternion.identity);
            instance.transform.rotation = transform.rotation;
            instance.direction = transform.forward;                             // �C���X�^���X�����e�̕��������g�Ɠ������̂ɂ���
            instance.tag = gameObject.tag + "Bullet";
            input = true;                                                       // ���͍ς݂ɕύX
        }

        if (Input.GetKey(upKey) && !input)      // �����
        {
            transform.position += transform.forward * speed * Time.deltaTime;   // �����ɑ��x���������ʈړ�����
            input = true;
        }

        if (Input.GetKey(downKey) && !input)    // ������
        {
            transform.position -= transform.forward * speed * Time.deltaTime;   // �t�����ɑ��x���������ʈړ�����
            input = true;
        }

        if (Input.GetKey(leftKey) && !input)    // ������
        {
            transform.Rotate(0, -1f, 0);                                        // y���ɋt��]
            input = true;
        }

        if (Input.GetKey(rightKey) && !input)   // �E����
        {
            transform.Rotate(0, 1f, 0);                                         // y���ɉ�]
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {

        }
    }
}
