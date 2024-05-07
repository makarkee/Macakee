using UnityEngine;

namespace Myd.Common              //动态调整摄像机的正交尺寸，以确保在不同屏幕分辨率下显示效果良好。
{//可以根据当前屏幕的宽高比自动计算出最合适的摄像机正交尺寸，从而适应不同的屏幕大小和比例。
    public static class ScreenResolutionUtil
    {
        public static float ScreenW = 3200, ScreenH = 1800;
        //调整摄像机，优先保证宽度
        public static float CalcOrthographicSize()
        {
            //获取当前
            float baseRate = ScreenW / ScreenH;
            float currRate = (Screen.width * 1.0f) / (Screen.height * 1.0f);
            if (currRate >= baseRate)
            {
                return ScreenH / 100.0f / 2f;
            }
            else
            {
                //优先满足宽度可见
                return ScreenW * (Screen.height * 1.0f) / (Screen.width * 1.0f) / 100.0f / 2f;
            }
        }
    }
}
