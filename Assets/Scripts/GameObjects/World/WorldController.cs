using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

  #region Fields

  private WorldModel worldModel;

  #endregion

  #region Mono Behaviour

  void Awake() {
    worldModel = GetComponent<WorldModel>();
    transform.localScale = new Vector2(ModeConfig.Instance.WORLD_SIZE, ModeConfig.Instance.WORLD_SIZE);
  }

  void OnEnable() {
    EventManager.StartListening<ItemInEvent>(OnItemInEvent);
    EventManager.StartListening<ItemOutEvent>(OnItemOutEvent);
  }

  void OnDisable() {
    EventManager.StopListening<ItemInEvent>(OnItemInEvent);
    EventManager.StopListening<ItemOutEvent>(OnItemOutEvent);
  }

  #endregion

  #region Event Behaviour

  void OnItemInEvent(ItemInEvent itemInEvent) {
    worldModel.AddItem(itemInEvent.Item);
    HUDController.UpdateScore(worldModel.Items.Count);
  }

  void OnItemOutEvent(ItemOutEvent itemOutEvent) {
    worldModel.RemoveItem(itemOutEvent.Item);
    HUDController.UpdateScore(worldModel.Items.Count);
  }

  #endregion
	
}
