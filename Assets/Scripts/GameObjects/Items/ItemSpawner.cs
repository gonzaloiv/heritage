﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject world;
  [SerializeField] private GameObject[] itemPrefabs;

  private Vector2 screenSize;
  private GameObjectArrayPool rectPool;

  #endregion

  #region Mono Behaviour

  void Awake() {
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		rectPool = new GameObjectArrayPool("ItemPool", itemPrefabs, 5, transform);
  }

  void Start() {
    StartCoroutine(SpawningRoutine());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator SpawningRoutine() {
    int i = 0;
    while (i < Config.MAX_ITEMS) {
      yield return new WaitForSeconds(1);
      SpawnRect();
    }
  }

  private void SpawnRect() {
    GameObject rect = rectPool.PopObject();
    rect.transform.position = RandomRectPosition();
    rect.GetComponent<GravityBehaviour>().Initialize(world);
    rect.SetActive(true);
  }

  private Vector2 RandomRectPosition() {
    return new Vector2(Random.Range(-screenSize.x, screenSize.x), screenSize.y);
  }

  #endregion
	
}