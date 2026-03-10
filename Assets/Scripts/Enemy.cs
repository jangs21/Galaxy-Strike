using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;

    Scoreboard scoreboard; //Allows me to talk to the scoreboard. I can call methods on it, and I can change variables on it. But right now, it's just an empty seat.
    bool isDead = false; // Starting with the assumption that the enemy is alive

    private void Start()
    {
        scoreboard = FindAnyObjectByType<Scoreboard>(); //This is you actually filling that seat. You go out into the scene, find the actual object, and put it into the spot you reserved at the top.
    }

    private void OnParticleCollision (GameObject other)
    {
        ProcessHit(other);
    }

    private void ProcessHit(GameObject other)
    {
        // 2. If already dead, stop everything immediately
        if (isDead) return;

        hitPoints--;

        if (hitPoints <= 0)
        {
            isDead = true; // 3. Set this to true BEFORE giving points or destroying
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}