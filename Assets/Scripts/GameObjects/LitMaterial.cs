using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LOS;

public class LitMaterial : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject lightPrefab;
  private GameObject light;

  #endregion

  #region Mono Behaviour

  void Awake() {
    light = Instantiate(lightPrefab, transform);
    light.transform.position = (Vector2) transform.position + new Vector2(-1, 1);
    light.GetComponent<LOSFullScreenLight>().color = GetComponent<SpriteRenderer>().color;
  }

  void Update() {
    light.transform.rotation = Quaternion.identity;
  }

  #endregion
	
}
