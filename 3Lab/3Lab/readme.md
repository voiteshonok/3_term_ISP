## Windows-служба, реализация простенького ETL
При запуске с помощью класса OptionsManager 'вытягиваем' конфигурацию
настроек из файла appsetings.json или config.xml при помощи парсеров JsonParser и XmlParser из папки Parsers, если таких файлов не существует, то используем настройки по умолчанию. 
Вся логика ETL-процесса происходит в классе Tracer.

Настройки, которые мы ищем (можно в файле указать не все):
- ArchiveOptions (сompressionLevel)
- FolderOptions (key)
- EncryptOptions (SourceFolder и TargetFolder)

`JsonParser` и `XmlParser` - универсальные парсеры, реализуют интерфейс `IParser` c методом *Parse(string text)*, *GetValue(string text, string value)* - статический метод, который возвращает значение конкретного тега.
