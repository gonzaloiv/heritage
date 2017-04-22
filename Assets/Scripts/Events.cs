using UnityEngine;
using UnityEngine.Events;

#region Input Events

public class RightInput : UnityEvent {}
public class LeftInput : UnityEvent {}
public class UpInput : UnityEvent {}
public class DownInput : UnityEvent {}
public class SpaceInput : UnityEvent {}
public class EscapeInput : UnityEvent {}
public class ReturnInput : UnityEvent {}

#endregion

#region Game Events

public class ItemInEvent : UnityEvent {

  public GameObject Item { get { return item; } }
  private GameObject item;

  public ItemInEvent(GameObject item) {
    this.item = item;
  }

}
public class ItemOutEvent : UnityEvent {

  public GameObject Item { get { return item; } }
  private GameObject item;

  public ItemOutEvent(GameObject item) {
    this.item = item;
  }

}


#endregion