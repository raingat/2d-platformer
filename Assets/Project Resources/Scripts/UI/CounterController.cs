public class CounterController
{
    private CounterModel _model;

    public CounterController(CounterModel model)
    {
        _model = model;
    }

    public void Calculate()
    {
        _model.CalculateCount();
    }
}
