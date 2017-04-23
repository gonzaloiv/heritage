using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject world;
  [SerializeField] private GameObject[] itemPrefabs;

  private Vector2 screenSize;
  private GameObjectArrayPool itemPool;

  #endregion

  #region Mono Behaviour

  void Awake() {
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		itemPool = new GameObjectArrayPool("ItemPool", itemPrefabs, 5, transform);
  }

  void Start() {
    StartCoroutine(SpawningRoutine());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator SpawningRoutine() {
    int i = 0;
    while (i < Config.MAX_ITEMS) {
      yield return new WaitForSeconds(ModeConfig.Instance.SPAWING_TIME);
      SpawnItem();
    }
  }

  private void SpawnItem() {
    GameObject rect = itemPool.PopObject();
    rect.transform.position = RandomItemPosition();
    rect.GetComponent<ItemCollisionBehaviour>().Initialize(this);
    rect.GetComponent<ItemGravityBehaviour>().Initialize(world);
    rect.SetActive(true);
  }

  private Vector2 RandomItemPosition() {
    return new Vector2(Random.Range(-screenSize.x, screenSize.x), screenSize.y);
  }

  #endregion
	
}
