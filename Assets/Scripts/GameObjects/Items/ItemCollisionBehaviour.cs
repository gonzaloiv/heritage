using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] explosionPrefabs;
  private ParticleSystem explosion;
  private Animator anim;
  private Rigidbody2D rb;
  private ItemModel itemModel;
  private ItemSpawner itemSpawner;

  #endregion

  #region Mono Behaviour

  void Awake() {
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    itemModel = GetComponent<ItemModel>();
  } 

  void OnEnable() {
    if(explosion != null)
      Destroy(explosion);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == gameObject.layer) {
      if (collision2D.gameObject.GetComponent<ItemModel>().Type == itemModel.Type) {
        EventManager.TriggerEvent(new ItemCollisionEvent(itemModel.Type));
        PlayExplosion();
      }
    }
  }

  #endregion

  #region Public Behaviour

  public void Initialize(ItemSpawner itemSpawner) {
    this.itemSpawner = itemSpawner;
  }

  #endregion

  #region Private Behaviour

  private void PlayExplosion() {
    anim.Play("Explode");
    explosion = Instantiate(explosionPrefabs[Random.Range(0, explosionPrefabs.Length)], itemSpawner.transform).GetComponent<ParticleSystem>();
    explosion.transform.position = transform.position;
    rb.AddTorque(360);
    explosion.Play();
  }

  #endregion

}
