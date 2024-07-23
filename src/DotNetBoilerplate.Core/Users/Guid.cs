//using DotNetBoilerplate.Core.CommonExceptions;

//namespace DotNetBoilerplate.Core.Users;

//public sealed record UserId
//{
//    public UserId(System.Guid value)
//    {
//        if (value == System.Guid.Empty) throw new InvalidEntityIdException(value);

//        Value = value;
//    }

//    public System.Guid Value { get; }

//    public static implicit operator Guid(Guid value)
//    {
//        return value.Value;
//    }

//    public static implicit operator Guid(string value)
//    {
//        return new Guid(System.Guid.Parse(value));
//    }

//    public static implicit operator Guid(System.Guid value)
//    {
//        return new Guid(value);
//    }

//    public static bool operator ==(Guid userId, System.Guid guid)
//    {
//        return userId!.Value == guid;
//    }

//    public static bool operator !=(Guid userId, System.Guid guid)
//    {
//        return !(userId == guid);
//    }
//}