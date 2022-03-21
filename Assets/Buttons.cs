using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public Button but1;
    public Button but2;
    // Start is called before the first frame update
    void Start()
    {

        but1.onClick.AddListener(b1);
        but2.onClick.AddListener(b2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void b1()
    {
            SceneManager.LoadScene("Victory!!!");
    }
    void b2()
    {
            SceneManager.LoadScene("Defeat2!!!");
    }
}
