.assembly extern mscorlib {}

.assembly HelloWorld {}

.method static public void main() cil managed
{
	.entrypoint
	.maxstack 2
	br 1
	ldc.i4.1
	ldc.i4.2
	call void [mscorlib]System.Console::WriteLine(int32)
	ret
}