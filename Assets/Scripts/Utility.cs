using UnityEngine;

namespace DefaultNamespace
{
    public static class Utility
    {

        //在实际的项目中,最好尽可能的减少Ultility类, 如果必要,可以采用适配器模式替代
        public static Rect GetTextureRect(Vector3 position,Texture texture, float scale = 0.01f)
        { 
            return new Rect(position.x, position.y, texture.width * scale, texture.height * -scale);
        }
    }
}