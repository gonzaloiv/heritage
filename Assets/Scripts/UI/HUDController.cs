using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDController : Singleton<HUDController> {

  #region Fields

  private const float UPDATE_TIME = 0.1f;

  private static Text scoreLabel;
  private static int score;
  private static int maxScore;

  #endregion

  #region Mono Behaviour

  void Awake() {
    scoreLabel = GetComponentInChildren<Text>();
  }

  void OnEnable() {
    StartCoroutine(ScoreUpdatingRoutine());
  }

  #endregion

  #region Public Behaviour

  public static void UpdateScore(int itemScore) {
    score = itemScore;
    if(score > maxScore)
      maxScore = score;
  }

  #endregion

  #region Private Behaviour

  private IEnumerator ScoreUpdatingRoutine() {
    while(gameObject.activeSelf) {
      yield return new WaitForSeconds(UPDATE_TIME);
      scoreLabel.text = score + "/" + maxScore;
    }
  }

  #endregion

}
