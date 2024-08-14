using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FoxHelper 
{ 
	public static class Log
	{
		static StringBuilder sb = new();
		public static TextBlock console;

		public static void Write(string content)
		{
			sb.Insert(0, content + Environment.NewLine );
			//sb.AppendLine(content);
		}
		public static void WritePrint(string content)
		{
			Write(content);
			console.Text = sb.ToString();
		}
		public static void Print()
		{
			console.Text = sb.ToString();
		}
		public static void Clear()
		{
			sb.Clear();
		}
	}
}
