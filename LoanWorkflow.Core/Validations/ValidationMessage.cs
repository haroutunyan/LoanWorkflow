using Newtonsoft.Json;

namespace LoanWorkflow.Core.Validations
{
    public class ValidationMessage
    {
        public static ValidationMessage For(string key) => new() { Name = key };
        public string Name { get; set; }
        public Dictionary<string, string> Params { get; set; } = [];
        private ValidationMessage WithParams(string k, string v)
        {
            Params.Add(k, v);
            return this;
        }
        public ValidationMessage WithParam(string paramName)
        {
            return WithParams(paramName, string.Concat("{", paramName, "}"));
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
