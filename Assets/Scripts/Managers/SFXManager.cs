using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour {

	#region Fields

  // Menus
  [SerializeField] private AudioClip gameStarted;

  // Game Mechanics

  private AudioSource audioSource;

  #endregion

  #region Mono Behaviour

  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void OnEnable () {
    audioSource.PlayOneShot(gameStarted);
  }

  void OnDisable () {
  }

  #endregion

  #region Event Behaviour
  #endregion

}
