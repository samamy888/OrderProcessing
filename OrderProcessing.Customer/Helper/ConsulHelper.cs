using Consul;

namespace OrderProcessing.Customer.Helper
{
    public static class ConsulHelper
    {
        /// <summary>
        /// 服務註冊到consul
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IConfiguration configuration, IHostApplicationLifetime lifetime)
        {
            var consulClient = new ConsulClient(c =>
            {
                //consul地址
                c.Address = new Uri(configuration["ConsulSetting:ConsulAddress"]);
            });
            var http = $"http://{configuration["ConsulSetting:ServiceIP"]}:{configuration["ConsulSetting:ServicePort"]}{configuration["ConsulSetting:ServiceHealthCheck"]}";//健康檢查地址
            var registration = new AgentServiceRegistration()
            {
                ID = Guid.NewGuid().ToString(),//服務例項唯一標識
                Name = configuration["ConsulSetting:ServiceName"],//服務名
                Address = configuration["ConsulSetting:ServiceIP"], //服務IP
                Port = int.Parse(configuration["ConsulSetting:ServicePort"]),//服務埠 因為要執行多個例項，埠不能在appsettings.json裡配置，在docker容器執行時傳入
                Check = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服務啟動多久後註冊
                    Interval = TimeSpan.FromSeconds(10),//健康檢查時間間隔
                    HTTP = http,
                    Timeout = TimeSpan.FromSeconds(5)//超時時間
                }
            };

            //服務註冊
            consulClient.Agent.ServiceRegister(registration).Wait();

            //應用程式終止時，取消註冊
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }
    }
}
