# FastPropertyAccessor
Fast property accessor without using reflection

## Sample

```csharp
Model model = new Model();
model.Amount = 100;

//name property info
PropertyInfo pi = model.GetType().GetProperty(nameof(Model.Amount));

//name property accessor
PropertyAccessor accessor = PropertyAccessor.Get(pi);

//get value
int amount = (int)accessor.GetValue(model);

//set value
accessor.SetValue(model, 200);

//prevent boxing/unboxing for primitive types
int amount2 = accessor.GetInt32Value(model);

accessor.SetInt32Value(model, 200);
```
