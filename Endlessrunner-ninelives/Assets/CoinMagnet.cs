using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.TryGetComponent<Points>(out Points coin)){
            coin.SetTarget(transform.parent.position);
        }
    }
}
