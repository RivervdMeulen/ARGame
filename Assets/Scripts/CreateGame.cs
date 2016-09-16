using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateGame : MonoBehaviour {

	[SerializeField]
	private Button[] disableOnStart;

	private int i;

	// Use this for initialization
	void Start () {
		for (i = 0; i < disableOnStart.Length; i++) {
			//disableOnStart [i].interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
