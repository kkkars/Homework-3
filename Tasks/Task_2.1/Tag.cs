namespace Task_2._1
{
    public class Tag
    {
        public string ProductId { get; private set; }
        public string Value { get; private set; }
        public Tag(string productId, string value)
        {
            ProductId = productId;
            Value = value;
        }
    }
}
