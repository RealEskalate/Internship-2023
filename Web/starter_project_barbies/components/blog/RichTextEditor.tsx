/* This component is done by using react quill text editor */
import dynamic from 'next/dynamic';
// import the snow theme that makes the editor's content area white backgorund and gray text.
import 'react-quill/dist/quill.snow.css';

// QuillEditor component
const QuillEditor = dynamic(
  () => import('react-quill'),
  { ssr: false } // since quill editor is designed to work in the browser environment.
);

interface RichTextEditorProps {
  value: string;
  onChange: (value: string) => void;
}

// Define toolbar options for Quill editor
const QuillToolbarOptions = [
  [{ 'header': [1, 2, 3, 4, 5, 6, false] }], 
  ['bold', 'italic', 'underline'], 
  [{ 'list': 'bullet' },{ 'align': [] }],
  ['link','video', 'image'],
];

const RichTextEditor: React.FC<RichTextEditorProps> = ({ value, onChange }) => {
  return (
    <div className="min-h-20">
      <QuillEditor
        theme="snow"  // Use the Snow theme for Quill
        modules={{
          toolbar: QuillToolbarOptions,  // Add the toolbar options to Quill
        }}
        value={value}
        onChange={(content) => onChange(content)}
      />
    </div>
  );
};

export default RichTextEditor;
