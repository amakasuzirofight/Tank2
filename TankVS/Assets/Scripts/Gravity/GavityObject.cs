using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavityObject : MonoBehaviour
{
    [SerializeField] private GameObject target;

    void FixedUpdate()
    {
        // ¯‚ÉŒü‚©‚¤Œü‚«‚Ìæ“¾
        var direction = target.transform.position - transform.position;
        direction.Normalize();

        // ‰Á‘¬“x—^‚¦‚é
        GetComponent<Rigidbody>().AddForce(9.81f * direction, ForceMode.Acceleration);
    }
}
