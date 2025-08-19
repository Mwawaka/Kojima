public enum AccountType
{
    Guest,
    User,
    Moderator
}

// uses binary
[Flags]
public enum Permission
{
    None = 0, //0000
    Read = 1, //0001
    Write = 2, //0010
    Delete = 4, //0100
    All = Read | Write | Delete //0111
}

static class Permissions
{
    public static Permission Default(AccountType accountType) => accountType switch
    {
        AccountType.Guest => Permission.Read,
        AccountType.User => Permission.Read | Permission.Write,
        AccountType.Moderator => Permission.All,
        _ => Permission.None
    };
    public static Permission Grant(Permission current, Permission grant) => current | grant;
    public static Permission Revoke(Permission current, Permission revoke) => current = current & ~revoke ;
    public static bool Check(Permission current, Permission check) => (current & check) == check;
}
