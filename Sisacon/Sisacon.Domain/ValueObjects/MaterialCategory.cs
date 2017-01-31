using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.ValueObjects
{
    public class MaterialCategory : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_DESC = 50;

        #endregion

        #region Properties

        public string Description { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods

        public bool validateBeforeDelete()
        {
            var isValid = true;



            return isValid;
        }

        #endregion

    }
}
