using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform PickUpSpawnPlatform;

    private GameObject item;


    public void SetItem(GameObject newItem)
    {
        if (item != null)
        {
            Destroy(item.gameObject);
            item = null;
        }

        item = newItem;
        Instantiate(item, PickUpSpawnPlatform);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
