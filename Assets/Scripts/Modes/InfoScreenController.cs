using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScreenController : MonoBehaviour {

  #region Field

  [SerializeField] private Canvas[] infoScreens;

  #endregion

  #region Mono Behaviour

  void Start() {
    if(!DataManager.GetIsTutorialPlayed())
      StartCoroutine(InfoRoutine());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator InfoRoutine() {
    Time.timeScale = 0;
    yield return TimeManager.WaitForRealTime(0.1f);
    infoScreens[(int) ModeConfig.Instance.MODE].gameObject.SetActive(true);
    yield return TimeManager.WaitForRealTime(2);
    infoScreens[(int) ModeConfig.Instance.MODE].gameObject.SetActive(false);
    infoScreens[infoScreens.Length - 1].gameObject.SetActive(true);
    yield return TimeManager.WaitForRealTime(2);
    infoScreens[infoScreens.Length - 1].gameObject.SetActive(false);
    Time.timeScale = Config.TIME_SCALE;
  }

  #endregion
	
}
