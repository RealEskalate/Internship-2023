import Image from "next/image";
import React, {useState} from 'react';
import { MultiValue } from 'react-select';
import SelectBlogTag, { TagOption } from './SelectBlogTag';
import RichTextEditor from "./RichTextEditor";
import { useAddBlogMutation } from "@/store/blog/blogs-api";
import { nanoid } from "nanoid";

// props for file uploads
interface FileInputProps {
  text: string;
  identity: string;
}

// File input conponent for file uploads
const FileInput: React.FC<FileInputProps> = ({ text, identity }) => {
  return (
    <label htmlFor={identity} className="bg-white text-gray rounded-md px-4 py-2 hover:bg-gray-200">
      {text}
      <input id={identity} type="file" className="sr-only" />
    </label>
  );
};

const BlogForm: React.FC = () => {
  // define states
  const [title, setTitle] = useState<string>('');
  const [content, setContent] = useState<string>('');
  const [selectedTags, setSelectedTags] = useState<MultiValue<TagOption>>([]);
  
  // addBlog mutation hook to post a blog
  const [addBlog, { isLoading }] = useAddBlogMutation();

  // handle title changes
  const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>): void => {
    setTitle(event.target.value);
  };

  // handle text editor content changes
  const handleContentChange = (value: string): void => {
    setContent(value);
  };

  // handle select tage changes
  const handleTagChange = (selectedOptions: MultiValue<TagOption>): void => {
    setSelectedTags(selectedOptions);
  };

  // handle cancel changes
  const handleCancelChange = () => {
    setTitle("");
    setContent("");
    setSelectedTags([]);
  }

  // handle form submission
  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    addBlog({
      userID: "Johnsnow1",
      id: nanoid(), // generate a unique id from nanoid package
      title,
      content,
      tags: selectedTags.map(tag => tag.value),
      date : "2/2/2023",
      author: {
        name : "John",
        email : "john@example.com",
        image : "/img/blog/profile.jpg",
        profession: "SWE",
        userName: "John",
      },
      blogImage: "/img/blog/coding.jpg",
      readTime: 4,
      shortDescription: "short description",
    });

    // clear states
    setTitle("");
    setContent("");
    setSelectedTags([]);
    
  };

  const canSaveChanges = Boolean(title) && Boolean(content) && Boolean(selectedTags)

  return (
    <form onSubmit={handleSubmit} className="m-5 w-screen h-screen">
      <div className="flex flex-col lg:flex-row gap-8">
        <div className="flex flex-col w-5/6  md:w-3/5">
          {/* Title Input Section */}
          <input
            className="w-full sm:w-3/5 border-l-2 border-blue-500 py-3 px-4 placeholder-gray-400 text-gray-900 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500 focus:rounded-md"
            placeholder="Enter the title of the blog"
            required
            value = {title}
            onChange = {handleTitleChange}
          />

          {/* Image and File Upload Section */}
          <div className="max-w-2xl max-h-96 md:max-h-72 mt-8 bg-gray-100 rounded-lg flex items-center justify-center flex-col p-5">
            <Image
              src="/img/blog/file-upload.jpg"
              alt="File Upload"
              width={200}
              height={200}
            />

            <div className="flex flex-wrap flex-col md:flex-row gap-2 items-center mt-3">
              <p>Please,</p>
              <FileInput text="Upload File" identity="upload-file" />
              <p>Or choose file from</p>
              <FileInput text="My Files" identity="my-files" />
            </div>
          </div>
          

          {/* Editor Section */}
          <div className="container py-4 max-w-2xl">
            <RichTextEditor
              value={content}
              onChange={handleContentChange}
            />
          </div>
        </div>

        {/* Tag Section */}
        <div className="mb-10 mr-10 px-4 sm:w-1/2 md:w-1/3 lg:w-1/4">
        <SelectBlogTag selectedTags={selectedTags} onChange={handleTagChange}/>
        </div>
      </div>

      {/* Buttons */}
      <div className="flex flex-col sm:flex-row gap-4 w-9/12 mt-10 lg:mt-2 p-4 justify-end lg:justify-center">
          <button onClick={handleCancelChange} className="text-primary hover:text-blue-500 font-medium mr-4">
            Cancel
          </button>
          <button
            className="bg-primary text-white rounded-md px-3 py-1 hover:bg-blue-500"
            type="submit"
            disabled = {isLoading || !canSaveChanges}
            >
            { isLoading ? "Adding..." : "Save Changes"}
          </button>
        </div>
    </form>
  );
};

export default BlogForm;