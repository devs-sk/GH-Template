using System;
using System.Collections.Generic;
using System.Drawing;

using Grasshopper.Kernel;

namespace Devs_GH_Pipeline;

class DevsCustomParameter : GH_PersistentParam<GH_DevsType>
{
    public DevsCustomParameter() : base("Full Name",
                                        "Short Name",
                                        "Long describing sentence.",
                                        "Tab Name",
                                        "Group Name")
    { }

    // For enabling a floating parameter set to anything else
    public override GH_Exposure Exposure => GH_Exposure.hidden;
    protected override Bitmap Icon => Properties.ShipIcon;
    // Change for every new parameter
    public override Guid ComponentGuid => new Guid("d14c9b0a-6c5d-4f90-880c-f4de7d0a1d70");

    protected override GH_GetterResult Prompt_Plural(ref List<GH_DevsType> values)
    {
        values = new List<GH_DevsType>();
        return GH_GetterResult.cancel;
    }

    protected override GH_GetterResult Prompt_Singular(ref GH_DevsType value)
    {
        value = new GH_DevsType();
        return GH_GetterResult.cancel;
    }
}
