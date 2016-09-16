using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EventCaller : MonoBehaviour, IEvents {

	[SerializeField]
	private GameObject[] playerTurns;

	private int i;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EndMatch () {

	}

	public void ValueChange (float amount) {

	}

	public void TakeAction (bool playerTurn, bool defend) {
		for (i = 0; i < playerTurns.Length; i++) {
			//ExecuteEvents.Execute<IEvents> (playerTurns[i], null, (x, y) => x.TakeAction (playerTurn, defend));
		}
	}
}
