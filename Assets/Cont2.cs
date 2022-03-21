using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cont2 : MonoBehaviour
{
    public UnityEngine.UI.Text label;
    Vector3 mousePos;
    Vector3 mousePosClick1;
    Vector3 mousePosClick2;
    public GameObject G;
    public GameObject cam;
    float n;
    float timii;
    float time2;
    float sp1 = 0;
    float sp2 = 0;
    float rfc = 0;
    public UnityEngine.UI.Button button1;
    public UnityEngine.UI.Button button2;
    public UnityEngine.UI.Button button3;
    public UnityEngine.UI.Button button4;
    public UnityEngine.UI.Button button5;
    public UnityEngine.UI.Button button6;
    // Start is called before the first frame update
    void Start()
    {
        n = 1;
        timii = 0;
        time2 = Time.time;
        button1.onClick.AddListener(delegate
        {
            button3.gameObject.SetActive(true);
            button4.gameObject.SetActive(true);
            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
        });
        button2.onClick.AddListener(delegate
        {
            button3.gameObject.SetActive(false);
            button4.gameObject.SetActive(false);
            button5.gameObject.SetActive(true);
            button6.gameObject.SetActive(true);
        });
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - time2 <= 900)
        {
            label.text = "Осталось продержаться: " + ((int)(900 - Time.time + time2)); 
        }
        if (Time.time - time2 > 900)
        {
            cam.SetActive(true);
            GameObject[] goArray;            
            goArray = GameObject.FindGameObjectsWithTag("Robots");
            for (int i = 0; i < goArray.Length; i++)
            {
                Destroy(goArray[i]);
            }
        }
        if (Time.time - time2 > 905&&rfc==0)
        {
            rfc = 1;
            Statistics stat = GameObject.Find("Stat").GetComponent<Statistics>();
            stat.t = 0;            
        }
        if (Time.time - time2 > 910)
        {
            Application.LoadLevel(10);
        }
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if ((Input.GetMouseButtonDown(0)) && (n == 1))
        {
            mousePosClick1 = mousePos;
            n = 2;
        }
        else if ((Input.GetMouseButtonUp(0)) && (n == 2))
        {
            mousePosClick2 = mousePos;
            n = 1;
            mousePosClick1 = mousePos;
            mousePosClick2 = mousePos;
        }
        if (n == 2)
        {
            float nn = mousePosClick1.x;
            if (nn < mousePos.x)
            {
                while (nn < mousePos.x)
                {
                    //Instantiate(G, new Vector3(nn, mousePosClick1.y, 0), Quaternion.identity);
                    //Instantiate(G, new Vector3(nn, mousePos.y, 0), Quaternion.identity);
                    nn += 1;
                }
            }
            else
            {
                while (nn > mousePos.x)
                {
                    //Instantiate(G, new Vector3(nn, mousePosClick1.y, 0), Quaternion.identity);
                    //Instantiate(G, new Vector3(nn, mousePos.y, 0), Quaternion.identity);
                    nn -= 1;
                }
            }
            nn = mousePosClick1.y;
            if (nn > mousePos.y)
            {
                while (nn > mousePos.y)
                {
                    //Instantiate(G, new Vector3(mousePosClick1.x, nn, 0), Quaternion.identity);
                    //Instantiate(G, new Vector3(mousePos.x, nn, 0), Quaternion.identity);
                    nn -= 1;
                }
            }
            else
            {
                while (nn < mousePos.y)
                {
                    //Instantiate(G, new Vector3(mousePosClick1.x, nn, 0), Quaternion.identity);
                    //Instantiate(G, new Vector3(mousePos.x, nn, 0), Quaternion.identity);
                    nn += 1;
                }
            }
        }
    }
}
