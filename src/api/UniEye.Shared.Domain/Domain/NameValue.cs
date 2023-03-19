namespace UniEye.Shared.Domain.Domain
{
    public class NameValue: IIdentifiable
    {
        public int Id { get; set; }
        public string Value { get; set; }


        public NameValue(int id, string value)
        {
            Id = id;
            Value = value;
        }

    }
}
