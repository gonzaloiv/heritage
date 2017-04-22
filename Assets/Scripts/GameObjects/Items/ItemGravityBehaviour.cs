using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravityBehaviour : MonoBehaviour {

  #region Field

  [SerializeField] private const float DECELERATION = 0.9f;
  [SerializeField] private GameObject world;

  private Rigidbody2D rb;
  private bool inContact = false;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>(); 
    rb.gravityScale = ModeConfig.Instance.INITIAL_GRAVITY_SCALE;
  }

  void OnEnable() {
    EventManager.StartListening<ScoreEvent>(OnScoreEvent);
  }

  void OnDisable() {
    EventManager.StopListening<ScoreEvent>(OnScoreEvent);
  }

  void Update() {
    Vector2 direction = (Vector2) world.transform.position - (Vector2) transform.position;
    if (!inContact) { 
      if (direction.magnitude < Vector2.one.magnitude * ModeConfig.Instance.GravityMinDistance)
        rb.AddForce(direction.normalized * ModeConfig.Instance.PULL_FORCE * Time.deltaTime);
    } 
    rb.velocity = rb.velocity * DECELERATION;
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == world.layer) {
      inContact = true;
      rb.gravityScale = 0;
    }
  }
  
  void OnCollisionExit2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == world.layer) {
      inContact = false;
      rb.gravityScale = ModeConfig.Instance.GravityScale;
    }
  }

  #endregion

  #region Event Behaviour

  void OnScoreEvent(ScoreEvent scoreEvent) {
    rb.gravityScale = ModeConfig.Instance.GravityScale;
  }

  #endregion

  #region Public Behaviour

  public void Initialize(GameObject world) {
    this.world = world;
  }

  #endregion

}

