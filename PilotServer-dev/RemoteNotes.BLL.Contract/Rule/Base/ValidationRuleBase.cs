namespace RemoteNotes.BLL.Contract.Rule.Base
{
    public abstract class ValidationRuleBase
    {
        protected string ruleDescription;

        public ValidationRuleBase(string ruleDescription)
        {
            this.ruleDescription = ruleDescription;
        }

        protected virtual string GetErrorMessage()
        {
            return ruleDescription;
        }
    }
}