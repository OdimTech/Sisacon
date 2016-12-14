namespace Sisacon.Domain.ValueObjects
{
    public class Email
    {
        #region Constants

        public const int EMAIL_MAX_LENGTH = 254;

        #endregion

        #region Propeties

        public string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                if(isValid(value))
                {
                    _address = value;
                }
            }
        }

        #endregion

        #region Methods

        public bool isValid(string address)
        {
            if (address.Length <= EMAIL_MAX_LENGTH)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
