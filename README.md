# DotnetMvc
C# .NET MVC ile Codefirst kullanilarak, Entity framework CRUD islemleri icin ornek bir web application projesidir.

Eğer northwind db create edilmemişse, asagidaki gibi cmd prompta local db instance i create edilerek connect olunur;
1) "sqllocaldb" komutunu yaz
2) "sqllocaldb i" komutu ile yeni local db instance ini create et. 
3) Visual studio connect mssql db wizard servername: (LocalDB)\MSSQLLocalDB (VS server explorer dan local db ye connect ol.)
4) Daha sonra "instnwnd.sql" dosyasını Visual studio SQL window da run ederek, northwind db yi create et.

Artık solution u localinizde çalıştırabilirsiniz.

Not : Eger roslyn veya csc.exe not found gibi bir hata alirsaniz, Package Manager Console da asagidaki komutu calistirip, rebuild edip bi daha deneyiniz;

"update-package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r"

added build-action.yml
