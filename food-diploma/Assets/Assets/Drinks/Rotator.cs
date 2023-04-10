using UnityEngine;
using System;

public enum Axis
{
    X,
    Y,
    Z,
}

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private Axis _axis;
    
    [SerializeField]
    private float _speed;
    
    private void Update()
    {
        switch (_axis)
        {
            case Axis.X:
                transform.Rotate(Vector3.right, _speed * Time.deltaTime);
                break;
            case Axis.Y:
                transform.Rotate(Vector3.up, _speed * Time.deltaTime);
                break;
            case Axis.Z:
                transform.Rotate(Vector3.forward, _speed * Time.deltaTime);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}