using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IEvents : IEventSystemHandler {

	void TakeAction(bool playerTurn, bool defend);

	void ValueChange (float amount);

	void EndMatch();

}
