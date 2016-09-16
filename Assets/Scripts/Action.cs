using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Action : MonoBehaviour, IEvents {

	[SerializeField]
	private GameObject playerBar;

	[SerializeField]
	private GameObject enemyBar;

	[SerializeField]
	private float minDamage;

	[SerializeField]
	private float maxDamage;

	[SerializeField]
	private bool playerDefend;

	[SerializeField]
	private bool enemyDefend;

	[SerializeField]
	private float attackDamage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeAction (bool playerTurn, bool defend) {
		if (playerTurn) {
			attackDamage = Random.Range (minDamage, maxDamage);

			if (defend) {
				playerDefend = true;
				attackDamage = attackDamage / 10f;
			}

			if (enemyDefend) {
				attackDamage = attackDamage / 10f;
				attackDamage *= -1f;
				enemyDefend = false;
			}

			ExecuteEvents.Execute<IEvents> (enemyBar, null, (x, y) => x.ValueChange (attackDamage));

		} else {
			
			attackDamage = Random.Range (minDamage, maxDamage);

			if (defend) {
				enemyDefend = true;
				attackDamage = attackDamage / 10f;
			}

			if (playerDefend) {
				attackDamage = attackDamage / 10f;
				attackDamage *= -1f;
				playerDefend = false;
			}

			ExecuteEvents.Execute<IEvents> (playerBar, null, (x, y) => x.ValueChange (attackDamage));
		}
	}

	public void EndMatch () {
	
	}

	public void ValueChange (float amount) {
	
	}
}
