using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    public Transform AimTransform;


    private Camera _camera;
    private Plane _plane = new Plane(-Vector3.forward, Vector3.zero);
    private PlayerMove _playerMove;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
        _playerMove = FindObjectOfType<PlayerMove>();
    }


    void LateUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        float distance;
        _plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        AimTransform.position = point;

        Vector3 toAim = point - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        /*
        if (toAim.x >= 0)
        {
            Quaternion targetRotation = Quaternion.Euler(_playerMove.transform.rotation.x, -40, _playerMove.transform.rotation.z);
            _playerMove.transform.rotation = Quaternion.Lerp(_playerMove.transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, 40, 0);
            _playerMove.transform.rotation = Quaternion.Lerp(_playerMove.transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
        */
    }
}
