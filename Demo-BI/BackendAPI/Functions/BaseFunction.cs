using Newtonsoft.Json;

namespace BackendAPI.Functions
{
    public class BaseFunction
    {
        internal T JSONToObject<T>(string json) where T : class
        {
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
    }
}
