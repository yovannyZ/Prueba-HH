namespace BLL
{
    public abstract class BizObject
    {
        protected static string ConvertNullToEmptyString(string input)
        {
            return (input == null ? "" : input);
        }
    }
}
