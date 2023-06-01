using UnityEngine;

namespace Utils
{
    public static class TimeExtensions
    {
        public static string FormatTime(float time)
        {
            var minutes = Mathf.FloorToInt(time / 60F);
            var seconds = Mathf.FloorToInt(time % 60F);
            var milliseconds = Mathf.FloorToInt((time * 100F) % 100F);
            return minutes.ToString("00") + ":" +
                   seconds.ToString("00") + ":" +
                   milliseconds.ToString("00");
        }
    }
}