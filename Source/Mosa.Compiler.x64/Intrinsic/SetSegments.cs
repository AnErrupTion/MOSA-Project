// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.x64.Intrinsic;

/// <summary>
/// Intrinsic Methods
/// </summary>
internal static partial class IntrinsicMethods
{
	[IntrinsicMethod("Mosa.Compiler.x64.Intrinsic::SetSegments")]
	private static void SetSegments(Context context, Transform transform)
	{
		var codeSelector = context.Operand1;
		var dataSelector = context.Operand2;

		var ds = transform.PhysicalRegisters.Allocate64(CPURegister.DS);
		var es = transform.PhysicalRegisters.Allocate64(CPURegister.ES);
		var fs = transform.PhysicalRegisters.Allocate64(CPURegister.FS);
		var gs = transform.PhysicalRegisters.Allocate64(CPURegister.GS);
		var ss = transform.PhysicalRegisters.Allocate64(CPURegister.SS);

		// TODO: Does this work?
		var blocks = transform.CreateNewBlockContexts(1, context.Label);

		//var v0 = transform.VirtualRegisters.Allocate64();

		// Creates a "far return", which allows setting the segment registers once in the jumped block
		context.SetInstruction(X64.Push64, null, codeSelector);
		// context.AppendInstruction(X64.Lea64, v0, blocks[0].Block);
		context.AppendInstruction(X64.Push64, null, Operand.CreateConstant64(blocks[0].Block.Label));
		context.AppendInstruction(X64.Retfq);

		blocks[0].AppendInstruction(X64.MovStoreSeg64, ds, dataSelector);
		blocks[0].AppendInstruction(X64.MovStoreSeg64, es, dataSelector);
		blocks[0].AppendInstruction(X64.MovStoreSeg64, fs, dataSelector);
		blocks[0].AppendInstruction(X64.MovStoreSeg64, gs, dataSelector);
		blocks[0].AppendInstruction(X64.MovStoreSeg64, ss, dataSelector);
		blocks[0].AppendInstruction(X64.Ret);
	}
}
