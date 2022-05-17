using System;
using UnityEngine;

public class Plug : MonoBehaviour
{
	private BoxCollider _boxCollider;

	private void Start()
	{
		_boxCollider = GetComponent<BoxCollider>();
	}
	
	private void OnMouseDrag()
	{
		float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		transform.position =
			Camera.main.ScreenToWorldPoint(
				new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
		_boxCollider.enabled = false;
	}

	private void OnMouseUp()
	{
		_boxCollider.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		Console.WriteLine("Wos gehtn?");
	}
}