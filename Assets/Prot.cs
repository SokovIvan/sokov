using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Prot : MonoBehaviour
{
    public Text text;
    float n;
    // Start is called before the first frame update
    void Start()
    {
        n = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
             if (n == 0&&other.tag=="Allies")
        {
            n = 1;            
            text.text = "Такую пробоину оставили не мутанты.Судя по всему роботы уже близко! ";
        }   
    }
}
