using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour, IEvents {

	[SerializeField]
	private Button attackButton;

	[SerializeField]
	private Button defendButton;

	[SerializeField]
	private GameObject levelHandler;

	[SerializeField]
	private bool playerTurn;

	private bool defend;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator enemyTurn () {
		playerTurn = false;
		attackButton.interactable = false;
		defendButton.interactable = false;
		yield return new WaitForSeconds (2f);
		defend = (Random.value > 0.85f);
		Action (defend);
		yield return new WaitForSeconds (0.5f);
		playerTurn = true;
	}

	public void Action (bool defense) {
		if (playerTurn) {
			ExecuteEvents.Execute<IEvents> (levelHandler, null, (x, y) => x.TakeAction (playerTurn, defense));
			StartCoroutine(enemyTurn ());
		} else {
			ExecuteEvents.Execute<IEvents> (levelHandler, null, (x, y) => x.TakeAction (playerTurn, defense));
		}
	}

	public void ValueChange (float amount) {

	}

	public void EndMatch () {

	}

	public void TakeAction (bool playerTurn, bool defend) {
	
	}
}
