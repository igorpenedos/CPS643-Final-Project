using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItemController : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
