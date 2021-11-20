using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomiser : MonoBehaviour
{
    [SerializeField] private List<Color> _colorList = new List<Color>();
    [SerializeField] private MeshRenderer _positionCubeMesh;

    private void Awake()
    {
        Color selectedColor = _colorList[Random.Range(0, _colorList.Count)];

        foreach(Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().material.color = selectedColor;
        }

        _positionCubeMesh.material.color = selectedColor;
    }
}
