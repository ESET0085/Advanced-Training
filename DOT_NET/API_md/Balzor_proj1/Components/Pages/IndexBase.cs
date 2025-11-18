using Microsoft.AspNetCore.Components;


namespace Balzor_proj1.Components.Pages
{
    public class IndexBase : ComponentBase
    {
        public string Text { get; set; } = "Click Me";

        public string ChangeColor { get; set; } = null;

        public string Name { get; set; } = "Rohan";
        protected void ChangeText()
        {
            if (Text == "Click Me")
            {
                Text = "You Clicked Me!";
                ChangeColor = "btncolorchange";
            }
            else
            {
             Text = "Click Me";
                ChangeColor = "";
            }
        }

    }

}