.assembly extern mscorlib {}

.assembly HelloWorld {}

.class private auto ansi beforefieldinit Test.Program
       extends [mscorlib]System.Object
{
	.method public hidebysig static int32 Compute() cil managed
	{
		.maxstack 1
		ldc.i4.3
		ret
	}

	.method static public void main() cil managed
	{
		.entrypoint
		.maxstack 1
		call int32 Test.Program::Compute()
		call void [mscorlib]System.Console::WriteLine(int32)
		ret
	}
}