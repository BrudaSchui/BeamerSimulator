using UnityEngine;

public class Plug : MonoBehaviour
{
	private BoxCollider _boxCollider;
	public ConnectorType connector;

	private void Start()
	{
		_boxCollider = GetComponent<BoxCollider>();
	}

	private void OnMouseDrag()
	{
		float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		Vector3 mousePos = new(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen);
		transform.position = Camera.main.ScreenToWorldPoint(mousePos);
		_boxCollider.enabled = false;
	}

	private void OnMouseUp()
	{
		_boxCollider.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Socket>().connector == connector)
		{
			transform.position = other.transform.position;
		}
	}
}