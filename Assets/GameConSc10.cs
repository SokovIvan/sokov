using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameConSc10 : MonoBehaviour
{
    public GameObject message;
    public GameObject pr;
    public GameObject zar;
    public Text text;
    bool n;
    bool k;
    public Text timer;
    public GameObject fire;
    float ttttt;
    // Start is called before the first frame update
    void Start()
    {
        k = true;
        n = false;
        text.text = "�����������!��� �������� ��� ����� ��������.�� ��� ����� ������� ������ ������������.";
    }

    // Update is called once per frame
    void Update()
    {
        float t = ((int)(1200 - Time.timeSinceLevelLoad));

        if (Time.timeSinceLevelLoad > 25&& Time.timeSinceLevelLoad < 26)
        {
            text.text = "�� ������ ��������� ����� ����� ����� �� ����,��� �� ������� ����������� � ����������..";
        }
        if (Time.timeSinceLevelLoad > 35&& Time.timeSinceLevelLoad < 36)
        {
            message.SetActive(false);
        }
        if (t >= 0)
        {
            timer.text = "�������� ������������: " + t;
        }
        else if (k)
        {
            k = false;
            GameObject[] a = GameObject.FindGameObjectsWithTag("Robots");
            for (int i = 0; i < a.Length; i++)
            {
                Instantiate(fire, a[i].transform.position, Quaternion.identity);
                Destroy(a[i]);
            }
            pr.SetActive(true);
            zar.SetActive(true);
            message.SetActive(true);
            text.text = "������ ������� ������ ���������� ���� �������!...������!�������� ��� ������� ���� � ������������ � ����-������� �������!!! ";

            //if (t < -20)
            //{
            //   message.SetActive(false);
            //    text.text = "������!�� ��������!!";                
            //}            

        }
        else if (1200 - Time.timeSinceLevelLoad<-20)
        {
            message.SetActive(true);
            text.text = "�� �������� ��!������� ������!������ ��� �������! ";
            if (ttttt == 0)
            {
            Statistics stat = GameObject.Find("Stat").GetComponent<Statistics>();
            stat.t = 0;
                ttttt = 1;
            }

        }
        if (n)
        {
            message.SetActive(true);
            text.text = "������ ����� �� ������ - �� �������!";
            SceneManager.LoadScene("ScSc");
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Robots")
        {
            n = true;
        }
    }
}