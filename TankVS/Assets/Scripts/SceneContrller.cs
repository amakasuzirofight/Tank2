using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContrller : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ChangeGameScene();
        }
    }
    void ChangeGameScene()
    {
        SceneManager.LoadScene("AmaScene");
    }
}
