using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace FoxHelper
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		#region GLOBAL_KEYS_WIDOW_HOOK
		[DllImport("User32.dll")]
		private static extern bool RegisterHotKey([In] IntPtr hWnd,[In] int id,[In] uint fsModifiers, [In] uint vk);

		[DllImport("User32.dll")]
		private static extern bool UnregisterHotKey([In] IntPtr hWnd,[In] int id);

		private HwndSource _source;
		// increment for click loops in miliseconds
		public int clickIncrement = 100;
		// hotkeys
		private const int HOTKEY_LEFT_CLICK_LOOP_ADD = 9000;
		private const int HOTKEY_LEFT_CLICK_LOOP_SUBTRACT = 9001;
		private const int HOTKEY_LEFT_CLICK_LOOP_TOGGLE = 9002;
		private const int HOTKEY_RIGHT_CLICK_LOOP_ADD = 9003;
		private const int HOTKEY_RIGHT_CLICK_LOOP_SUBTRACT = 9004;
		private const int HOTKEY_RIGHT_CLICK_LOOP_TOGGLE = 9005;
		private const int HOTKEY_RIGHT_LEFT_HOLD_TOGGLE = 9006;
		private const int HOTKEY_F9 = 9007;
		private const int HOTKEY_HOLD_SHIFT_WITH_F9 = 9008;
		private const int HOTKEY_W = 9009;

		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);
			var helper = new WindowInteropHelper(this);
			_source = HwndSource.FromHwnd(helper.Handle);
			_source.AddHook(HwndHook);
			RegisterHotKey();
		}

		protected override void OnClosed(EventArgs e)
		{
			_source.RemoveHook(HwndHook);
			_source = null;
			UnregisterHotKey();
			base.OnClosed(e);
		}

		private void RegisterHotKey()
		{
			var helper = new WindowInteropHelper(this);
			const uint VK_F1 = 0x70;
			const uint VK_F2 = 0x71;
			const uint VK_F3 = 0x72;
			const uint VK_F4 = 0x73;
			const uint VK_F5 = 0x74;
			const uint VK_F6 = 0x75;
			const uint VK_F7 = 0x76;
			const uint VK_F8 = 0x77;
			const uint VK_F9 = 0x78;
			const uint VK_F10 = 0x79;
			const uint VK_F11 = 0x7A;
			const uint VK_W = 0x57;
			//const uint MOD_CTRL = 0x0002; //RIGHT CTRL
			const uint MOD_SHIFT = 0x0004;
			const uint MOD_ALT = 0x0001;
			const uint MOD_CTRL = 0;
			RegisterHotKey(helper.Handle, HOTKEY_LEFT_CLICK_LOOP_ADD, MOD_CTRL, VK_F3);
			RegisterHotKey(helper.Handle, HOTKEY_LEFT_CLICK_LOOP_SUBTRACT, MOD_CTRL, VK_F2);
			RegisterHotKey(helper.Handle, HOTKEY_LEFT_CLICK_LOOP_TOGGLE, MOD_CTRL, VK_F4);
			RegisterHotKey(helper.Handle, HOTKEY_RIGHT_CLICK_LOOP_ADD, MOD_CTRL, VK_F6);
			RegisterHotKey(helper.Handle, HOTKEY_RIGHT_CLICK_LOOP_SUBTRACT, MOD_CTRL, VK_F5);
			RegisterHotKey(helper.Handle, HOTKEY_RIGHT_CLICK_LOOP_TOGGLE, MOD_CTRL, VK_F7);
			RegisterHotKey(helper.Handle, HOTKEY_RIGHT_LEFT_HOLD_TOGGLE, MOD_CTRL, VK_F8);
			RegisterHotKey(helper.Handle, HOTKEY_F9, MOD_CTRL, VK_F9);
			RegisterHotKey(helper.Handle, HOTKEY_HOLD_SHIFT_WITH_F9, MOD_SHIFT, VK_F9);
			RegisterHotKey(helper.Handle, HOTKEY_W, MOD_ALT, VK_W);
		}

		private void UnregisterHotKey()
		{
			var helper = new WindowInteropHelper(this);
			UnregisterHotKey(helper.Handle, HOTKEY_LEFT_CLICK_LOOP_ADD);
			UnregisterHotKey(helper.Handle, HOTKEY_LEFT_CLICK_LOOP_SUBTRACT);
			UnregisterHotKey(helper.Handle, HOTKEY_LEFT_CLICK_LOOP_TOGGLE);
			UnregisterHotKey(helper.Handle, HOTKEY_RIGHT_CLICK_LOOP_ADD);
			UnregisterHotKey(helper.Handle, HOTKEY_RIGHT_CLICK_LOOP_SUBTRACT);
			UnregisterHotKey(helper.Handle, HOTKEY_RIGHT_CLICK_LOOP_TOGGLE);
			UnregisterHotKey(helper.Handle, HOTKEY_RIGHT_LEFT_HOLD_TOGGLE);
			UnregisterHotKey(helper.Handle, HOTKEY_F9);
			UnregisterHotKey(helper.Handle, HOTKEY_HOLD_SHIFT_WITH_F9);
			UnregisterHotKey(helper.Handle, HOTKEY_W);
		}

		private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			const int WM_HOTKEY = 0x0312;
			switch (msg)
			{
				case WM_HOTKEY:
					switch (wParam.ToInt32())
					{
						case HOTKEY_LEFT_CLICK_LOOP_ADD:
							Autoclicker.AddLeftClickLoopInterval(clickIncrement);
							handled = true;
							break;
						case HOTKEY_LEFT_CLICK_LOOP_SUBTRACT:
							Autoclicker.AddLeftClickLoopInterval(-clickIncrement);
							handled = true;
							break;
						case HOTKEY_LEFT_CLICK_LOOP_TOGGLE:
							Autoclicker.ToggleLeftClick();
							handled = true;
							break;
						case HOTKEY_RIGHT_CLICK_LOOP_ADD:
							Autoclicker.AddRightClickLoopInterval(clickIncrement);
							handled = true;
							break;
						case HOTKEY_RIGHT_CLICK_LOOP_SUBTRACT:
							Autoclicker.AddRightClickLoopInterval(-clickIncrement);
							handled = true;
							break;
						case HOTKEY_RIGHT_CLICK_LOOP_TOGGLE:
							Autoclicker.ToggleRightClick();
							handled = true;
							break;
						case HOTKEY_RIGHT_LEFT_HOLD_TOGGLE:
							Autoclicker.ToggleRightLeftHold();
							handled = true;
							break;
						case HOTKEY_F9:
							Autoclicker.BeginLeftclickLoopWithShift();
							handled = true;
							break;
						case HOTKEY_HOLD_SHIFT_WITH_F9:
							Autoclicker.EndLeftclickLoopWithShift();
							handled = true;
							break;
						case HOTKEY_W:
							Log.WritePrint(lParam.ToInt32().ToString());
							KeyOperations.HoldW();
							handled = true;
							break;
					}
					break;
			}
			return IntPtr.Zero;
		}
		#endregion

		public MainWindow()
		{
			InitializeComponent();
			Log.console = LogBox;
			AutoclickerInstructions.Content = Autoclicker.GetHowToUse;
			CreditsBlock.Text = Credits.GetCredits;
			DestructionController.InitStructuresTable();
			ExplosivesController.InitExplosivesTable();
			StructuresGrid.ItemsSource = DestructionController.Structures;
			ExplosivesGrid.ItemsSource = ExplosivesController.Explosives;
			WetnessSlider.Value = 24;
		}

		private void WetnessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			WetnessLabel.Content = String.Format("Concrete dryness = {0:f2}h{1}Wet concrete damage modifier = {2:f2}", e.NewValue,Environment.NewLine,DestructionController.GetWetConcreteDamageModifier(e.NewValue));
			UpdateDestructionTab();
		}

		private void StructuresGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			//UpdateDestructionTab();
		}

		private void UpdateDestructionTab()
		{
			double totalHP = DestructionController.GetTotalHealth;
			decimal totalNormalIntegrity = DestructionController.GetTotalIntegrity;
			decimal totalConcreteIntegrity = totalNormalIntegrity * DestructionController.DrynessModifier;
			//decimal totalIntegrity = totalNormalIntegrity * totalConcreteIntegrity;
			
			HealthLabel.Content = String.Format("Total structure health = {0:f2}HP", totalHP);
			EffectiveHealthLabel.Content = String.Format("Total dry structure health = {0:f2}HP", totalHP * (double)totalNormalIntegrity);
			EffectiveConcreteHealthLabel.Content = String.Format("Total wet structure health = {0:f2}HP", totalHP * (double)totalConcreteIntegrity);
			IntegrityLabel.Content = String.Format("Total structural integrity = {0:f2}%", totalConcreteIntegrity * 100);
			ExplosivesController.RecalculateNeededCount(totalHP, totalNormalIntegrity, totalConcreteIntegrity);
			ExplosivesGrid.Items.Refresh();
		}

		private void StructuresGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			UpdateDestructionTab();
		}
	}
}
