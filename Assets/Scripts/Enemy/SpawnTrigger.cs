using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class SpawnTrigger : MonoBehaviour
{
    public GameObject targetSpawn;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
        if(other.CompareTag("Player"))
        {
            targetSpawn.SetActive(true);
            gameObject.SetActive(false);
        }
    }
 
}
