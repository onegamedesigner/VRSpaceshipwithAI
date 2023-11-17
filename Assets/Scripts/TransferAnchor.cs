using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferAnchor : MonoBehaviour
{
    public GameObject player;
    
    public void Transfer()
    {
        player.transform.position = transform.position;
    }
}
