using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{

    [SerializeField] private ParticleSystem _destroyEffect;

    public event UnityAction<Block> BulletHit;


    public void SetColor(Color color)
    {

    }


    public void Break()
    {
        BulletHit?.Invoke(this);
        ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position,
            Quaternion.identity).GetComponent<ParticleSystemRenderer>();
        renderer.material.color = GetComponent<MeshRenderer>().material.color;  // cos all our blocks has different colors
        Destroy(gameObject);
    }

}
