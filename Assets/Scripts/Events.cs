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

public class ItemCollisionEvent : UnityEvent {

  public Item Type { get { return type; } }
  private Item type;

  public ItemCollisionEvent(Item type) {
    this.type = type;
  }

}

public class ScoreEvent : UnityEvent {

  public int Items { get { return items; } }
  private int items;

  public ScoreEvent(int items) {
    this.items = items;
  }

}

#endregion