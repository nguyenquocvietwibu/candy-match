using System.Collections;
using UnityEngine;

namespace External
{
    public class WorldTimeService : IWorldTimeService
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Resume()
        {
            Time.timeScale = 1;
        }
    }
}