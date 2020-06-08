namespace RemoteNotes.BLL.Contract.Rule
{
    public interface IValidationRuleFactory
    {
        T Create<T>();
    }
}
