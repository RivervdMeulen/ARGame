using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTimeout : MonoBehaviour, IEvents {

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject button2;

	[SerializeField]
	private GameObject fill;

	[SerializeField]
	private float turns;

	[SerializeField]
	private bool startEmpty;

	private float size;
	private float speed = 5f;
	private bool change = false;

	// Use this for initialization
	void Start () {
		if (startEmpty) {
			button.interactable = false;
			size = 0.1f;
			change = true;
		}

		turns = 1 / turns;
	}
	
	// Update is called once per frame
	void Update () {
		if (change) {
			fill.transform.localScale = Vector2.Lerp (fill.transform.localScale, new Vector2 (fill.transform.localScale.x, size), Time.deltaTime * speed);
		}

		if (fill.transform.localScale.y == size && change) {
			change = false;
		}
	}

	IEnumerator EndTurn () {
		Debug.Log ("Endturn:" + button);
		yield return new WaitForSeconds (3f);
		size += turns;
		Debug.Log ("Size:" + size + " Button:" + button);
		change = true;

		if (size > 1f) {
			size = 1f;
			button.interactable = true;
		}

		if (size < 0.1f) {
			size = 0.1f;
		}
	}

	public void ButtonPress () {
		button.interactable = false;
		size = 0.1f;
		change = true;
		TakeAction (true, true);
		ExecuteEvents.Execute<IEvents> (button2, null, (x, y) => x.TakeAction (true, true));
	}

	public void EndMatch () {

	}

	public void ValueChange (float amount) {

	}

	public void TakeAction (bool playerTurn, bool defend) {
		Debug.Log ("Receive Signal:" + button);
		StartCoroutine (EndTurn ());
	}
}
