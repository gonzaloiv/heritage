using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderBehaviour : MonoBehaviour {

  #region Fields

  public int sceneNumber;

  #endregion

  #region Public Behaviour

  public void LoadScene() {
    SceneManager.LoadScene(sceneNumber);
  }

  #endregion
	
}
