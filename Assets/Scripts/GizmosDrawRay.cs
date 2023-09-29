using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GizmosDrawRay: MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Ray ray = new Ray(transform.position, transform.up);
            Gizmos.DrawRay(ray);
            var martix = Matrix4x4.Rotate(Quaternion.Euler(30, 30, 30))*Matrix4x4.Scale(new Vector3(5,5,5));
            Gizmos.matrix = transform.localToWorldMatrix*martix;
            Gizmos.DrawRay(Vector3.zero, transform.forward);
        }
    }
}