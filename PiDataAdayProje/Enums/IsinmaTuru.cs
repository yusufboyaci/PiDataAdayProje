using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PiDataAdayProje.Enums
{
    public enum IsinmaTuru
    {
        [Display(Name = "Dogalgazlı Merkezi Isıtıcılar")]
        DogalgazliMerkeziIsiticilar,
        [Display(Name = "Elektrikli Merkezi Isıtıcılar")]
        ElektrikMerkeziIsiticilar,
        [Display(Name = "Sıvı Yakıtlı Merkezi Isıtıcılar")]
        SiviYakitliMerkeziIsitmaSistemleri,
        [Display(Name = "LPG li Merkezi Isıtma Sistemleri")]
        LPGliMerkeziIsiticilar,
        [Display(Name = "Odunlu Merkezi Isıtma Sistemleri")]
        OdunluIsitmaSistemleri,
        [Display(Name = "Kömürlü Merkezi Isıtma Sistemleri")]
        KomurluIsitmaSistemleri,
        [Display(Name = "Günes Enerjisi")]
        GunesEnerjisi,
        [Display(Name = "Termosifon ile Su Isıtma Sistemleri")]
        TermosifonileSuIsitma
    }
}
