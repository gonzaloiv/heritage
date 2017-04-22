using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TitleController : MonoBehaviour {

  #region Fields

  private float SHAKE_AMOUNT = 0.4f;
  private Text[] titles;
    
  #endregion

  #region Mono Behaviour

  void Awake() {
    titles = GetComponentsInChildren<Text>();
  }

  void Update() {
    foreach (Text title in titles) {
      Vector2 position = Random.insideUnitCircle * SHAKE_AMOUNT;
      title.transform.localPosition = (Vector2) title.transform.localPosition + new Vector2(position.x, position.y);
    }
  }

  #endregion

}



  