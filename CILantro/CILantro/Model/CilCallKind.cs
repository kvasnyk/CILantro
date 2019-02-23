namespace CILantro.Model
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