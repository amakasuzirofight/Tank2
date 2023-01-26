using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavityObject : MonoBehaviour
{
    [SerializeField] private GameObject target;

    void FixedUpdate()
    {
        // 星に向かう向きの取得
        var direction = target.transform.position - transform.position;
        direction.Normalize();

        // 加速度与える
        GetComponent<Rigidbody>().AddForce(9.81f * direction, ForceMode.Acceleration);
    }
}
