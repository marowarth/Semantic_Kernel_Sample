using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.KernelExtensions;
using Microsoft.SemanticKernel.Orchestration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semantic_Kernel_Sample
{
    internal class SemanticConnection
    {
        public IKernel login()
        {

            var kernel = Kernel.Builder.Build();

            // For Azure Open AI service endpoint and keys please see
            // https://learn.microsoft.com/azure/cognitive-services/openai/quickstart?pivots=rest-api
            kernel.Config.AddOpenAICompletionBackend(
                "GPT",  //nombre
                "text-davinci-003",  // modelo
                "sk-..." //APikey
                );

            return kernel;
        }
        public SKContext question(string text, IKernel kernel)
        {

            string skPrompt = text;

            string textToSummarize = @"";

            var tldrFunction = kernel.CreateSemanticFunction(skPrompt);

            var summary = kernel.RunAsync(textToSummarize, tldrFunction).Result;

            return summary;
        }
    }
}
