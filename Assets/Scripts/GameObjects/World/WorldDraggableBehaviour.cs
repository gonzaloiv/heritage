using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldDraggableBehaviour : MonoBehaviour {

  #region Fields

  private Vector2 initialPosition;
  private Vector2 initialClickPosition;

  #endregion

  #region Mono Behaviour

  void Update() {

  if (Input.GetMouseButtonDown(0)) {
    initialClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    initialPosition = transform.position;
  }

  if (Input.GetMouseButton(0))
    transform.position = (Vector2) initialPosition + (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialClickPosition;

  }

  #endregion


}
