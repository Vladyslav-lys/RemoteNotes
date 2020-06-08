using RemoteNotes.BLL.Contract.Rule;
using RemoteNotes.BLL.Rules.Validation.Operation;
using System;
using System.Collections.Generic;

namespace RemoteNotes.BLL.Rules
{
    public class ValidationRuleFactory : IValidationRuleFactory
    {
        readonly Dictionary<Type, object> ruleCollection = new Dictionary<Type, object>();

        public ValidationRuleFactory()
        {
            // Extension point of the factory
            this.ruleCollection.Add(typeof(IEnterOperationValidationRule), new EnterOperationValidationRule());
            this.ruleCollection.Add(typeof(IUpdateUserOperationValidationRule), new UpdateUserOperationValidationRule());
            this.ruleCollection.Add(typeof(IEditNoteOperationValidationRule), new EditNoteOperationValidationRule());
            this.ruleCollection.Add(typeof(IAfterLoginOperationValidationRule), new AfterLoginOperationValidationRule());
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            if (!this.ruleCollection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing in the rule collection");
            }

            return (T)this.ruleCollection[type];
        }
    }
}
