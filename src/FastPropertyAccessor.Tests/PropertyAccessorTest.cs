using Xunit;

namespace FastPropertyAccessor.Tests;

public class PropertyAccessorTest
{
    [Fact]
    public void Get()
    {
        Model model = new Model();
        model.Name = "John Doe";
        model.IsActive = true;
        model.Value = 101;
        model.ValueInt64 = 200;
        model.Date = DateTime.MaxValue;

        var name = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.Name)));
        var active = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.IsActive)));
        var value = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.Value)));
        var valueInt64 = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.ValueInt64)));
        var date = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.Date)));

        Assert.Equal("John Doe", name.GetValue(model));
        Assert.True((bool)active.GetValue(model));
        Assert.True(active.GetBoolValue(model));
        Assert.Equal(101, value.GetInt32Value(model));
        Assert.Equal(200, valueInt64.GetInt64Value(model));
        Assert.Equal(DateTime.MaxValue, date.GetDateTimeValue(model));
    }

    [Fact]
    public void Set()
    {
        Model model = new Model();

        var name = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.Name)));
        var active = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.IsActive)));
        var value = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.Value)));
        var valueInt64 = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.ValueInt64)));
        var date = PropertyAccessor.Get(model.GetType().GetProperty(nameof(Model.Date)));

        name.SetValue(model, "John Doe");
        active.SetBoolValue(model, true);
        value.SetInt32Value(model, 101);
        valueInt64.SetInt64Value(model, 200);
        date.SetDateTimeValue(model, DateTime.MaxValue);

        Assert.Equal("John Doe", model.Name);
        Assert.True(model.IsActive);
        Assert.Equal(101, model.Value);
        Assert.Equal(200, model.ValueInt64);
        Assert.Equal(DateTime.MaxValue, model.Date);
    }
}