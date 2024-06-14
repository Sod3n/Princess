using Assets.Project2DExample;
using ControllsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeSystem
{
    public static class TimeManager
    {
        public static void StopWorld()
        {
            ControllsSelector.BlockControlls = true;
            Time.timeScale = 0f;
        }
        public static void StartWorld()
        {
            Time.timeScale = 1f;
            ControllsSelector.BlockControlls = false;
        }
    }
}
