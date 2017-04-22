using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionBehaviour : MonoBehaviour {

  #region Mono Behaviour

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == gameObject.layer) {
      if (collision2D.gameObject.GetComponent<ItemModel>().Type == GetComponent<ItemModel>().Type) {
        gameObject.SetActive(false);
      }
    }
  }

  #endregion

}
