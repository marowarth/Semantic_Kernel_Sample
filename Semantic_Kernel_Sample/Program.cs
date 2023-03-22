// See https://aka.ms/new-console-template for more information
using Semantic_Kernel_Sample;
using Microsoft.SemanticKernel;

Console.WriteLine("Hola!!!");
Console.WriteLine("cual es tu pregunta?");
SemanticConnection gpt = new SemanticConnection();
IKernel kernel = gpt.login();

while (true)
{
    String texto;
    texto = Console.ReadLine();
    var answer = gpt.question(texto, kernel);
    Console.WriteLine(answer);
    kernel = gpt.login();
}