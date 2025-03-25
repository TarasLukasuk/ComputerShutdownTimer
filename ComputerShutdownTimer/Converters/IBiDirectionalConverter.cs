public interface IBiDirectionalConverter<TSource, TTarget>
{
    TTarget Convert(TSource source);
    TSource ConvertBack(TTarget target);
}