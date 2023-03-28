using GH_IO.Serialization;
using Grasshopper.Kernel.Types;

namespace Devs_GH_Pipeline;

public class GH_DevsType : GH_Goo<int>
{
    private readonly bool _isValid;
    internal GH_DevsType(int value)
    {
        Value = value;
        _isValid = true;
    }

    public GH_DevsType()
    {
        Value = -1;
        _isValid = false;
    }

    public override IGH_Goo Duplicate()
    {
        // Deep copy if that is what you want
        return new GH_DevsType(Value);
    }

    public override string TypeName => "Devs Data";
    public override string TypeDescription => "Custom Devs data description.";
    public override string ToString() => $"Devs value #{Value}.";
    public override bool IsValid => _isValid;
    public override string IsValidWhyNot => "Not initialized";

    // Not implemented / applicable GH requirements
    public override bool Write(GH_IWriter writer)
    {
        // TODO: implement serialization if possible
        return false;
    }
    public override bool Read(GH_IReader reader)
    {
        // TODO: implement deserialization if possible
        return false;
    }

    public override bool CastFrom(object inputData) => false;
    public override object ScriptVariable() => this;
    public override IGH_GooProxy? EmitProxy() => null;

}
