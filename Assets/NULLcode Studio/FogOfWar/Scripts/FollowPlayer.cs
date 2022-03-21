// NULLcode Studio © 2015
// null-code.ru

using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Vector3 offset;
	public float damping = 2f;
	private Transform pl;

	void Start () 
	{
		pl = GameObject.FindGameObjectWithTag("Player").transform;
		FindPlayer();
	}

	public void FindPlayer()
	{
		transform.position = pl.position + offset;
	}

	void LateUpdate ()
	{
		if(pl)
		{
			transform.position = Vector3.Lerp(transform.position, pl.position + offset, damping * Time.deltaTime);
		}
	}
}
