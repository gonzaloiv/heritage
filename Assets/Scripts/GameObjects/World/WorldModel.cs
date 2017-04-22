using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorldModel : MonoBehaviour {

  #region Fields

  public List<GameObject> Items { get { return items; } }
  private List<GameObject> items = new List<GameObject>();

  #endregion

  #region Mono Behaviour


  void Update() {
    HUDController.UpdateScore(items.Count);
    items.Clear();
  }

  void FixedUpdate() {
    items.Clear();
  }

  #endregion

  #region Public Behaviour

  public void AddItem(GameObject item) {
    if (!items.Contains(item)) {
      items.Add(item);
      EventManager.TriggerEvent(new ScoreEvent(items.Count));
    }
  }

  public void RemoveItem(GameObject item) {
    bool result = items.Remove(item);
    EventManager.TriggerEvent(new ScoreEvent(items.Count));
  }

  #endregion

}