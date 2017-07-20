namespace DL.Common.Data.Contracts
{
    public interface IScalarOperation<out T> where T : struct
    {
        T Execute();
    }
}