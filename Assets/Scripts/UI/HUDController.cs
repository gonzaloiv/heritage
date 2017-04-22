using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDController : Singleton<HUDController> {

  #region Fields

  private const float UPDATE_TIME = 0.1f;

  private static Text scoreLabel;
  private Animator anim;
  private static int currentScore;
  private static int maxScore;

  #endregion

  #region Mono Behaviour

  void Awake() {
    scoreLabel = GetComponentInChildren<Text>();
    anim = GetComponent<Animator>();
  }

  void Start() {
    maxScore = DataManager.GetHighestScore();
  }

  #endregion

  #region Public Behaviour

  public static void UpdateScore(int score) {
    currentScore = score;
    scoreLabel.text = currentScore + "/" + maxScore;
    if (score > maxScore)
      Instance.SetHighestScore(currentScore);
  }

  #endregion

  #region Private Behaviour

  private void SetHighestScore(int score) {
    maxScore = score;

    DataManager.SetHighestScore(score);
    anim.Play("HighestScore");
  }

  #endregion

}
