using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BarManual : MonoBehaviour, IEvents {

	[SerializeField]
	private bool vertical;

	[SerializeField]
	private GameObject bar;

	[SerializeField]
	private float speed;

	private float sizeX;
	private float sizeY;

	private bool change = false;

	// Use this for initialization
	void Start () {
		sizeX = bar.transform.localScale.x;
		sizeY = bar.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (change) {
			if (!vertical) {
				bar.transform.localScale = Vector2.Lerp (bar.transform.localScale, new Vector2 (sizeX, bar.transform.localScale.y), Time.deltaTime * speed);
			} else {
				bar.transform.localScale = Vector2.Lerp (bar.transform.localScale, new Vector2 (bar.transform.localScale.x, sizeY), Time.deltaTime * speed);
			}
		}

		if (bar.transform.localScale.x == sizeX) {
			change = false;
		}

		if (bar.transform.localScale.y == sizeY) {
			change = false;
		}
	}

	public void ValueChange (float amount) {
		sizeX = bar.transform.localScale.x - amount;
		sizeY = bar.transform.localScale.y - amount;
		change = true;
		if (sizeX < 0) {ExecuteEvents.Execute<IEvents> (gameObject, null, (x, y) => x.EndMatch());}
		if (sizeY < 0) {ExecuteEvents.Execute<IEvents> (gameObject, null, (x, y) => x.EndMatch());}
		if (sizeX > 1) {sizeX = 1;}
		if (sizeY > 1) {sizeY = 1;}
	}

	public void EndMatch() {
	
	}

	public void TakeAction (bool playerTurn, bool defend) {
		
	}

}

