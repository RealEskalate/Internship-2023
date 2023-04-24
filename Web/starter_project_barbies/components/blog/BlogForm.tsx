import Image from "next/image";
import React, {useState} from 'react';
import SelectTag from './SelectBlogTag';
import QuillEditorComponent from "./RichTextEditor";

const BlogForm: React.FC = () => {
  // define state for the text editor content
  const [content, setContent] = useState<string>('');

  const handleContentChange = (value: string): void => {
    setContent(value);
  };

  return (
    <div className="m-5 w-screen h-screen">
      <div className="flex flex-col lg:flex-row gap-8">
        <div className="flex flex-col w-5/6  md:w-3/5">
          {/* Title Input Section */}
          <input
            className="w-full sm:w-3/5 border-l-2 border-blue-500 py-3 px-4 placeholder-gray-400 text-gray-900 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 focus:rounded-md"
            placeholder="Enter the title of the blog"
            required
          />

          {/* Image and File Upload Section */}
          <div className="max-w-2xl max-h-96 md:max-h-72 mt-8 bg-gray-100 rounded-lg flex items-center justify-center flex-col p-5">
            <Image
              src="/img/file-upload.jpg"
              alt="File Upload"
              width={200}
              height={200}
            />

            <div className="flex flex-wrap flex-col md:flex-row gap-2 items-center mt-3">
              <p>Please,</p>
              <label htmlFor="upload-file" className="bg-white text-gray rounded-md px-4 py-2 hover:bg-gray-200">
                Upload File
                <input id="upload-file" type="file" className="sr-only" />
              </label>
              <p>Or choose file from</p>
              <label htmlFor="my-files" className="bg-white text-gray rounded-md px-4 py-2 hover:bg-gray-200">
                My Files
                <input id="my-files" type="file" className="sr-only" />
              </label>
            </div>
          </div>

          {/* Editor Section */}
          <div className="container py-4 max-w-2xl">
            <QuillEditorComponent
              value={content}
              onChange={handleContentChange}
            />
          </div>
        </div>

        {/* Tag Section */}
        <div className="mb-10 mr-10 px-4 sm:w-1/2 md:w-1/3 lg:w-1/4">
        <SelectTag />
        </div>
      </div>

      {/* Buttons */}
      <div className="flex flex-col sm:flex-row gap-4 w-9/12 mt-10 lg:mt-2 p-4 justify-end lg:justify-center">
          <button className="text-blue-600 hover:text-gray-800 font-medium mr-4">
            Cancel
          </button>
          <button className="bg-blue-600 text-white rounded-md px-3 py-1 hover:bg-blue-500">
            Save Changes
          </button>
        </div>
    </div>
  );
};

export default BlogForm;
