using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehaviour : MonoBehaviour {

  #region Field

  [SerializeField] private const float MIN_DISTANCE = 2.2f;
  [SerializeField] private const float PULL_FORCE = 10000;
  [SerializeField] private const float DECELERATION = 0.9f;
  [SerializeField] private GameObject world;

  private Rigidbody2D rb;
  private bool inContact = false;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>(); 
  }

  void Update() {
    if (!inContact) { 
      Vector2 direction = world.transform.position - transform.position;
      if (direction.magnitude < Vector2.one.magnitude * MIN_DISTANCE) {
        rb.AddForce(direction.normalized * PULL_FORCE * Time.deltaTime);
        rb.velocity = rb.velocity * DECELERATION;
      }
    }
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if(collision2D.gameObject.layer == world.layer)
      inContact = true;
  }
  
  void OnCollisionExit2D(Collision2D collision2D) {
    if(collision2D.gameObject.layer == world.layer)
      inContact = false;
  }

  #endregion

  #region Public Behaviour

  public void Initialize(GameObject world) {
    this.world = world;
  }

  #endregion

}

