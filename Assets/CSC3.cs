using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CSC3 : MonoBehaviour
{
    public UnityEngine.UI.Button button1;
    public UnityEngine.UI.Button button2;
    public UnityEngine.UI.Button button3;
    public UnityEngine.UI.Button buttonL;
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(delegate
        {
            PlayerPrefs.SetInt("LibC",  1);
            Application.LoadLevel(4);
        });
        button2.onClick.AddListener(delegate
        {
            if (Random.Range(0, 2) == 1)
            {
                Application.LoadLevel(8);
            }
            else
            {
                SceneManager.LoadScene("Battle2");
            }
        });
        button3.onClick.AddListener(delegate
        {
            Application.Quit();
        });
        buttonL.onClick.AddListener(delegate
        {
            Application.LoadLevel(12);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
