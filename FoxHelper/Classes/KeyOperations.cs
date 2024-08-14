using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;

namespace FoxHelper{
	class KeyOperations
	{
    public const byte KEYBDEVENTF_SHIFTVIRTUAL = 0x10;
    public const byte VK_W = 0x57;
    public const byte KEYBDEVENTF_SHIFTSCANCODE = 0x2A;
    public const int KEYBDEVENTF_KEYDOWN = 0;
    public const int KEYBDEVENTF_KEYUP = 2;
    //const int KEYEVENTF_KEYDOWN As Integer = &H0

    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

    public static void HoldShift()
		{
      keybd_event(KEYBDEVENTF_SHIFTVIRTUAL, KEYBDEVENTF_SHIFTSCANCODE, KEYBDEVENTF_KEYDOWN, 0);
      Log.WritePrint("Holding SHIFT.");
    }
    public static void ReleaseShift()
    {
      keybd_event(KEYBDEVENTF_SHIFTVIRTUAL, KEYBDEVENTF_SHIFTSCANCODE, KEYBDEVENTF_KEYUP, 0);
      Log.WritePrint("Releasing SHIFT");
    }
    public static void HoldW()
    {
      keybd_event(VK_W, KEYBDEVENTF_SHIFTSCANCODE, KEYBDEVENTF_KEYDOWN, 0);
      Log.WritePrint("Holding W.");
    }

    // original code for windows hooks
    /*
    [DllImport("User32.dll")]AAAAAAAAAaaaaaa
private static extern bool RegisterHotKey(
    [In] IntPtr hWnd,
    [In] int id,
    [In] uint fsModifiers,
    [In] uint vk);

[DllImport("User32.dll")]
private static extern bool UnregisterHotKey(
    [In] IntPtr hWnd,
    [In] int id);

private HwndSource _source;
private const int HOTKEY_ID = 9000;

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
    const uint VK_F10 = 0x79;
    const uint MOD_CTRL = 0x0002;
    if(!RegisterHotKey(helper.Handle, HOTKEY_ID, MOD_CTRL, VK_F10))
    {
        // handle error
    }
}

private void UnregisterHotKey()
{
    var helper = new WindowInteropHelper(this);
    UnregisterHotKey(helper.Handle, HOTKEY_ID);
}

private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
{
    const int WM_HOTKEY = 0x0312;
    switch(msg)
    {
        case WM_HOTKEY:
            switch(wParam.ToInt32())
            {

    */
  }
}
