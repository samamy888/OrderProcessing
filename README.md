# OrderProcessing
實現 api gateway

參考網址 : 
* [使用 Ocelot 在 ASP.NET Core 中實現 API 網關](https://auth0.com/blog/implementing-api-gateway-in-aspnet-core-with-ocelot/#The-Order-Processing-Microservices-Based-Application) 
* [春光牛牛教學文章](https://www.cnblogs.com/yakniu/category/2144564.html)

官方文檔 : [Welcome to Ocelot](https://ocelot.readthedocs.io/en/latest/)

## Consul

參考網址 : [.Net Core微服務入門全紀錄（二）——Consul-服務註冊與發現（上）](https://iter01.com/511114.html)

**使用方法** : 

* 下載 **consul** : https://www.consul.io/downloads
* 到文件目錄開啟 cmd 輸入程式碼

    ``` bash
    consul.exe agent -dev
    ```
* 瀏覽器訪問 http://localhost:8500/


## Ocelot + Consul (健康檢測)

參考網址 : [Asp-Net Core Ocelot Consul 微服務](https://www.readfog.com/a/1631827871820517376)

## Ocelot + Polly (熔斷)

參考網址 : [Ocelot之基于Polly熔断](https://www.cnblogs.com/yakniu/p/16113231.html)


