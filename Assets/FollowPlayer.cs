using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _smoothSpeed;

    private void Start()
    {
        transform.position = new Vector3(_playerTransform.position.x, transform.position.y, _playerTransform.position.z);
    }

    private void Update()
    {
        Vector3 finalPos = new Vector3(transform.position.x, transform.position.y, _playerTransform.position.z);
        Vector3 smoothPos = Vector3.Lerp(transform.position, finalPos, _smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }
}
