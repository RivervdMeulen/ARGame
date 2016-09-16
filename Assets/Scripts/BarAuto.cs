using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BarAuto : MonoBehaviour, IEvents {

	[SerializeField]
	private GameObject fill;

	[SerializeField]
	private float addAmount;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void ValueChange (float amount) {
		
	}

	public void EndMatch() {

	}

	public void TakeAction (bool playerTurn, bool defend) {
		if (!playerTurn) {
			Debug.Log ("Fill");
			ExecuteEvents.Execute<IEvents> (fill, null, (x, y) => x.ValueChange (addAmount));
		}

	}

}

