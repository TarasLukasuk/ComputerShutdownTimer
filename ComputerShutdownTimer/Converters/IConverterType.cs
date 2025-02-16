public interface IConverterType<TInput, TOutput>
{
    TOutput Convert(TInput value);
    TInput ConvertBack(TOutput value);
}
