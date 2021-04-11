using Volo.Abp.DependencyInjection;

 namespace AbpVnextPro.GUI
{
    public class HelloWorldService : ITransientDependency
    {
        public string SayHello()
        {
            return "Hello world!";
        }
    }
}
