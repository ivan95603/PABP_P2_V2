using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PABP_2_V3.Models
{
    public class CustomRegionEmployees
    {
        string territoryDescription;
        
        List<Territories> territoriesInCurrentRegion;

        public string TerritoryDescription
        {
            get
            {
                return territoryDescription;
            }

            set
            {
                territoryDescription = value;
            }
        }

        public List<Territories> TerritoriesInCurrentRegion
        {
            get
            {
                return territoriesInCurrentRegion;
            }
        }

        // TODO MethodNoOfEmployeesInInternalTerritories

        public CustomRegionEmployees(string territoryDescription, List<Territories> territoriesInCurrentRegion)
        {
            this.territoryDescription = territoryDescription;
            this.territoriesInCurrentRegion = territoriesInCurrentRegion;
        }

        public int NumberOfEmployeesInRegion()
        {
            int count = 0;
            foreach (var item in this.territoriesInCurrentRegion)
            {
                count += item.Employees.Count;
            }
            return count;
        }
    }
}