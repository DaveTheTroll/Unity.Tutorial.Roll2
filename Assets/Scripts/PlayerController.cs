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
#if UNITY_ANDROID
		if (Input.touchCount > 0 &&
			Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			Vector2 delta = Input.GetTouch(0).deltaPosition;
			Vector3 force = new Vector3(delta.x, 0, delta.y);
			rb.AddForce(force * speed);
		}
#else
		float inHorizontal = Input.GetAxis("Horizontal");
		float inVertical = Input.GetAxis("Vertical");

		Vector3 force = new Vector3(inHorizontal, 0, inVertical);
		rb.AddForce(force * speed);
#endif
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
