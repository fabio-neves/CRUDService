using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FNS.CRUDService.Model
{
    public class ServiceResponse<T>
    {
        private readonly IDictionary<string, List<string>> _messages = new Dictionary<string, List<string>>();

        public IDictionary<string, List<string>> Errors { get; }
        public T Result { get; }

        public ServiceResponse() => Errors = new ReadOnlyDictionary<string, List<string>>(_messages);

        public ServiceResponse(T result) : this() => Result = result;

        public ServiceResponse<T> AddError(string key, string message)
        {
            if (!_messages.ContainsKey(key))
            {
                _messages.Add(key, new List<string>() { message });
            }
            else
            {
                _messages[key].Add(message);
            }

            return this;
        }

        public ServiceResponse<T> AddError(KeyValuePair<string, List<string>> error)
        {
            if (!_messages.ContainsKey(error.Key))
            {
                _messages.Add(error);
            }
            else
            {
                foreach (var message in error.Value)
                {
                    _messages[error.Key].Add(message);
                }
            }

            return this;
        }
    }
}
