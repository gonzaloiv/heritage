using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	#region Mono Behaviour

	void OnEnable() {
		EventManager.StartListening<UpInput>(OnUpInput);
    EventManager.StartListening<RightInput>(OnRightInput);
    EventManager.StartListening<DownInput>(OnDownInput);
    EventManager.StartListening<LeftInput>(OnLeftInput);
	}

  void OnDisable() {
    EventManager.StopListening<UpInput>(OnUpInput);
    EventManager.StopListening<RightInput>(OnRightInput);
    EventManager.StopListening<DownInput>(OnDownInput);
    EventManager.StopListening<LeftInput>(OnLeftInput);
  }

	#endregion

	#region EventBehaviuor

  void OnUpInput(UpInput upInput) {
    transform.Translate(new Vector2(0, 1));
  }

  void OnRightInput(RightInput rightInput) {
    transform.Translate(new Vector2(1, 0));
  }

  void OnDownInput(DownInput downInput) {
    transform.Translate(new Vector2(0, -1));
  }

  void OnLeftInput(LeftInput leftInput) {
    transform.Translate(new Vector2(-1, 0));
  }

	#endregion
}
