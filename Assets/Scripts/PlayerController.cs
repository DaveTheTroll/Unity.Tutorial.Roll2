using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;

	public Text collectedItemsText;
	public Text winText;

	Rigidbody rb;
	int collectedItems;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		collectedItems = 0;
		UpdateUI();
		winText.text = "";
	}

	void UpdateUI()
	{
		collectedItemsText.text = string.Format("Count: {0}", collectedItems);
		if (collectedItems == 12)
		{
			winText.text = "FINISHED!";
		}
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
			collectedItems++;
			UpdateUI();
		}
	}
}
