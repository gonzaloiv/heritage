using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehaviour : MonoBehaviour {

  #region Field

  [SerializeField] private const float PULL_FORCE = 10000;
  [SerializeField] private const float DECELERATION = 0.9f;
  [SerializeField] private GameObject world;

  private Rigidbody2D rb;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>(); 
  }

  void Update() {
    Vector2 direction = world.transform.position - transform.position;
    rb.AddForce(direction.normalized * PULL_FORCE * Time.deltaTime);
    rb.velocity = rb.velocity * DECELERATION;
  }

  #endregion

  #region Public Behaviour

  public void Initialize(GameObject world) {
    this.world = world;
  }

  #endregion

}

