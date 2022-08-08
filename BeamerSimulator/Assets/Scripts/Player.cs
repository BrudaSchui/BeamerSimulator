using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<CinemachineVirtualCamera> _vCams = new();

    private void Awake() => _vCams.AddRange(FindObjectsOfType<CinemachineVirtualCamera>());

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Tab)) return;

        var activeCam = _vCams.Find(cam => cam.enabled);
        int activeIdx = _vCams.IndexOf(activeCam);
        _vCams[activeIdx].enabled = false;
        activeIdx = activeIdx == _vCams.Count - 1 ? 0 : activeIdx + 1;
        _vCams[activeIdx].enabled = true;
    }
}