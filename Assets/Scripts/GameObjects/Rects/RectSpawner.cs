using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject world;
  [SerializeField] private GameObject rectPrefab;

  private Vector2 screenSize;
  private GameObjectPool rectPool;

  #endregion

  #region Mono Behaviour

  void Awake() {
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    rectPool = new GameObjectPool("RectPool", rectPrefab, 5, transform);
  }

  void Start() {
    StartCoroutine(SpawningRoutine());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator SpawningRoutine() {
    int i = 0;
    while (i < rectPool.Count) {
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
    Vector2 position = new Vector2(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y));
    while (Physics2D.OverlapCircle(position, 1))
      position = new Vector2(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y));
    return position;
  }

  #endregion
	
}
