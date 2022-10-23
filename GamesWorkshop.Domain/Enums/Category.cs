using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesWorkshop.Domain.Enum
{
    public enum Category
    {
        [Display(Name = "Space Marines")]
        SpaceMarines = 0,

        [Display(Name = "Armies Of The Imperium")]
        ArmiesOfTheImperium = 1,

        [Display(Name = "Armies Of Chaos")]
        ArmiesOfChaos = 2,

        [Display(Name = "Xenos Armies")]
        XenosArmies = 3,

        [Display(Name = "Terrain")]
        Terrain = 4,

        [Display(Name = "Ways To Play")]
        WaysToPlay = 5,
    }
}
