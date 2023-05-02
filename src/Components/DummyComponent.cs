using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;

namespace Devs_GH_Pipeline;

public class DumyComponent : GH_Component
{

    public DumyComponent() : base("Full Name",
                                  "Short Name",
                                  "Long describing sentence.",
                                  "Tab Name",
                                  "Group Name")
    {
        Message = Config.VersionHint;
    }

    public override GH_Exposure Exposure => GH_Exposure.primary;
    protected override Bitmap Icon => Properties.ShipIcon;
    // Change for every new component
    public override Guid ComponentGuid => new Guid("57bc3ae8-c795-4a42-8844-52ae1ce22ae2");

    private const int IN_PARAM_COUNT = 0;
    private const int IN_PARAM_CUSTOM = 1;
    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddIntegerParameter("Full Name",
                                     "Short Name",
                                     "Long describing sentence.",
                                     GH_ParamAccess.item);
        pManager.AddParameter(new DevsCustomParameter(),
                              "Full Name",
                              "Short Name",
                              "Long describing sentence.",
                              GH_ParamAccess.list);
    }

    private const int OUT_PARAM_SIZE = 0;
    private const int OUT_PARAM_CUSTOM = 1;
    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddNumberParameter("Full Name",
                                    "Short Name",
                                    "Long describing sentence.",
                                    GH_ParamAccess.item);
        pManager.AddParameter(new DevsCustomParameter(),
                              "Full Name",
                              "Short Name",
                              "Long describing sentence.",
                              GH_ParamAccess.tree);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        int wholeNumber = default;
        DA.GetData(IN_PARAM_COUNT, ref wholeNumber);

        List<GH_DevsType?> list = new();
        DA.GetDataList(IN_PARAM_COUNT, list);
        if (list.Any(p => p is null))
        {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Some data or the data list is null.");
            return;
        }

        double floatingPointNumber = 2 * Math.PI * wholeNumber;
        DA.SetData(OUT_PARAM_SIZE, floatingPointNumber);

        var tree = new GH_Structure<GH_DevsType>();
        tree.AppendRange(list!, new GH_Path(0));
        tree.Graft(GH_GraftMode.GraftAll);
        DA.SetDataTree(OUT_PARAM_CUSTOM, tree);

    }
}
