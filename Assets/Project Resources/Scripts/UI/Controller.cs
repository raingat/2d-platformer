public class Controller
{
    private Model _model;

    public Controller(Model model)
    {
        _model = model;
    }

    public void Calculate()
    {
        _model.CalculateCount();
    }
}
