using System;

namespace Sisacon.Domain.Entities
{
    public class Configuration : BaseEntity
    {
        #region Propeties

        public string DefaultPage { get; set; }
        public bool CodAutoClient { get; set; }
        public bool CodAutoProvider { get; set; }
        public bool CodAutoMaterial { get; set; }
        public bool CodAutoProduct { get; set; }
        public bool CodAutoEstimate { get; set; }
        public bool CodAutoRequest { get; set; }
        public bool CodAutoEquipment { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods

        public Configuration createDefaultConfig(User user)
        {
            var config = new Configuration();

            try
            {
                config.DefaultPage = "#/initialDashBoard";
                config.CodAutoClient = true;
                config.CodAutoProvider = true;
                config.CodAutoMaterial = true;
                config.CodAutoProduct = true;
                config.CodAutoEstimate = true;
                config.CodAutoRequest = true;
                config.CodAutoEquipment = true;
                config.User = user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return config;
        }

        #endregion
    }
}
