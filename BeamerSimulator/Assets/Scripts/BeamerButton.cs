using System.Collections;
using UnityEngine;

public class BeamerButton : MonoBehaviour
{
    public Beamer beamer;

    private Transform _transform;
    private const float DownPos = .6f;
    private const float UpPos = 1.5f;

    private void Awake() => _transform = transform;

    private IEnumerator OnMouseDown()
    {
        Vector3 position = _transform.localPosition;
        position.y = DownPos;
        _transform.localPosition = position;

        yield return new WaitForSeconds(1);

        beamer.FlipPower();

        position.y = UpPos;
        _transform.localPosition = position;
    }
}