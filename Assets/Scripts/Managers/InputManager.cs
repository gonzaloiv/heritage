using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

  #region Mono Behaviour

  void Update() {

    // Keyboard player input
    if (Time.timeScale != 0) {

      // DIRECTION CONTROLS

      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        EventManager.TriggerEvent(new UpInput());
      if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        EventManager.TriggerEvent(new RightInput());
      if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        EventManager.TriggerEvent(new LeftInput());
      if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        EventManager.TriggerEvent(new DownInput());

      // ACTION CONTROLS

      if (Input.GetKey(KeyCode.Space))
        EventManager.TriggerEvent(new SpaceInput());
      if (Input.GetKey(KeyCode.Return))
        EventManager.TriggerEvent(new ReturnInput());
      if (Input.GetKey(KeyCode.Escape))
        EventManager.TriggerEvent(new EscapeInput());

    }
   
    // UI CONTROLS

    if (Input.GetKeyDown(KeyCode.Escape))
      EventManager.TriggerEvent(new SpaceInput());

  }

  #endregion

}
