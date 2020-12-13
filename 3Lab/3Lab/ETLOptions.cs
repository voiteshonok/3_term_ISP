using System;
using System.Collections.Generic;
using System.Text;

namespace _3Lab
{
    class ETLOptions : Options
    {
        public FolderOptions FolderOptions { get; set; }
        public EncryptOptions EncryptOptions { get; set; }
        public ArchiveOptions ArchiveOptions { get; set; }

        public ETLOptions()
        {
            FolderOptions = new FolderOptions();

            EncryptOptions = new EncryptOptions();

            ArchiveOptions = new ArchiveOptions();
        }

        public ETLOptions(FolderOptions folderOptions, EncryptOptions encryptOptions,
            ArchiveOptions archiveOptions)
        {
            this.FolderOptions = folderOptions;

            this.EncryptOptions = encryptOptions;

            this.ArchiveOptions = archiveOptions;
        }
    }
}
