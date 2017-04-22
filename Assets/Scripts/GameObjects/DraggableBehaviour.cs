using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableBehaviour : MonoBehaviour {

  #region Fields

  private Vector2 initialPosition;
  private Vector2 initialClickPosition;

  private bool inContact = false;

  #endregion

  #region Mono Behaviour

  void Update() {

    if (!inContact) { 

      if (Input.GetMouseButtonDown(0)) {
        initialClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        initialPosition = transform.position;
      }

      if (Input.GetMouseButton(0))
        transform.position = (Vector2) initialPosition + (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialClickPosition;

    }
  }

  void OnCollision2DEnter(Collision2D collision2D) {
    if(collision2D.gameObject.layer == (int) Layer.World)
      inContact = true;
  }

  void OnCollision2DExit(Collision2D collision2D) {
    if(collision2D.gameObject.layer == (int) Layer.World)
      inContact = false;
  }

  #endregion


}
