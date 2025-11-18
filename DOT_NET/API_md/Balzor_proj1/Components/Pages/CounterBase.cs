using Microsoft.AspNetCore.Components;

namespace Balzor_proj1.Components.Pages
{
    public class CounterBase:ComponentBase

    {
        public int currentCount = 0;

        public void IncrementCount()
        {
            currentCount++;
        }


    }
}
