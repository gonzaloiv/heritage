using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorldModel : MonoBehaviour {

  #region Fields

  public List<GameObject> Items { get { return items; } }
  private List<GameObject> items = new List<GameObject>();

  #endregion

  #region Public Behaviour

  public void AddItem(GameObject item) {
    if(items.Where(x => x == item).Count() == 0)
      items.Add(item);
  }

  public void RemoveItem(GameObject item) {
    if(items.Where(x => x == item).Count() != 0)
      items.Remove(item);
  }

  #endregion

}
