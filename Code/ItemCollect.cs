using UnityEngine;

public class ItemCollect : MonoBehaviour

{
    static int count = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            count++;
            Destroy(gameObject);

            if (count >= 3)
            {
                Debug.Log("You Win!");
            }
        }
    }
}

