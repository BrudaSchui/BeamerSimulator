using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

public class Beamer : MonoBehaviour
{
	public SpriteRenderer screen;
	private BeamerState State { get; set; } = BeamerState.PowerOff;
	public ConnectorType ExpectedConnector { get; private set; }

	private void Awake()
	{
		Array cTypes = Enum.GetValues(typeof(ConnectorType));
		ExpectedConnector = (ConnectorType) cTypes.GetValue(new Random().Next(cTypes.Length));
	}

	private void Update()
	{
		string resPath = null;
		switch (State)
		{
			case BeamerState.NoSignal:
				resPath = "Beamer_no_signal";
				break;
			case BeamerState.Projecting:
				resPath = "Waterbyte";
				break;
			case BeamerState.PowerOff:
			default:
				break;
		}

		Sprite sprite = resPath != null ? Resources.Load<Sprite>(resPath) : null;
		screen.sprite = sprite != null ? Instantiate(sprite) : null;
	}

	public void FlipPower()
	{
		double random = new Random().NextDouble();
		if (random > .5) State = State == BeamerState.PowerOff ? BeamerState.NoSignal : BeamerState.PowerOff;
	}

	public void TryConnecting(Plug plug)
	{
		if (State == BeamerState.PowerOff) return;

		if (plug.connectorType == ExpectedConnector)
		{
			StartCoroutine(Connect());
		}
	}

	IEnumerator Connect()
	{
		double waitTime = new Random().NextDouble() * 2 + 3;
		yield return new WaitForSecondsRealtime((float) waitTime);
		State = BeamerState.Projecting;
	}
}

public enum BeamerState
{
	PowerOff,
	NoSignal,
	Projecting
}