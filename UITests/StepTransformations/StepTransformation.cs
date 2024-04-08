namespace ToptalAutomationTask.StepTransformations
{
    [Binding]
    public class StepTransformation
    {
        [StepArgumentTransformation(@"(\d+)(?:st|nd|rd|th)")]
        public int GetIndex(int index)
        {
            return index;
        }
    }
}
