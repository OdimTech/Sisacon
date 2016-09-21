namespace Sisacon.Domain
{
    public class ValueObjects
    {
        public enum eErrorGravity : short { Pequena = 1, Media = 2, Grande = 3, Travamento = 4 };
        public enum eUserType : short { Admin = 1, User = 2 };
        public enum eOperationType : short { Insert = 1, Update = 2, Select = 3, Delete = 4 };
        public enum ePersonType : short { Fisica = 1, Juridica = 2};
        public enum eFormatImg : short { Circular = 1, Quadrado = 2 };
    }
}
