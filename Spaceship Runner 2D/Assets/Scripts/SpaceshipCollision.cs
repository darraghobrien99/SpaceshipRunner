using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollision : MonoBehaviour
{
    [SerializeField] private int lives = 1;
    public static SpaceshipCollision Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScript()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Entity"))
        {
            if (collision.GetComponent<EntityType>().entityType == EntityType.EntityTypes.star)
            {
                //add score
                //MoneyManager.Instance.addCurrency(1);
                Destroy(collision.gameObject);
            }

            else
            {
                onHitAsteroid();
            }
 
         }
    }


    private void onHitAsteroid()
    {
        lives--;
        if(lives <= 0)
        {
            FinishGameManager.Instance.FinishGame();
        }
        else
        {
            //fire animation
        }
    }
}
