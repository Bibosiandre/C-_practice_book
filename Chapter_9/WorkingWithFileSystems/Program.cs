using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

OutputFileSystemInfo();
// WorkWithDrives();
// WorkWithDirectories();
// WorkWithFiles();

static void OutputFileSystemInfo()
{
  WriteLine("{0,-33} {1}", arg0: "Path.PathSeparator",
    arg1: PathSeparator);
  WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar",
    arg1: DirectorySeparatorChar);
  WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()",
    arg1: GetCurrentDirectory());
  WriteLine("{0,-33} {1}", arg0: "Environment.CurrentDirectory",
    arg1: CurrentDirectory);
  WriteLine("{0,-33} {1}", arg0: "Environment.SystemDirectory",
    arg1: SystemDirectory);
  WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()",
    arg1: GetTempPath());

  WriteLine("GetFolderPath(SpecialFolder");
  WriteLine("{0,-33} {1}", arg0: "  .System)",
    arg1: GetFolderPath(SpecialFolder.System));
  WriteLine("{0,-33} {1}", arg0: "  .ApplicationData)",
    arg1: GetFolderPath(SpecialFolder.ApplicationData));
  WriteLine("{0,-33} {1}", arg0: "  .MyDocuments)",
    arg1: GetFolderPath(SpecialFolder.MyDocuments));
  WriteLine("{0,-33} {1}", arg0: "  .Personal)",
    arg1: GetFolderPath(SpecialFolder.Personal));
}

static void WorkWithDrives()
{
  WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
    "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");

  foreach (DriveInfo drive in DriveInfo.GetDrives())
  {
    if (drive.IsReady)
    {
      WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
        drive.Name, drive.DriveType, drive.DriveFormat,
        drive.TotalSize, drive.AvailableFreeSpace);
    }
    else
    {
      WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
    }
  }
}

static void WorkWithDirectories()
{
  // определяем путь для новой папки
  // начиная с папки пользователя
  string newFolder = Combine(
    GetFolderPath(SpecialFolder.Personal),
    "Code", "Chapter09", "NewFolder");

  WriteLine($"Working with: {newFolder}");

  // проверяем, существует ли он
  WriteLine($"Does it exist? {Exists(newFolder)}");

  // создать каталог
  WriteLine("Creating it...");
  CreateDirectory(newFolder);
  WriteLine($"Does it exist? {Exists(newFolder)}");

  Write("Confirm the directory exists, and then press ENTER: ");
  ReadLine();

  // удалить каталог
  WriteLine("Deleting it...");
  Delete(newFolder, recursive: true);
  WriteLine($"Does it exist? {Exists(newFolder)}");
}

static void WorkWithFiles()
{
  // определяем путь к каталогу для выходных файлов
  // начиная с папки пользователя
  string dir = Combine(
    GetFolderPath(SpecialFolder.Personal),
    "Code", "Chapter09", "OutputFiles");

  CreateDirectory(dir);

  // определить пути к файлам
  string textFile = Combine(dir, "Dummy.txt");
  string backupFile = Combine(dir, "Dummy.bak");

  WriteLine($"Working with: {textFile}");

  // проверить, существует ли файл
  WriteLine($"Does it exist? {File.Exists(textFile)}");

  // создайте новый текстовый файл и напишите в него строку
  StreamWriter textWriter = File.CreateText(textFile);
  textWriter.WriteLine("Hello, C#!");
  textWriter.Close();  // закрываем файл и освобождаем ресурсы
  WriteLine($"Does it exist? {File.Exists(textFile)}");

  // скопируйте файл и перезапишите, если он уже существует
  File.Copy(sourceFileName: textFile,
    destFileName: backupFile, overwrite: true);
  WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
  Write("Confirm the files exist, and then press ENTER: ");
  ReadLine();

  //удалить файл
  File.Delete(textFile);
  WriteLine($"Does it exist? {File.Exists(textFile)}");

  // прочитать из резервной копии текстового файла
  WriteLine($"Reading contents of {backupFile}:");
  StreamReader textReader = File.OpenText(backupFile);
  WriteLine(textReader.ReadToEnd());
  textReader.Close();

  // Управление путями
  WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
  WriteLine($"File Name: {GetFileName(textFile)}");
  WriteLine("File Name without Extension: {0}",
    GetFileNameWithoutExtension(textFile));
  WriteLine($"File Extension: {GetExtension(textFile)}");
  WriteLine($"Random File Name: {GetRandomFileName()}");
  WriteLine($"Temporary File Name: {GetTempFileName()}");

  // Получение информации о файле
  FileInfo info = new(backupFile);
  WriteLine($"{backupFile}:");
  WriteLine($"Contains {info.Length} bytes");
  WriteLine($"Last accessed {info.LastAccessTime}");
  WriteLine($"Has readonly set to {info.IsReadOnly}");
}
