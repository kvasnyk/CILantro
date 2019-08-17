.assembly extern mscorlib {}

.assembly HelloWorld {}

.method static public void main() cil managed
{
	.entrypoint
	.maxstack 1
	.locals init ([0] int32 n)
	ldc.i4.7
	stloc.0
	ldloc.0
	call void [mscorlib]System.Console::WriteLine(int32)
	ret
}