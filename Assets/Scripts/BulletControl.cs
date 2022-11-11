using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float bulletTtl = 5f;
    public ParticleSystem spark;
    [SerializeField] GameObject particleToSpawn;
    [SerializeField] Transform particleSpawnPoint;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<TankController>().spelerNummer == 1)
            {
                Debug.Log("b geraakt");
                //GameObject.Find("Canvas").GetComponent<ScoreScript>().AddP1Score();
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<TankController>().spelerNummer == 2)
            {
                Debug.Log("o geraakt");
                //GameObject.Find("Canvas").GetComponent<ScoreScript>().AddP2Score();
            }
        }
        // FAck();
        ParticleSpawner();
        Destroy(gameObject);
        Destroy(particleSpawnPoint);
        //GameObject.Find("folocity").GetComponent<FelocityAmount>().AddP1felocity();
    }
    private void ParticleSpawner()
    {
        Instantiate(particleToSpawn, particleSpawnPoint.position, particleSpawnPoint.rotation);
    }
}

