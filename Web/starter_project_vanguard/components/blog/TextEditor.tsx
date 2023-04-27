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


const QuillToolbarOptions = [
  [{ 'header': [1, 2, 3, 4, 5, 6, false] }], 
  ['bold', 'italic', 'underline'], 
  [{ 'list': 'bullet' },{ 'align': [] }],
  ['link','video', 'image'],
];

const TextEditor: React.FC<QuillProps> = ({ value, onChange }) => {
  return (
    <div className="min-h-20">
      <QuillEditor
        theme="snow"  
        modules={{
          toolbar: QuillToolbarOptions,  
        }}
        value={value}
        onChange={(content) => onChange(content)}
      />
    </div>
  );
};

export default TextEditor