using System.ComponentModel.DataAnnotations;

namespace websoft_react.ModelView
{
    public class DokladyPodpisyView
    {
        public long DruhDokladu { get; set; }
        [Display(Name = "Číslo dokladu")]
        public long CisloDokladu { get; set; }
        [Display(Name = "Rok")]
        public short Rok { get; set; }
        [Display(Name = "Popis")]
        public string Popis { get; set; }
    }    
}