using UnityEngine;

public class Socket : MonoBehaviour
{
    private SphereCollider connectionDetector;
    public ConnectorType connector;

    void Start()
    {
        connectionDetector = GetComponent<SphereCollider>();
    }
}
