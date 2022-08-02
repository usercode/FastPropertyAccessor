using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FastPropertyAccessor.Tests;

public class TypeAccessorTest
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

        TypeAccessor accessor = TypeAccessor.Get(model.GetType());

        Assert.Equal("John Doe", accessor[model, nameof(Model.Name)]);
        Assert.True((bool)accessor[model, nameof(Model.IsActive)]);
        Assert.Equal(101, accessor[model, nameof(Model.Value)]);
    }

    [Fact]
    public void Set()
    {
        Model model = new Model();
        model.Name = "John Doe";
        model.IsActive = true;
        model.Value = 101;
        model.ValueInt64 = 200;
        model.Date = DateTime.MaxValue;

        TypeAccessor accessor = TypeAccessor.Get(model.GetType());

        accessor[model, nameof(Model.Name)] = "John Doe 2";
        accessor[model, nameof(Model.IsActive)] = false;
        accessor[model, nameof(Model.Value)] = 999;

        Assert.Equal("John Doe 2", model.Name);
        Assert.False(model.IsActive);
        Assert.Equal(999, model.Value);
    }

    [Fact]
    public void EnumerableProperties()
    {
        Model model = new Model();
        model.Name = "John Doe";
        model.IsActive = true;
        model.Value = 101;
        model.ValueInt64 = 200;
        model.Date = DateTime.MaxValue;

        TypeAccessor accessor = TypeAccessor.Get(model.GetType());

        int counter = 0;

        foreach (PropertyAccessor property in accessor)
        {
            counter++;
        }

        Assert.Equal(5, counter);
    }
}
