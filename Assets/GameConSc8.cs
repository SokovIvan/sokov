using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameConSc8 : MonoBehaviour
{
    public GameObject message;
    public Text text;
    bool n;
    float timev = 0;
    // Start is called before the first frame update
    void Start()
    {
        n = false;
        text.text = "������,��� ������ ������ ������������ ���� �����.�� ������ ������� ���������� � ����� � ������ ��� �����.���� ��� �������� ��� ����� ����� � ���� �������.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 25 && timev == 0)
        {
            text.text = "����������� �������� ����������������� ������ �������.";
        }
        if (Time.timeSinceLevelLoad > 35 && timev == 0)
        {
            message.SetActive(false);
        }
        if (n&&timev==0)
        {
            message.SetActive(true);
            text.text = "�����������!���������� ������ ������ ��� ����� ������.";
            timev = Time.timeSinceLevelLoad;
            Statistics stat = GameObject.Find("Stat").GetComponent<Statistics>();
            stat.t = 0;

        }
        if (Time.timeSinceLevelLoad - timev > 20 && timev > 0)
        { SceneManager.LoadScene("Sc9"); }

            GameObject[] a = GameObject.FindGameObjectsWithTag("Allies");
        if (a.Length == 0)
        {
            SceneManager.LoadScene("ScSc");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Allies")
        {
            n = true;
        }
    }
}

