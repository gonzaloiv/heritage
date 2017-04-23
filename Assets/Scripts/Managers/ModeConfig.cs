using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeConfig : Singleton<ModeConfig> {

  #region Fields

  public Mode MODE;
  public float INITIAL_WORLD_SIZE;
  public float INITIAL_GRAVITY_SCALE;
  public float INITIAL_GRAVITY_MIN_DISTANCE;
  public float SPAWING_TIME;
  public float PULL_FORCE;

  public float GravityMinDistance;
  public float WorldSizeScale;
  public float GravityScale;

  #endregion

  #region Public Behavour

  void Awake() {
    SetupModeConfig();
  }

  void OnEnable() {
    DataManager.LoadData();
    EventManager.StartListening<ScoreEvent>(OnScoreEvent);
  }

  void OnDisable() {
    DataManager.SaveData();
    EventManager.StopListening<ScoreEvent>(OnScoreEvent);  
  }

  #endregion

  #region Event Behaviour

  void OnScoreEvent(ScoreEvent scoreEvent) {
    WorldSizeScale = Instance.INITIAL_WORLD_SIZE + scoreEvent.Items / 5f * 0.3f;
    GravityMinDistance = Instance.INITIAL_GRAVITY_MIN_DISTANCE - scoreEvent.Items / 5f * 0.1f;
    GravityScale = Instance.INITIAL_GRAVITY_SCALE + scoreEvent.Items / 5f * 0.1f;
  }

  #endregion

  #region Private Behaviour

  private void SetupModeConfig() {
    WorldSizeScale = Instance.INITIAL_WORLD_SIZE;
    GravityMinDistance = Instance.INITIAL_GRAVITY_MIN_DISTANCE;
    GravityScale = Instance.INITIAL_GRAVITY_SCALE;
  }

  #endregion
	
}
