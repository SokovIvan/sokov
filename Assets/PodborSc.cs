using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodborSc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hod = 0;
        GameObject[] goArray;
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 40)
            {                
                hod = hod + 1;
                if (hod == 1)
                {
                    transform.position = goArray[i].transform.position;
                }
            }
        }
    }
}
