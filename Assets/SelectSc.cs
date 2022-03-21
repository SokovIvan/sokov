using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectSc : MonoBehaviour
{
    public Text text;
    public GameObject mess;
    public int res;
    public int en;
    // Start is called before the first frame update
    void Start()
    {
        mess = transform.Find("Image").gameObject;
        text = transform.Find("Image/Text").gameObject.GetComponent<Text>();
        text.text = "Περ:"+res+"\n"+"έλ:"+en;
        
    }

    private void OnMouseEnter()
    {
        mess.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        mess.gameObject.SetActive(false);
    }
}
