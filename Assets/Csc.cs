using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Csc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {  
    }
    public void onClick1()
    {
Application.Quit();
    }
    public void onClick2()
    {
Application.LoadLevel(9);
    }
}
