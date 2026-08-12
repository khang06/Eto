namespace Eto.WinForms;

static class DpiExtensions
{
	static int Scale(double value) => (int)Math.Round(value, MidpointRounding.AwayFromZero);

	public static Size DeviceUnitsToLogical(this swf.Control control, sd.Size size)
	{
#if NET9_0_OR_GREATER
		var dpi = control.DeviceDpi;
		return new Size(Scale(size.Width * 96.0 / dpi), Scale(size.Height * 96.0 / dpi));
#else
		return size.ToEto();
#endif
	}

	public static Rectangle DeviceUnitsToLogical(this swf.Control control, sd.Rectangle rectangle)
	{
#if NET9_0_OR_GREATER
		var location = control.DeviceUnitsToLogical(rectangle.Location);
		var size = control.DeviceUnitsToLogical(rectangle.Size);
		return new Rectangle(location, size);
#else
		return rectangle.ToEto();
#endif
	}
	public static Point DeviceUnitsToLogical(this swf.Control control, sd.Point point)
	{
#if NET9_0_OR_GREATER
		var dpi = control?.DeviceDpi ?? 96;
		return new Point(Scale(point.X * 96.0 / dpi), Scale(point.Y * 96.0 / dpi));
#else
		return point.ToEto();
#endif
	}
	public static int DeviceUnitsToLogical(this swf.Control control, int size)
	{
#if NET9_0_OR_GREATER
		var dpi = control?.DeviceDpi ?? 96;
		return Scale(size * 96.0 / dpi);
#else
		return size;
#endif
	}

	public static sd.Size LogicalToDeviceUnits(this swf.Control control, Size size)
	{
#if NET9_0_OR_GREATER
		var dpi = control?.DeviceDpi ?? 96;
		return new sd.Size(Scale(size.Width * dpi / 96.0), Scale(size.Height * dpi / 96.0));
#else
		return size.ToSD();
#endif
	}

	public static sd.Point LogicalToDeviceUnits(this swf.Control control, Point point)
	{
#if NET9_0_OR_GREATER
		var dpi = control?.DeviceDpi ?? 96;
		return new sd.Point(Scale(point.X * dpi / 96.0), Scale(point.Y * dpi / 96.0));
#else
		return point.ToSD();
#endif
	}

#if !NET9_0_OR_GREATER
	public static sd.Size LogicalToDeviceUnits(this swf.Control control, sd.Size size)
	{
		return size;
	}
	public static int LogicalToDeviceUnits(this swf.Control control, int size)
	{
		return size;
	}
#endif

}
