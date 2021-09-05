using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerSizeView : MonoBehaviour
{

    [SerializeField] private TMP_Text _sizeView;
    [SerializeField] private Tower _tower;


    private void OnEnable()
    {
        _tower.SizeUpdated += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= OnSizeUpdated;
    }

    private void OnSizeUpdated(int size)
    {
        _sizeView.text = size.ToString();
    }
}
