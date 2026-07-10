using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Encapsulated window handle for different platforms.
/// </summary>
public class WindowHandle
{
    private WindowHandle()
    {
    }

    /// <summary>
    /// The GdkWindow* instance
    /// </summary>
    public static WindowHandle FromGdk(IntPtr window)
    {
        return new WindowHandle();
    }

    /// <summary>
    /// Create  from an XCB surface.
    /// </summary>
    public static WindowHandle FromXcb(IntPtr connection, IntPtr surface)
    {
        return new WindowHandle();
    }

    /// <summary>
    /// Create  from a Wayland surface
    /// </summary>
    public static WindowHandle FromWayland(IntPtr display, IntPtr surface)
    {
        return new WindowHandle();
    }

    /// <summary>
    /// Create  from an Xlib window
    /// </summary>
    public static WindowHandle FromXlib(IntPtr display, IntPtr window)
    {
        return new WindowHandle();
    }

    /// <summary>
    /// The native HWND instance in Windows environment.
    /// </summary>
    public static WindowHandle FromWin32(IntPtr hWnd)
    {
        return new WindowHandle();
    }
}
