namespace CILantro.ProgramStructure
{
    public enum CilCallKind
    {
        None,
        Default,
        VarArg,
        UnmanagedCdecl,
        UnmanagedStdCall,
        UnmanagedThisCall,
        UnmanagedFastCall
    }
}