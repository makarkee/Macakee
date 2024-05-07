using System;
using System.Collections;
using UnityEngine;

namespace Myd.Platform
{
    /// <summary>
    /// 跳跃检查组件
    /// </summary>
    public class JumpCheck
    {
        private float timer;    // 用于计时跳跃容许时间的计数器。

        private PlayerController controller;   //引用 PlayerController 类型的对象，用于获取角色控制器的状态信息。
        public float Timer => timer;
        private bool jumpGrace;    //一个布尔值，表示是否启用跳跃宽限时间（Jump Grace），即在离开地面一段时间后仍允许跳跃。
        public JumpCheck(PlayerController playerController, bool jumpGrace)
        {
            this.controller = playerController;
            this.ResetTime();    // 重置跳跃容许时间计时器（timer）
            this.jumpGrace = jumpGrace;
        }

        public void ResetTime()
        {
            this.timer = 0;
        }

        public void Update(float deltaTime)
        {
            //Jump Grace
            if (controller.OnGround)
            {
                //dreamJump = false;
                timer = Constants.JumpGraceTime;
            }
            else
            {
                if (timer > 0)
                {
                    timer -= deltaTime;
                }
            }
        }

        public bool AllowJump()
        {
            return jumpGrace ? timer > 0 : controller.OnGround;
        }
    }
}
//管理跳跃时的状态和条件。
//通过 JumpCheck 类，可以根据角色的状态（是否在地面上）、
//是否启用了跳跃宽限时间等条件，来判断是否允许角色执行跳跃操作。
//在更新过程中，根据角色的状态更新跳跃容许时间，并提供方法来检查是否可以执行跳跃动作。
//
//