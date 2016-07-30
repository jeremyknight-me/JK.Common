namespace DL.Core.Data
{
    public interface IScalarOperation<out T> where T : struct
    {
        T Execute();
    }
}