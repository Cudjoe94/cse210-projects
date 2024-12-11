using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> prompts = new List<string> 
    { 
        "What made you smile today?", 
        "Describe your perfect day.", 
        "What are you grateful for?" 
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }
}
