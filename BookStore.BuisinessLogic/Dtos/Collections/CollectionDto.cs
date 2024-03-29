using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Dtos.Collections
{
    public class CollectionDto
    {
        public string Name { get; set; } 
        public string Tags { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Boolean Custom_Int1_State { get; set; } = false;
        public int Custom_Int1_Name { get; set; }
        public Boolean Custom_Int2_State { get; set; } = false;
        public int Custom_Int2_Name { get; set; }
        public Boolean Custom_Int3_State { get; set; } = false;
        public int Custom_Int3_Name { get; set; }
        public Boolean Custom_String1_State { get; set; } = false;
        public string Custom_String1_Name { get; set; } = string.Empty;
        public Boolean Custom_Sting2_State { get; set; } = false;
        public string Custom_Sting2_Name { get; set; } = string.Empty;
        public Boolean Custom_String3_State { get; set; } = false;
        public string Custom_String3_Name { get; set; } = string.Empty;

        public Boolean Custom_MultilineTextField1_State { get; set; } = false;
        public string Custom_MultilineTextField1_Name { get; set; } = string.Empty;
        public Boolean Custom_MultilineTextField2_State { get; set; } = false;
        public string Custom_MultilineTextField2_Name { get; set; } = string.Empty;
        public Boolean Custom_MultilineTextField3_State { get; set; } = false;
        public string Custom_MultilineTextField3_Name { get; set; } = string.Empty;
        public Boolean Custom_BooleanCheckbox1_State { get; set; } = false;
        public Boolean Custom_BooleanCheckbox1Name { get; set; } = false;
        public Boolean Custom_BooleanCheckbox2State { get; set; } = false;
        public Boolean Custom_BooleanCheckbox2Name { get; set; } = false;
        public Boolean Custom_BooleanCheckbox3State { get; set; } = false;
        public Boolean Custom_BooleanCheckbox3Name { get; set; } = false;
        public Boolean Custom_Datetime1_State { get; set; } = false;
        public DateTime Custom_Datetime1_Name { get; set; }
        public Boolean Custom_Datetime2_State { get; set; } = false;
        public DateTime Custom_Datetime2_Name { get; set; }
        public Boolean Custom_Datetime3_State { get; set; } = false;
        public DateTime Custom_Datetime3_Name { get; set; }
    }
}
