# asp-net-core-web-api-token-kullanimi

Bu uygulamada önceki web api uygulamamıza login ve token mekanizmasını eklendi.

Startup dosyası içerisinde jwt optimizasyonunu tanımlandı. Bazı sabit değerlerini ise appsetting dosyasında tanımlayarak kullanıldı.

Ayrıca login işlemi olacağı için Startup dosyası içeriside şifre ayarlaması da tanımlandı. 

AuthController dosyası içerisinde login ve kullanıcı kayıt işlemleri yapıldı. Login işlemi başarılı olduktan sonra token ayarlası yapıldı. 

ViewModel klasörüne login ve register sınıfları eklendi. 

Author1Controller [Authorize] ile yetkilendirilme yapıldı.  
