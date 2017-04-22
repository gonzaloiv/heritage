using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

  #region Fields

  private ItemModel itemModel;

  #endregion

  #region Mono Behaviour

  void Awake() {
    itemModel = GetComponent<ItemModel>();
  }

  #endregion

  #region Public Behaviour

  public void Disable() {
    gameObject.SetActive(false);
    transform.localScale = new Vector2(itemModel.Size * 0.7f, itemModel.Size * 0.7f);
  }

  #endregion

}
