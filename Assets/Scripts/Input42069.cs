using System;
using UnityEngine;
public class Input42069
{
    public static Touch[] touches
    {
        get
        {
            if (Application.isMobilePlatform)
            {
                return Input.touches;
            }
            // kill yourself
            return InputHelper.GetTouches().ToArray();
        }
    }
}
