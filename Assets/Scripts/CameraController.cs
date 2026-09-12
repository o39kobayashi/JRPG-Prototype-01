using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _pivot;

    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _cameraSpeed;
    [SerializeField] private float _cameraLookSpeed;
    [SerializeField] private float _cameraPivotSpeed;
    [SerializeField] private float _cameraCollisionRadius;
    [SerializeField] private float _cameraCollisionOffset;
    [SerializeField] private float _minimumCollisionOffset;

    [SerializeField] private LayerMask _collisionLayers;

    private Vector3 _cameraSmoothVelocity;
    private Vector3 _cameraVectorPosition;

    private float _cameraHorizontalInput;
    private float _cameraVerticalInput;

    private float _defaultPosition;
    private float _lookAngle;
    private float _pivotAngle;
    private float _maximumPivotAngle = 35.0f;
    private float _minimumPivotAngle = -35.0f;


    public float CameraHorizontalInput { get { return _cameraHorizontalInput; } set { _cameraHorizontalInput = value; } }
    public float CameraVerticalInput { get { return _cameraVerticalInput; } set { _cameraVerticalInput = value; } }


    private void Start() {

        _cameraSmoothVelocity = Vector3.zero;

        _defaultPosition = _camera.localPosition.z;
    
    }

    private void LateUpdate() {

        RotateCamera();
        FollowPlayer();
        HandleCollisions();
        // LookAtPlayer();
    
    }

    private void FollowPlayer() {

        // Vector3 targetPosition = _player.position + _offset;
        Vector3 targetPosition = _player.position;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _cameraSmoothVelocity, _cameraSpeed * Time.deltaTime);
    
    }

    private void RotateCamera() {

        Vector3 verticalRotation;
        Vector3 horizontalRotation;

        Quaternion targetRotation;

        _lookAngle = _lookAngle + (_cameraHorizontalInput * _cameraLookSpeed);
        _pivotAngle = _pivotAngle + (_cameraVerticalInput * _cameraPivotSpeed);

        _pivotAngle = Mathf.Clamp(_pivotAngle, _minimumPivotAngle, _maximumPivotAngle);

        verticalRotation = Vector3.zero;
        verticalRotation.y = _lookAngle;
        targetRotation = Quaternion.Euler(verticalRotation);
        transform.rotation = targetRotation;

        horizontalRotation = Vector3.zero;
        horizontalRotation.x = _pivotAngle;
        targetRotation = Quaternion.Euler(horizontalRotation);
        _pivot.localRotation = targetRotation;
        
    }

    private void HandleCollisions() {

        float targetPosition = _defaultPosition;

        RaycastHit hit;

        Vector3 direction = _camera.position - _pivot.position;
        direction.Normalize();

        if (Physics.SphereCast(_pivot.position, _cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), _collisionLayers)) {

            float distance = Vector3.Distance(_pivot.position, hit.point);
            targetPosition = -(distance - _cameraCollisionOffset);
        
        }

        if (Mathf.Abs(targetPosition) < _minimumCollisionOffset) {

            targetPosition = targetPosition - _minimumCollisionOffset;

        }

        _cameraVectorPosition.z = Mathf.Lerp(_camera.localPosition.z, targetPosition, 0.2f);

        _camera.localPosition = _cameraVectorPosition;
    
    
    }

    private void LookAtPlayer() {

        _camera.LookAt(_player.position);
    
    }



}
