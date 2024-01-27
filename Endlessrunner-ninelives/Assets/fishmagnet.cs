using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishmagnet : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.TryGetComponent<fishPoints>(out fishPoints coin)){
            coin.SetTarget(transform.parent.position);
        }
    }
}
