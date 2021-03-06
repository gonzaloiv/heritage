﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCollisionBehaviour : MonoBehaviour {

  #region Fields

  private const float EXIT_DISTANCE = 4f;
  private WorldModel worldModel;

  #endregion

  #region Mono Behaviour

  void Awake() {
    worldModel = GetComponent<WorldModel>();
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if(collision2D.gameObject.layer == (int) Layer.Item)
      EventManager.TriggerEvent(new ItemInEvent(collision2D.gameObject));
  }

  void OnCollisionStay2D(Collision2D collision2D) {
    if(collision2D.gameObject.layer == (int) Layer.Item)
      EventManager.TriggerEvent(new ItemInEvent(collision2D.gameObject));
  }

	#endregion

}
