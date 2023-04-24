/* This component is done by using react-quill rich text editor */
import dynamic from 'next/dynamic';
import 'react-quill/dist/quill.snow.css';  

const QuillEditor = dynamic(
  () => import('react-quill'),
  { ssr: false }
);

interface QuillProps {
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

const QuillEditorComponent: React.FC<QuillProps> = ({ value, onChange }) => {
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

export default QuillEditorComponent;
