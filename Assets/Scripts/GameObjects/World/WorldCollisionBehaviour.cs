using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCollisionBehaviour : MonoBehaviour {

  #region Fields

  private const float EXIT_DISTANCE = 3f;
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

  void OnCollisionExit2D(Collision2D collision2D) {
    if(collision2D.gameObject.layer == (int) Layer.Item)
      StartCoroutine(ExitRoutine(collision2D.gameObject));
  }

	#endregion

  #region Private Behaviour

  private IEnumerator ExitRoutine(GameObject item) {
    yield return new WaitForSeconds(0.2f);
    float distance = (item.transform.position - transform.position).magnitude;
    if(distance > EXIT_DISTANCE)
      EventManager.TriggerEvent(new ItemOutEvent(item));
  }

  #endregion

}
