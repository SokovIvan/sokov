using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GemoConSc92 : MonoBehaviour
{
    public GameObject mess;
    public Text lab;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time>0&&Time.time-time>5)
        {
SceneManager.LoadScene("Sc10");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Allies")
        {
            if (time == 0)
            {
            Statistics stat = GameObject.Find("Stat").GetComponent<Statistics>();
            stat.t = 0;
             time = Time.time;
            mess.SetActive(true);
            lab.text = "Судя по этим данным,перед нами оружие невероятной мощи.С его помощью мы перевернём ход войны.";
            }

        }
    }
}
