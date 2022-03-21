using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlSC : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 mousePosClick1;
    Vector3 mousePosClick2;
    public GameObject G;
    public GameObject h;
    public GameObject h2;
    public GameObject Soldier;
    public GameObject can;
    public GameObject can2;
    public GameObject can3;
    public GameObject can4;
    public GameObject can5;
    public GameObject can6;
    public GameObject can7;
    public GameObject can8;
    public GameObject can9;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam1;
    float n;
    float timii;
    float time2;
    float sp1 = 0;
    float sp2 = 0;
    float rfc = 0;
    // Start is called before the first frame update
    void Start()
    {

        can.SetActive(false);
        can2.SetActive(false);
        can3.SetActive(false);
        can4.SetActive(false);
        can5.SetActive(false);
        can6.SetActive(false);
        can7.SetActive(false);
        can8.SetActive(false);
        can9.SetActive(false);
        //cam2.SetActive(false);
        cam3.SetActive(false);
        n = 1;
        timii = 0;
        time2 = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - time2) > 10)
        {
            cam2.SetActive(false);
            cam3.SetActive(true);
        }
        if ((Time.time - time2) > 20)
        {
            cam3.SetActive(false);            
        }
        GameObject[] goArray;
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position.x > -10) && (goArray[i].transform.position.x < 10) && (goArray[i].transform.position.y > 20) && (goArray[i].transform.position.y < 30) && (rfc == 0))
            {
                rfc = 1;
                cam1.SetActive(true);
            }
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
                Instantiate(G, new Vector3(nn, mousePosClick1.y, 0), Quaternion.identity);
                Instantiate(G, new Vector3(nn, mousePos.y, 0), Quaternion.identity);
                nn += 1;
            }
            }
            else
            {
                while (nn > mousePos.x)
                {
                    Instantiate(G, new Vector3(nn, mousePosClick1.y, 0), Quaternion.identity);
                    Instantiate(G, new Vector3(nn, mousePos.y, 0), Quaternion.identity);
                    nn -= 1;
                }
            }
            nn = mousePosClick1.y;
            if (nn > mousePos.y)
            { 
            while (nn > mousePos.y)
            {
                Instantiate(G, new Vector3(mousePosClick1.x, nn, 0), Quaternion.identity);
                Instantiate(G, new Vector3(mousePos.x, nn, 0), Quaternion.identity);
                nn -= 1;
            }
            }
            else
            {
                while (nn < mousePos.y)
                {
                    Instantiate(G, new Vector3(mousePosClick1.x, nn, 0), Quaternion.identity);
                    Instantiate(G, new Vector3(mousePos.x, nn, 0), Quaternion.identity);
                    nn += 1;
                }
            }

        }
        if ((Time.time-time2) - timii > 20)
        {
            cam1.SetActive(false);
            can.SetActive(false);
            can2.SetActive(false);
            can3.SetActive(false);
            can4.SetActive(false);
            can5.SetActive(false);
            can6.SetActive(false);
            can7.SetActive(false);
            can8.SetActive(false);
            can9.SetActive(false);
        }
        if ((Time.time - time2) - timii > 30)
        {
            timii = Time.time - time2;
        float h=Random.Range(-50,50);
        if (h == 1)
        {
            can.SetActive(true);
        }
        if (h == 2)
        {
            can2.SetActive(true);
        }
        if (h == 3)
        {
            can3.SetActive(true);
        }
        if (h == 4)
        {
            can4.SetActive(true);
        }
        if (h == 5)
        {
            can5.SetActive(true);
        }
        if (h == 6)
        {
            can6.SetActive(true);
        }
        if (h == 7)
        {
            can7.SetActive(true);
        }
        if (h == 8)
        {
            can8.SetActive(true);
        }
        if (h == 9)
        {
            can9.SetActive(true);
        }
        }
    }
}
