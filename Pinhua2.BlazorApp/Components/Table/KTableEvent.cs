namespace Klazor
{
    public class KTableEvent<TItem>
    {
        public KTable<TItem> Target { get; set; }
        public TItem Row { get; set; }
    }
}