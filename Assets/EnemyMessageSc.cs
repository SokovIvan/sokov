using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMessageSc : MonoBehaviour
{
    public string[] s;
    public Text m;
    int x = 0;
    public float stt; 
    public float endt;
    float t;
    // Update is called once per frame
    private void Start()
    {
       t = Time.time;  
    }
    void Update()
    {

        if (Time.timeSinceLevelLoad > stt)
        {
            
            GetComponent<SpriteRenderer>().enabled = true;
            m.gameObject.SetActive(true);
                    if (Time.time - t > 10&&x<s.Length)
        {
            m.text = s[x];
            t = Time.time;
            x++;            
        }

        }

        if (Time.timeSinceLevelLoad > endt)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            m.gameObject.SetActive(false);
        }

        }
}
