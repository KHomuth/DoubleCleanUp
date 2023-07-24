using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

    public float speed = 5f;

    public float closestDistance;

    private bool playerFound;

    private Vector3 startPos;
    private Quaternion startRot;

    Player closestPlayer;

    void Start() {
        setStartPosition();
    }

    void Update() {
        if (playerFound == true) {
            homingMove();
        }
    }

    public void FindClosestPlayer() {
        Player[] playerList = FindObjectsOfType<Player>();

        if(playerList != null) {
            playerFound = true;

            foreach (Player player in playerList) {
                float distanceToPlayer = (player.transform.position - transform.position).sqrMagnitude;

                if (distanceToPlayer < closestDistance) {
                    closestPlayer = player;

                } else {
                    playerFound = false;
                    resetPosition();
                }
            }
        }

        if(playerList.Length == 0) {
            playerFound = false;
        }
    }

    void homingMove() {
        Vector3 direction = transform.position - closestPlayer.transform.position;
        direction = -direction.normalized;
        transform.rotation = Quaternion.LookRotation(transform.forward, direction);
        transform.position += direction * speed * Time.deltaTime;
    }
    
    void setStartPosition() {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void resetPosition() {
        transform.position = startPos;
        transform.rotation = startRot;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(_damageAmount);
            resetPosition();
        }
    }
}
