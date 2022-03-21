using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContB : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 mousePosClick1;
    Vector3 mousePosClick2;
    public GameObject G;
    public GameObject cir;
    float n;
    float timii;
    float time2;
    float sp1 = 0;
    float sp2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        n = 1;
        timii = 0;
        time2 = Time.time;

    }
    // Update is called once per frame
    void Update()
    {
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
            GameObject[] gg = GameObject.FindGameObjectsWithTag("Allies");
            foreach (GameObject t in gg)
            {
                if ((((t.transform.position.x > mousePosClick1.x) && (t.transform.position.x < mousePosClick2.x)) || ((t.transform.position.x < mousePosClick1.x) && (t.transform.position.x > mousePosClick2.x))) && (((t.transform.position.y > mousePosClick1.y) && (t.transform.position.y < mousePosClick2.y)) || ((t.transform.position.y < mousePosClick1.y) && (t.transform.position.y > mousePosClick2.y))))
                {
                    Instantiate(cir, t.transform.position, Quaternion.identity);
                }
            }
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
