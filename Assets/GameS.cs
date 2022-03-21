using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameS : MonoBehaviour
{

    public Text textm;
    public GameObject G;
    public GameObject t;
    public GameObject cam2;
    public GameObject sold;
    public GameObject soldier;
    public GameObject baggy;
    public GameObject cam1;
    public Statistics stat;
    Vector3 pos;
    Quaternion rot;
    Vector3 mousePos;
    Vector3 mousePosClick1;
    Vector3 mousePosClick2;
    float n;
    float b;
    float time2;
    float timii;
    // Start is called before the first frame update
    void Start()
    {
        stat = GameObject.Find("Stat").GetComponent<Statistics>();
        //GameObject.Find("Stat").SetActive(false);
        n = 1;
        time2 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (b ==2)
        {
            sold.transform.position = pos;
            sold.transform.rotation = rot;
        } 
        if (((Time.time - time2) > 10) && (b == 0))
        {
            b = 15;
            cam1.SetActive(false);  
            cam2.SetActive(true);           
            textm.text ="Выберите солдата рамкой и отдайте приказание нажатием правой кнопки мыши.Осмотрите местность около внешней заставы.";
        }
        if (((sold.transform.position - transform.position).sqrMagnitude < 10000) && (b == 14))
        {
            b = 1;
            textm.text = "Осмотрите местность с безопасного расстояния около мешков.";
        }

            if (((sold.transform.position - transform.position).sqrMagnitude < 25) && (b == 1))
        {
            pos=sold.transform.position;
            rot=sold.transform.rotation;
            b = 2;
            textm.text = "Впереди туррели.Атакуйте их отрядом добровольцев из туннелей и двигайтесь дальше.";
            for (int i = 0; i < 12; i++)
            {
                Instantiate(soldier, t.transform.position, Quaternion.identity);
            }
            for (int i = 0; i < 6; i++)
            {
                Instantiate(baggy, t.transform.position, Quaternion.identity);
            }
            timii = Time.time + 30;
        }
        if ((b == 2) && (timii<=Time.time)&& GameObject.FindGameObjectsWithTag("Allies").Length<25)
        {
            timii = Time.time + 30;
            for (int i = 0; i < 12; i++)
            {
                Instantiate(soldier, t.transform.position, Quaternion.identity);
            }
            for (int i = 0; i < 6; i++)
            {
                Instantiate(baggy, t.transform.position, Quaternion.identity);
            }
        }
        GameObject[] goArray;
        goArray = GameObject.FindGameObjectsWithTag("Robots");
        if ((goArray.Length < 4) && (b == 15))
        {
            timii = Time.time + 5;
            b = 14;
            textm.text = "Это мутант.Видимо,они перебили заставу .Но если они уже здесь,то сколько нам осталось.Пора переходить к активным действиям!";
        }

        if ((goArray.Length == 0)&&(b==2))
        {
            timii = Time.time + 5;
            b = 3;
            textm.text = "Прекрасно,выдвигайтесь в цехи дальше по туннелю.";
            //stat.gameObject.SetActive(true);
            stat.t = 0;
        }
        if ((b == 3) && (timii <= Time.time))
        {
            
            Application.LoadLevel(1);
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
