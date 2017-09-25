using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeOfficeDoc
{
    public class FormatPreset
    {
        public static List<FormatPreset> ComboBoxOptions = new List<FormatPreset>();
        public static FormatPreset Original;

        public string Name { get; set; }
        public string FormatName;
        public long QualityLevel;
        public long ColorDepth;

        public FormatPreset(string Name, string FormatName, long? QualityLevel, long? ColorDepth)
        {
            if(FormatName == "SRC") { Original = this; }
            this.Name = Name;
            this.FormatName = FormatName;
            this.QualityLevel = (QualityLevel == null ? -1 : (long)QualityLevel);
            this.ColorDepth = (ColorDepth == null ? -1 : (long)ColorDepth);
        }
    }
}
