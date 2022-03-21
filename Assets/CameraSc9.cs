using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSc9 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float posx = transform.position.x + Input.GetAxis("Horizontal");
        float posy = transform.position.y + Input.GetAxis("Vertical");
        transform.position = new Vector2(posx, posy);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -896, -693), Mathf.Clamp(transform.position.y, -418, -238));
    }
}