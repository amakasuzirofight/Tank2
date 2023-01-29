using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavityController : MonoBehaviour
{
    [SerializeField] private GameObject gavityCenter;

    private static GameObject gavityCenter_static;

    // Start is called before the first frame update
    void Start()
    {
        gavityCenter_static = gavityCenter;
    }

    public static Vector3 GetPos
    {
        get => gavityCenter_static.transform.position;
    }

    public static float GetRad
    {
        get => gavityCenter_static.transform.localScale.x * 0.5f;
    }
}
