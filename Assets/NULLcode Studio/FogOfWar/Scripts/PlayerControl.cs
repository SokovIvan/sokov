// NULLcode Studio © 2015
// null-code.ru

using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 150f;
	public float jumpForce = 10f;
	public Transform head;
	public float mouseSensitivity = 5f;
	public float headMinY = -40f;
	public float headMaxY = 40f;
	private Vector3 moveDirection;
	private float vertical;
	private float horizontal;
	private Rigidbody body;
	private float rotationY;
	private bool jump;

	void Start () 
	{
		Cursor.visible = false;
		jump = false;
		body = GetComponent<Rigidbody>();
		body.freezeRotation = true;
	}

	void OnCollisionStay(Collision coll) 
	{
		jump = true;
	}

	void OnCollisionExit(Collision coll) 
	{
		jump = false;
	}

	void FixedUpdate()
	{
		body.AddForce(moveDirection * speed);

		// Ограничение скорости, иначе объект будет постоянно ускоряться
		if(Mathf.Abs(body.velocity.x) > speed/100f)
		{
			body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed/100f, body.velocity.y, body.velocity.z);
		}
		if(Mathf.Abs(body.velocity.z) > speed/100f)
		{
			body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed/100f);
		}

		// Прыжок - "пробел"
		if (Input.GetKey(KeyCode.Space) && jump)
		{
			body.velocity = new Vector3(0, jumpForce, 0);
		}
	}

	void Update () 
	{
		// Вертим головой
		//float rotationX = head.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
		//rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
		//rotationY = Mathf.Clamp (rotationY, headMinY, headMaxY);
		//head.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

		// Управление W A S D
		if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) vertical = 1;
		else if(!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) vertical = -1; else vertical = 0;
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) horizontal = -1;
		else if(!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) horizontal = 1; else horizontal = 0;

		// Расчет направления движения
		moveDirection = new Vector3(horizontal, 0, vertical);
		//moveDirection = head.TransformDirection(moveDirection);
		moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
	}
}
