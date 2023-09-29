using System;
using UnityEngine;

namespace DefaultNamespace
{
    
    public enum Shape
    {
        Cube,Sphere,Mesh
    }
    public class GizmosDrawShape: MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            //变换矩阵,属于计算机图形学的基本内容
            //一切物体的缩放，旋转，位移，都可以通过变换矩阵作用得到。
            // https://zhuanlan.zhihu.com/p/144323332
            // https://zhuanlan.zhihu.com/p/340444415
            Gizmos.matrix = transform.localToWorldMatrix;
            var color = Color.magenta;
            color.a = 0.5f;
            Gizmos.color =color;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
            Gizmos.color = Color.clear;
            Gizmos.DrawSphere(Vector3.zero,1);
            color=Color.cyan;
            color.a = 0.5f;
            Gizmos.color = color;
            Gizmos.DrawWireCube(Vector3.one, Vector3.one);
            Gizmos.DrawWireSphere(-Vector3.one,1);
            
        }
    }
}