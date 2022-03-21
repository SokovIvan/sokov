using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Swarz : MonoBehaviour
{
    float t = 0;
    public string message;    
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && t == 0)
        {           

            t = 1;
            StartCoroutine(Example());
        }
        else if (Input.anyKeyDown&&t==1)
        {
            t = 0;
            Time.timeScale = 1;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
    }
    IEnumerator Example()
    {
        if (t == 1)
        {
        transform.Find("Panel/Text").GetComponent<Text>().text = "";
            foreach (char i in message)
            {
                yield return new WaitForSecondsRealtime(1 / 2);
                yield return new WaitForSecondsRealtime(1 / 4);
                transform.Find("Panel/Text").GetComponent<Text>().alignment=TextAnchor.UpperLeft;
                transform.Find("Panel/Text").GetComponent<Text>().fontSize=40;
                transform.Find("Panel/Text").GetComponent<Text>().resizeTextForBestFit = false;
                if (i == '|')
                {
                   transform.Find("Panel/Text").GetComponent<Text>().text += "\n";
                }
                else
                {
                transform.Find("Panel/Text").GetComponent<Text>().text += i;
                }  
         }
        }

    }


}
