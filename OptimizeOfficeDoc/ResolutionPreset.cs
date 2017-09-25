using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeOfficeDoc
{
    public class ResolutionPreset
    {
        public static List<ResolutionPreset> ComboBoxOptions = new List<ResolutionPreset>();
        public static ResolutionPreset Original;

        public string Name { get; set; }
        public int Width;
        public int Height;

        /// <summary>
        /// Constructor for names that have a WxH resolution as the final string 
        /// </summary>
        /// <param name="Name"></param>
        public ResolutionPreset(string Name)
        {
            this.Name = Name;
            
            // Extract width/height
            string lastPiece = Name.Split(' ').Last();
            if(!lastPiece.Contains("x"))
            {
                throw new Exception(Name + " does not end with a WxH resolution!");
            }

            string[] pieces = lastPiece.Split('x');
            if(!int.TryParse(pieces[0], out Width))
            {
                throw new Exception("Could not parse " + pieces[0] + " as a numeric width!");
            }
            if (!int.TryParse(pieces[1], out Height))
            {
                throw new Exception("Could not parse " + pieces[1] + " as a numeric height!");
            }
        }

        public ResolutionPreset(string Name, int Width, int Height)
        {
            this.Name = Name;
            this.Width = Width;
            this.Height = Height;
            if ((Width == -1) && (Height == -1)) { Original = this; }
        }
    }
}
