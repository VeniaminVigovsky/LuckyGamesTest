using UnityEngine;
public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _smoothSpeed;

    private Vector3 _offset;

    private Vector3 _velocityVector = Vector3.zero;

    private void Awake()
    {
        _offset = _player.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _player.position - _offset, ref _velocityVector, _smoothSpeed * Time.deltaTime);
    }
}
