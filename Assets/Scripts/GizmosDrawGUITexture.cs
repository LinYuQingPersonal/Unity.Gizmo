using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

[HelpURL("https://docs.unity.cn/cn/current/ScriptReference/Gizmos.DrawGUITexture.html")]
public class GizmosDrawGUITexture : MonoBehaviour
{
    [SerializeField] private Texture m_DefaultTexture;
    [SerializeField] private Vector2 m_ThirdTextureOffset;
    [SerializeField] private Rect m_SelectedRect;
    [SerializeField] private Material m_GizmoMaterial;
    [SerializeField] private int leftBorder;
    [SerializeField] private int rightBorder;
    [SerializeField] private int topBorder;
    [SerializeField] private int downBorder;
    public bool lockRect = true;
    private void Awake()
    {
        //在Awake的时候创建Rect,而不是每一帧都创建,对性能有小优化
        m_SelectedRect = Utility.GetTextureRect(transform.position, m_DefaultTexture);
    }

    /// <summary>
    /// 当编辑器字段被改变的时候,刷新图片
    /// </summary>
    private void OnValidate()
    {
        if (lockRect)
        {
            m_SelectedRect = Utility.GetTextureRect(transform.position, m_DefaultTexture);
        }
    }

    //在实际的项目中, 仅在Editor模式下出现的东西,需要用#if UNITY_EDITOR包裹
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (m_DefaultTexture != null)
        {
            //Gizmos.matrix对DrawGUITexture无效
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawGUITexture(new Rect(Vector2.zero,Vector2.one),m_DefaultTexture);  
        }
        
        if (m_DefaultTexture != null)
        {
            //声明变量,避免重复获取transform.position,有助于提高性能
            //<!--这条是IDE的提示,我的猜想是值类型的访问,每一次都是创建一个新的变量赋值过去-->
            var position = transform.position;
            //位置的修改,是实时的,所以需要一直获取
            m_SelectedRect.position = new Vector2(position.x, position.y);
            Gizmos.DrawGUITexture(m_SelectedRect,m_DefaultTexture,m_GizmoMaterial);
            //值类型,在没有ref修饰符的时候, 是拷贝一份值过去, 所以我们在这里修改不会影响上面的.
            //即使是class(引用类型),绘制逻辑已经在上一个语句绘制完成了,所以不需要担心
            m_SelectedRect.position += m_ThirdTextureOffset; 
            Gizmos.color=Color.magenta;
            Gizmos.DrawGUITexture(m_SelectedRect,m_DefaultTexture,leftBorder,rightBorder,topBorder,downBorder);
        }
         
        
    } 
    
#endif
}
