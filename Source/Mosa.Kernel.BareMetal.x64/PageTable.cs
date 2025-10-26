// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Runtime;

namespace Mosa.Kernel.BareMetal.x64;

internal static class PageTable
{
	public static GDT GDTTable;

	public static void Setup()
	{
		Debug.WriteLine("x64.PageTable:Setup()");

		GDTTable.Setup();

		Debug.WriteLine("x64.PageTable:Setup() [Exit]");
	}

	public static void Initialize()
	{
		Debug.WriteLine("x64.PageTable:Initialize()");

		for (; ; );

		Debug.WriteLine("x64.PageTable:Initialize() [Exit]");
	}

	public static void Enable()
	{
		Debug.WriteLine("x64.PageTable:Enable()");

		Debug.WriteLine("x64.PageTable:Enable() [Exit]");
	}

	public static void MapVirtualAddressToPhysical(Pointer virtualAddress, Pointer physicalAddress, bool present = true) { }

	public static Pointer GetPhysicalAddressFromVirtual(Pointer virtualAddress)
	{
		return Pointer.Zero;
	}
}
