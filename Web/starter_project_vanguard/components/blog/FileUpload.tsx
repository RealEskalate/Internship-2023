import React, { ChangeEvent } from 'react';
import Image from 'next/image';


interface FileUploadProps {
  onImageUpload: (file: File) => void;
}

const FileUpload: React.FC<FileUploadProps> = ({ onImageUpload }) => {
  const handleFileUpload = (event: ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      onImageUpload(file);
    }
  };

  return (
    <div className="w-full mb-16 h-1/2 lg:h-2/3 mt-8 bg-gray-100 rounded-lg flex items-center justify-center flex-col p-2 lg:p-5">
      <Image
        src="/img/illustration.jpg"
        alt="illustration image"
        width={200}
        height={200}
      />

      <div className="flex flex-wrap flex-row gap-2 items-center mt-3">
        <p>Please,</p>
        <label
          htmlFor="upload-file"
          className="bg-white text-gray rounded-md px-4 py-2 hover:bg-gray-200"
        >
          Upload File
          <input
            id="upload-file"
            type="file"
            accept="image/*"
            className="sr-only"
            onChange={handleFileUpload}
          />
        </label>
      </div>
    </div>
  );
};

export default FileUpload;
