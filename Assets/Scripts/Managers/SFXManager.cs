using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour {

	#region Fields

  [SerializeField] private AudioClip gameStartedSound;
  [SerializeField] private AudioClip[] itemCollisionSounds;

  private AudioSource audioSource;

  #endregion

  #region Mono Behaviour

  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void OnEnable () {
    audioSource.PlayOneShot(gameStartedSound);
    EventManager.StartListening<ItemCollisionEvent>(OnItemCollisionEvent);
  }

  void OnDisable () {
    EventManager.StopListening<ItemCollisionEvent>(OnItemCollisionEvent);
  }

  #endregion

  #region Event Behaviour

  void OnItemCollisionEvent(ItemCollisionEvent ItemCollisionEvent) {
    audioSource.PlayOneShot(itemCollisionSounds[Random.Range(0, itemCollisionSounds.Length)]);
  }

  #endregion

}
