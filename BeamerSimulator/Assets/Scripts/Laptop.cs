using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class Laptop : MonoBehaviour
{
    private Beamer _beamer;

    private void Awake()
    {
        _beamer = FindObjectOfType<Beamer>();
        
        Random random = new();
        List<ConnectorType> cTypes = Enum.GetValues(typeof(ConnectorType))
            .Cast<ConnectorType>()
            .ToList();
        
        cTypes.Remove(_beamer.ExpectedConnector);
        
        do
        {
            int idx = random.Next(0, cTypes.Count);
            cTypes.RemoveAt(idx);
        } while (random.Next(cTypes.Count + 1) != 0);
        // chance decreases as less connectors are available, reaching 0 as cTypes is empty

        Socket[] sockets = GetComponentsInChildren<Socket>();
        cTypes.ForEach(c => sockets.First(s => s.connectorType == c).gameObject.SetActive(false));
    }
}