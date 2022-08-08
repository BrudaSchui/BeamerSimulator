using UnityEngine;

public class Plug : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Beamer _beamer;

    public Transform origin;
    public GameObject cablePrefab;

    public ConnectorType connectorType;
    private Vector3 _screenPoint, _offset;
    private LineRenderer _cableRenderer;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _beamer = FindObjectOfType<Beamer>();

        _cableRenderer = Instantiate(cablePrefab, new Vector3(0, 0, 0), Quaternion.identity)
            .GetComponent<LineRenderer>();
        _cableRenderer.enabled = true;
    }

    private void Update() => _cableRenderer.SetPositions(new[] {transform.position, origin.position});

    private void OnMouseDown()
    {
        Vector3 pos = transform.position;
        _screenPoint = Camera.main!.WorldToScreenPoint(pos);

        Vector3 mousePos = new(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        _offset = pos - Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDrag()
    {
        _rigidBody.isKinematic = true;

        Vector3 curScreenPoint = new(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);

        Vector3 curPosition = Camera.main!.ScreenToWorldPoint(curScreenPoint) + _offset;
        transform.position = curPosition;
    }

    private void OnMouseUp() => _rigidBody.isKinematic = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Socket>().connectorType != connectorType) return;

        _beamer.TryConnecting(this);
        _rigidBody.isKinematic = true;
        transform.position = other.transform.position;
    }
}