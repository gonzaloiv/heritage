using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

  #region Fields

  private WorldModel worldModel;

  #endregion

  #region Mono Behaviour

  void Awake() {
    worldModel = GetComponent<WorldModel>();
    transform.localScale = new Vector2(ModeConfig.Instance.INITIAL_WORLD_SIZE, ModeConfig.Instance.INITIAL_WORLD_SIZE) * ModeConfig.Instance.WorldSizeScale;
  }

  void Start() {
    transform.localScale = new Vector2(ModeConfig.Instance.INITIAL_WORLD_SIZE, ModeConfig.Instance.INITIAL_WORLD_SIZE) * ModeConfig.Instance.WorldSizeScale;
  }

  void OnEnable() {
    EventManager.StartListening<ScoreEvent>(OnScoreEvent);
  }

  void OnDisable() {
    EventManager.StopListening<ScoreEvent>(OnScoreEvent);
  }

  #endregion

  #region Event Behaviour

  void OnScoreEvent(ScoreEvent scoreEvent) {
    UpdateScale(ModeConfig.Instance.WorldSizeScale);
  }

  #endregion

  #region Private Behaviour

  private void UpdateScale(float scale) {
    transform.localScale = Vector3.Lerp (transform.localScale, new Vector2(ModeConfig.Instance.INITIAL_WORLD_SIZE, ModeConfig.Instance.INITIAL_WORLD_SIZE) * scale, Time.deltaTime);
  }

  #endregion
	
}
