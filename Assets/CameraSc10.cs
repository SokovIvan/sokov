using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSc10 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float posx = transform.position.x + Input.GetAxis("Horizontal")*7;
        float posy = transform.position.y + Input.GetAxis("Vertical")*7;
        transform.position = new Vector2(posx, posy);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -316, 316), Mathf.Clamp(transform.position.y, -350, 350));
    }
}
