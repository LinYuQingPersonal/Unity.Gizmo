using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GizmosDrawMesh: MonoBehaviour
    {
        public float distance;
        public Mesh Mesh;
        public void OnDrawGizmos()
        {
            if (Mesh is not UnityEngine.Mesh{})
            {
                return;
            }
            Matrix4x4 matrix4X4 = new Matrix4x4();
            matrix4X4.SetTRS(transform.position,transform.rotation,transform.lossyScale);
            Gizmos.matrix = matrix4X4;
            
            matrix4X4.SetTRS(transform.position+new Vector3(0,distance,0),transform.rotation,transform.lossyScale);
            Gizmos.matrix = matrix4X4;
            Gizmos.DrawMesh(Mesh);
            matrix4X4.SetTRS(transform.position+new Vector3(0,distance*2,0),transform.rotation,transform.lossyScale);
            Gizmos.matrix = matrix4X4;
            Gizmos.DrawMesh(Mesh,1);
            matrix4X4.SetTRS(transform.position+new Vector3(0,distance*3,0),transform.rotation,transform.lossyScale);
            Gizmos.matrix = matrix4X4;
            Gizmos.DrawWireMesh(Mesh);
        }
    }
}