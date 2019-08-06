.assembly extern mscorlib {}

.assembly HelloWorld {}

.method static public void main() cil managed
{
	.entrypoint
	.maxstack 1
	ldc.i4.1
	call void [mscorlib]System.Console::WriteLine(int32)
	ret
}