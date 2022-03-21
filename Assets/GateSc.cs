using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSc : MonoBehaviour
{
    public GameObject gate;
    public GameObject gatem;
    float hod;
    public int x;
    // Update is called once per frame
    void Update()
    {
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 200)
            {
                hod++;
                if (hod > 0)
                {
                    gatem.SetActive(true);
                }                
            }

        }
        if (hod > 0 && Input.GetKeyDown(KeyCode.E) && gate.activeSelf == true)
        {
          gate.SetActive(false);
        }
        else if (hod > 0 && Input.GetKeyDown(KeyCode.E)&& gate.activeSelf==false)
        {
            gate.SetActive(true);
        }
        if (hod <= 0)
        {
            gatem.SetActive(false);
        }
    }

}
