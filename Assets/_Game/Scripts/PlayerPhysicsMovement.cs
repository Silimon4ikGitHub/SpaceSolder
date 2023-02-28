using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerPhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private int colliders;
    [SerializeField] private Vector3 down;
    private Vector3 _normal;
    
    
    public Vector3 Project(Vector3 forward)
    {
        return forward - Vector3.Dot(forward, _normal) * _normal;    
    }

    private void OnCollisionEnter(Collision collision)
    {
        colliders = collision.contacts.Length;
        if (collision.contacts.Length != null && collision.contacts.Length < 2)
        {
        _normal = collision.contacts[0].normal;
        }
        else
        {
        _normal = down;
        }
    }
    
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + _normal * 1000);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Project(transform.forward) * 1000);
    }

    public void Move(Vector3 direction)
    {
        Vector3 dirrectionAlongSurface = Project(direction.normalized);
        Vector3 offset = dirrectionAlongSurface * (speed * Time.deltaTime);

        rigidbody.MovePosition(rigidbody.position + offset);
        
    }
}
