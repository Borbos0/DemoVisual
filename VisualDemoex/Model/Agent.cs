using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualDemoex
{
    public partial class Agent
    {
        public string LogoView
        {
            get
            {
                if (String.IsNullOrEmpty(Logo) || String.IsNullOrWhiteSpace(Logo))
                {
                    return @"agents\picture.png";
                }
                else
                {
                    return Logo;
                }
            }
        }
    }
}
