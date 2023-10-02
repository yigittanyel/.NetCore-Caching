# .Net Core Üzerinde Caching Yapısının İncelenmesi

### Caching nedir?
- .NET Core'da caching(önbellekleme), uygulamanın çalışma süresi boyunca geçici verileri bellekte saklayarak hızlı erişim sağlayan bir tekniktir. Bu, performansı artırmanın ve maliyetli işlemleri azaltmanın etkili bir yoludur.
- .NET Core üzerinde caching için kullanılabilecek cacheleme yöntemleri şu şekildedir:
* In Memory Caching
* Distributed Caching
* Response Caching
* Output Cachinng

 ![image](https://github.com/yigittanyel/.NetCore-Caching/assets/61347219/b2cadbdb-0753-4077-af16-cf0f9806a166)


### In Memory Caching
- In-memory cache, bir uygulamanın çalışma süresi boyunca geçici verileri hızlı bir şekilde saklamak için kullanılan bir mekanizmadır. Bu tür bir önbellek, verileri bellekte tutarak, tekrar tekrar erişilmesi gereken verilere hızlı erişim sağlar.
- Uygulamaya ait dataların , uygulamayı barındıran sunucunun ram kısmına kaydedilme işlemine denir. İlgili datalara daha hızlı erişmek için bilgiler RAM'de tutulur.

### Distributed Caching

- Distributed Caching, bir uygulamanın farklı sunucular veya servisler arasında paylaşılan bir önbellek kullanarak verileri depolaması ve paylaşmasına olanak tanır. Bu, uygulama ölçeklenebilirliğini artırarak performansı iyileştirir.
- .NET'te bu amaca yönelik olarak yaygın olarak kullanılan araçlardan biri Redis adlı açık kaynaklı bir veri yapısıdır. Redis, hafızada veri depolamanın yanı sıra bu verileri disk üzerinde de saklama yeteneğine sahip bir veri yapısıdır. Bu, sıkça erişilen verilerin hızlı bir şekilde paylaşılmasını sağlar.

![image](https://github.com/yigittanyel/.NetCore-Caching/assets/61347219/1af7ab30-d931-4b16-a970-8b08ea6043bb)


### Response Caching

-  Response Caching, bir web sunucusunun yanıtlarını (responses) önbellekte tutarak, aynı talepler için tekrar tekrar aynı içeriği oluşturmasını önleyen bir mekanizmadır.
-  Response Caching, tekrarlayan istemciler için önemli bir performans artışı sağlar. Özellikle dinamik olmayan içerikler (örneğin, blog sayfaları veya ürün bilgileri) için uygundur.

### Output Caching

-  .NET'te Output Caching, bir web sayfasının içeriğini üretip gönderdikten sonra, bu içeriğin belirli bir süre boyunca önbellekte (cache) tutulması işlemidir.
-  Output Caching, dinamik olmayan içeriklerin (örneğin, bir haber makalesi veya ürün bilgisi) hızlı bir şekilde sunulmasını sağlar. Bu, veritabanı sorguları veya hesaplamalar gibi maliyetli işlemleri tekrar tekrar yapmaktansa, sonuçları önbellekte saklayarak performansı artırır.

> **_NOT:_**  Output Cache server-side(sunucu tarafında), response cache ise client-side(istemci tarafında) çalışır.<hr>
> **_ÖZETLE:_**  Output Cache sunucu tarafında çalışır ve belirli bir action veya sayfanın sonuçlarını önbelleğe alırken, Response Cache istemci tarafında çalışır ve tarayıcı seviyesinde istek sonuçlarını önbelleğe alır. Hangisinin kullanılacağı, kullanım senaryonu ve ihtiyaçlara bağlı olarak belirlenir.

### ÖZET

#### In-Memory Cache

##### Artıları:
- Hızlı erişim: Veriler doğrudan bellekte saklanır, bu nedenle çok hızlı erişim sağlar.
- Basit yapı: .NET Core içinde doğrudan kullanılabilen basit bir önbellek mekanizmasıdır.
- Esneklik: Verilerin boyutu ve süresi gibi parametreler kolayca ayarlanabilir.
##### Eksileri:
- Tek sunucu sınırlaması: Yalnızca bir sunucuda çalışır, bu nedenle çoklu sunucu - ortamlarında paylaşılan veri saklama kapasitesi yoktur.
- Bellek tüketimi: Veriler bellekte saklanır, bu nedenle büyük miktarda verinin önbelleğe alınması performansı etkileyebilir.

#### Distributed Cache

##### Artıları:
- Ölçeklenebilirlik: Birden fazla sunucu arasında veri paylaşımını destekler.
- Yüksek performans: Veri hızlı erişim için bellekte tutulur.
- Güvenilirlik: Birden fazla sunucu arasında veri çoğaltılabilir.
##### Eksileri:
- Ek konfigürasyon: Redis veya diğer dağıtılmış önbellek sistemlerinin yapılandırılması gerekebilir.
- Karmaşıklık: Dağıtık önbellek sistemleri, in-memory cache'e göre daha karmaşık olabilir.
#### Response Cache

##### Artıları:
- Tarayıcıda önbellek: Yanıtlar istemci tarayıcısında saklanır, bu nedenle tekrarlayan istekler hızla yanıtlanır.
- Kontrol seçenekleri: HTTP başlıkları ile önbellek davranışını ayarlamak mümkündür.
- Evrensellik: Tüm istemci türleri tarafından desteklenir.
##### Eksileri:
- Yalnızca GET isteklerini destekler.
- Dinamik içerik için uygun değildir.
#### Output Cache

##### Artıları:
- Hızlı yanıt: Sayfa içeriği önbellekte saklanır, bu nedenle tekrar eden istemciler için hızlı yanıt sağlar.
- Ayarlanabilir süre: Süre belirleyerek ne kadar süreyle önbellekte saklanacağını kontrol edebilirsiniz.
- Evrensellik: Tüm istemci türleri tarafından desteklenir.
##### Eksileri:
- Dinamik içerik için uygun değildir.
##### Ek bilgiler:

- Ön bellekleme (Caching), bir uygulamanın performansını ve ölçeklenebilirliğini iyileştirmenin etkili bir yoludur. Önbelleğe alınan veriler, uygulamanın bir veritabanı veya web servisi gibi başka bir kaynaktan verileri yeniden almaktan tasarruf etmesini sağlar.
- .NET Core, çeşitli önbellek türleri sunar. Bu türlerden her biri, farklı gereksinimleri karşılamak için tasarlanmıştır.
Uygulamanız için doğru önbellek türünü seçmek, performansı ve ölçeklenebilirliği en üst düzeye çıkarmanıza yardımcı olacaktır.


### Kaynakça
- [Overview of caching in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/overview?view=aspnetcore-7.0#in-memory-caching)
- [How To Implement Caching In The .NET Core Web API Application](https://www.c-sharpcorner.com/article/how-to-implement-caching-in-the-net-core-web-api-application/)
- [DistributedCacheAspNetCoreRedis Repo](https://github.com/sahansera/DistributedCacheAspNetCoreRedis)


### Teşekkürler
Okuduğunuz için teşekkürler. Bana bu konuyla ya da farklı konularda ulaşmak isterseniz: <br>
- [LinkedIn - Yiğit Tanyel](https://www.linkedin.com/in/yigittanyel/)
- [GitHub - Yiğit Tanyel](https://github.com/yigittanyel)
