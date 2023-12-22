using Newtonsoft.Json;

namespace ProjectWebAPI.ExtensionClasses
{
    public static  class SessionExtension
    {
        public static void SetObject(this ISession session,string key,object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key,objectString);
        }

        public static T GetObject<T>(this ISession session,string key) where T: class
        {
            string objectString =session.GetString(key);
            if(string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            T deserializedObect = JsonConvert.DeserializeObject<T>(objectString);
            return deserializedObect;
        }
    }
}
