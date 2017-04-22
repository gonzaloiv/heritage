using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldDraggableAxisBehaviour : MonoBehaviour {

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

    if (Input.GetMouseButton(0)) {
      Vector2 distance = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialClickPosition;
      transform.position = (Vector2) initialPosition + new Vector2(distance.x, 0);
      transform.rotation = transform.rotation * Quaternion.Euler(0, 0, distance.y);
      RotateItems(distance);
    }

  }

  #endregion

  #region Private Behaviour

  private void RotateItems(Vector2 distance) {
    GetComponent<WorldModel>().Items.ForEach( x => { 
      x.transform.rotation = x.transform.rotation * Quaternion.Euler(0, 0, distance.y); 
    });
  }

  #endregion

}