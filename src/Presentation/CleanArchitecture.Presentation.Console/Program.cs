namespace CleanArchitecture.Presentation.Console
{
    using CleanArchitecture.Persistance.SqlServer.Entities;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(nameof(Article) + nameof(Article.Id));
        }
    }
}
