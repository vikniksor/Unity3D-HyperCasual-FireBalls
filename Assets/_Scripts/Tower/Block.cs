using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{

    public event UnityAction<Block> BulletHit;

    public void Break()
    {
        BulletHit?.Invoke(this);
        Destroy(gameObject);
    }

}
