namespace Assignment1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();
            builder.Services.AddCors();//gioi han phan quyen cho api
            //add end
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            app.MapControllers();
            //add end
            //    app.MapGet("/", () => "Hello World!");



            app.Run();
        }
    }
}