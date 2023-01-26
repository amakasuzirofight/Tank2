using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavityObject : MonoBehaviour
{
    [SerializeField] private GameObject target;

    void FixedUpdate()
    {
        // ���Ɍ����������̎擾
        var direction = target.transform.position - transform.position;
        direction.Normalize();

        // �����x�^����
        GetComponent<Rigidbody>().AddForce(9.81f * direction, ForceMode.Acceleration);
    }
}
