using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSc : MonoBehaviour
{
    public GameObject TankK;
    public GameObject TankB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TankB.transform.position = TankK.transform.position;        
    }
}
