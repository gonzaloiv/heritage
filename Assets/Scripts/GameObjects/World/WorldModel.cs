using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorldModel : MonoBehaviour {

  #region Fields

  public List<GameObject> Items { get { return items; } }
  private List<GameObject> items;

  private int itemsDestroyed;

  #endregion

  #region Mono Behaviour

  void Start() {
    ResetData();
  }

  void Update() {
    if (ModeConfig.Instance.MODE == Mode.Collect) {
      HUDController.UpdateScore(items.Count);
      items.Clear();
    }
  }

  void FixedUpdate() {
    items.Clear();
  }

  void OnEnable() {
    EventManager.StartListening<ItemInEvent>(OnItemInEvent);
    EventManager.StartListening<ItemCollisionEvent>(OnItemCollisionEvent);
  }

  void OnDisable() {
    EventManager.StopListening<ItemInEvent>(OnItemInEvent);
    EventManager.StopListening<ItemCollisionEvent>(OnItemCollisionEvent);
  }

  #endregion

  #region Event Behaviour

  void OnItemInEvent(ItemInEvent itemInEvent) {
    if(ModeConfig.Instance.MODE == Mode.Collect)
      AddItem(itemInEvent.Item);
  }

  void OnItemCollisionEvent(ItemCollisionEvent itemCollisionEvent) {
    if(ModeConfig.Instance.MODE == Mode.Destroy)  
      AddDestroyedItem();
  }

  #endregion

  #region Public Behaviour

  public void AddItem(GameObject item) {
    if (!items.Contains(item)) {
      items.Add(item);
      EventManager.TriggerEvent(new ScoreEvent(items.Count));
    }
  }

  public void AddDestroyedItem() {
    itemsDestroyed++;
    EventManager.TriggerEvent(new ScoreEvent(itemsDestroyed));
    HUDController.UpdateScore(itemsDestroyed);
  }

  #endregion

  #region Private Behaviour

  private void ResetData() {
    itemsDestroyed = 0;
    items = new List<GameObject>();
    HUDController.UpdateScore(0);
  }

  #endregion

}