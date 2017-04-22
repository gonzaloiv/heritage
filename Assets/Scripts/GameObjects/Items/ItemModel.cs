using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : MonoBehaviour {

  #region Fields

  public Item Type { get { return type; } }
  [SerializeField] private Item type;

  public int Size { get { return 1; } }
  [SerializeField] private int size;

  #endregion

}
