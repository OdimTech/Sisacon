using Sisacon.Domain.ValueObjects;
using System.Collections.Generic;

namespace Sisacon.Domain.Entities
{
    public class Cost : BaseEntity
    {
        #region Propeties

        public string ReferenceMonthText { get; set; }
        public int WorkedHours { get; set; }
        public decimal Salary { get; set; }
        public decimal TotalFixedCost { get; set; }
        public decimal TotalDevaluationOfEquipment { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CostPerHour { get; set; }
        public bool Closed { get; set; }
        public bool Current { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<FixedCost> ListFixedCost { get; set; }

        #endregion

        #region Methods

        public bool isValid()
        {
            var isValid = true;



            return isValid;
        }

        /// <summary>
        /// Valida se um Custo pode ser removido.
        /// </summary>
        /// <returns></returns>
        public bool validateBeforeDelete()
        {
            var isValid = true;

            //SÓ É POSSIVEL DELETEAR O CUSTO DO MES ATUAL, DURANTE O PERIODO EM QUE ELE ESTEJA VIGENTE, APÓS ESSE PERIODO, NÃO PODERÁ MAIS SER REMOVIDO, POR QUESTOES DE MANUTENÇÃO DE HISTORICO
            if(!Current)
            {
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Calcula o total dos gastos fixos.
        /// </summary>
        public void calcCosts()
        {
            TotalCost = Salary + TotalDevaluationOfEquipment;

            foreach (var item in ListFixedCost)
            {
                TotalCost += item.Value;
            }

            if(WorkedHours > 0)
            {
                CostPerHour = TotalCost / WorkedHours;
            }
        }

        #endregion
    }
}
