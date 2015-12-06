using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public class CollisionDetector
    {
        /// <summary> 
        /// Calculates if rectangles describing two sprites 
        /// are overlapping on screen. 
        /// </summary> 
        /// <param name="s1">First sprite</param> 
        /// <param name="s2">Second sprite</param> 
        /// <returns>Returns true if overlapping</returns>
        public static bool Overlaps(Sprite s1, Sprite s2)
        {
            if(s1.Position.Y > s2.Position.Y)
            {
                Sprite tmp = s1;
                s1 = s2;
                s2 = tmp;
            }

            float left1 = s1.Position.X;
            float right1 = s1.Position.X + s1.Size.Width;
            float bottom1 = s1.Position.Y + s1.Size.Height;
            float left2 = s2.Position.X;
            float right2 = s2.Position.X + s2.Size.Width;
            float top2 = s2.Position.Y;

            if(bottom1 < top2 || right1 < left2 || right2 < left1)
            {
                return false;
            }
            return true;
        }
    }
}
