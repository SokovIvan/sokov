using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSc : MonoBehaviour{
    
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        float posx = transform.position.x + Input.GetAxis("Horizontal");
        float posy = transform.position.y + Input.GetAxis("Vertical");
        transform.position = new Vector2(posx,posy);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -60, 60),Mathf.Clamp(transform.position.y, -33, 33));
    }
}
