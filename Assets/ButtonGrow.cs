using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGrow : MonoBehaviour
{
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(4.5125f, 8.01875f,1);
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(4.0125f, 7.81875f, 1);
    }
}
