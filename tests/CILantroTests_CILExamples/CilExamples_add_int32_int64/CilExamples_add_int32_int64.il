.assembly extern mscorlib {}

.assembly HelloWorld {}

.method static public void main() cil managed
{
	.entrypoint
	.maxstack 2
	ldc.i4.2
	ldc.i8 10
	add
	call void [mscorlib]System.Console::WriteLine(int32)
	ret
}