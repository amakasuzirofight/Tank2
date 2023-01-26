using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankObject : MonoBehaviour
{
    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //var baseQuat = Quaternion.Inverse(transform.rotation);
        //transform.rotation *= Quaternion.Euler(baseQuat * distance);
    }

    // Update is called once per frame
    void Update()
    {
        var distance = target.transform.position - transform.position;
        GetComponent<Rigidbody>().velocity = distance;
        // transform.rotation *= Quaternion.LookRotation(transform.forward);
        transform.rotation *= Quaternion.AngleAxis(0,transform.forward);
    }
}
