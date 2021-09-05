using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{

    private TowerBuilder _towerBuilder;

    private List<Block> _blocks;


    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Builder();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBullletHit;
        }
    }


    private void OnBullletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBullletHit;

        _blocks.Remove(hitedBlock);

        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x,
                block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }
        
    }
}
