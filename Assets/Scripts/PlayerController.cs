using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;

	Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float inHorizontal = Input.GetAxis("Horizontal");
		float inVertical = Input.GetAxis("Vertical");

		Vector3 force = new Vector3(inHorizontal, 0, inVertical);
		rb.AddForce(force * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pickup"))
		{
			other.gameObject.SetActive(false);
		}
	}
}
