using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxHelper
{
	class Autoclicker
	{
		private static bool left_click_loop;
		private static bool right_click_loop;
		private static bool right_left_hold;
		private static int left_click_loop_interval = 1100;
		private static int right_click_loop_interval = 300;

		public static void AddLeftClickLoopInterval(int addMiliseconds)
		{
			if(left_click_loop_interval + addMiliseconds > 0)
				left_click_loop_interval += addMiliseconds;
			Log.WritePrint(String.Format("Left click loop interval = {0}ms", left_click_loop_interval));
		}
		public static void AddRightClickLoopInterval(int addMiliseconds)
		{
			if (right_click_loop_interval + addMiliseconds > 0)
				right_click_loop_interval += addMiliseconds;
			Log.WritePrint(String.Format("Right click loop interval = {0}ms", right_click_loop_interval));
		}

		public static void ToggleLeftClick()
		{
			if (left_click_loop)
			{
				left_click_loop = false;
			}
			else
			{
				left_click_loop = true;
				LeftClickLoop();
			}
		}

		async public static void LeftClickLoop()
		{
			int counter = 0;
			while (left_click_loop)
			{
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
				Log.WritePrint(String.Format("Left click ({0})", counter++));
				await Task.Delay(left_click_loop_interval);
			}
		}

		public static void ToggleRightClick()
		{
			if (right_click_loop)
			{
				right_click_loop = false;
			}
			else
			{
				right_click_loop = true;
				RightClickLoop();
			}
		}

		async public static void RightClickLoop()
		{
			int counter = 0;
			while (right_click_loop)
			{
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
				MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
				Log.WritePrint(String.Format("Right click ({0})", counter++));
				await Task.Delay(right_click_loop_interval);
			}
		}

		public static void ToggleRightLeftHold()
		{
			if (right_left_hold)
			{
				right_left_hold = false;
				RightLeftHoldEnd();
			}
			else
			{
				right_left_hold = true;
				RightLeftHoldBegin();
			}
		}

		async public static void RightLeftHoldBegin()
		{
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
			await Task.Delay(100);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
			Log.WritePrint("Holding right and left mouse buttons");
		}
		public static void RightLeftHoldEnd()
		{
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
			Log.WritePrint("Releasing right and left mouse buttons");
		}

		public static void BeginLeftclickLoopWithShift()
		{
			KeyOperations.HoldShift();
			ToggleLeftClick();
		}
		public static void EndLeftclickLoopWithShift()
		{
			KeyOperations.ReleaseShift();
			ToggleLeftClick();
		}
		/*
		private static Queue<TimeSpan> WTaps = new();
		private static TimeSpan maxTapWait = new TimeSpan(0, 0, 2);
		public static void TryBeginHoldW()
		{
			if(WTaps.Count < 3)
			{
				WTaps.Enqueue(DateTime.Now.TimeOfDay);
				Log.WritePrint(DateTime.Now.TimeOfDay.ToString());
				return;
			}
			else
			{
				TimeSpan now = DateTime.Now.TimeOfDay;
				TimeSpan lastTap = WTaps.Dequeue();
				if(lastTap - now < maxTapWait)
				{
					Log.WritePrint("Holding W button");
				}
			}		
		}
		*/

		public static string GetHowToUse
		{
			get
			{
				StringBuilder sb = new();
				sb.AppendLine("F2 = -100ms from left click loop");
				sb.AppendLine("F3 = +100ms to left click loop");
				sb.AppendLine("F4 = toggle left click loop");
				sb.AppendLine("F5 = -100ms from right click loop");
				sb.AppendLine("F6 = +100ms to right click loop");
				sb.AppendLine("F7 = toggle right click loop");
				sb.AppendLine("F8 = toggle right left hold");
				sb.AppendLine("F9 = pull items (toggle left click loop and hold shift)");
				sb.AppendLine("Alt + W = Begin hold W / cancel by pressing W");
				return sb.ToString();
			}
		}
	}
}
