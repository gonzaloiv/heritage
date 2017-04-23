using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

  #region Mono Behaviour

  void Update() {
 
    if (Input.GetKeyDown(KeyCode.Escape))
      SceneManager.LoadScene(0);

  }

  #endregion

}
