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
    <div className="border-l-2 ">
      <QuillEditor
        theme="snow" 
        placeholder='Lorem ipsum dolor sit amet consectetur adipisicing elit. Enim optio voluptatum accusamus quibusdam aliquam quam libero qui, ducimus magnam voluptas quia, omnis et aspernatur maiores voluptatem quis officiis molestias quo! Ipsum vero illo quasi ducimus quia voluptatum numquam dignissimos quae. Accusamus maiores explicabo vero minima praesentium a doloribus itaque cumque hic odio pariatur, sint ullam ad architecto dolorum, at culpa!' 
        modules={{
          toolbar: QuillToolbarOptions,  
        }}
        value={value}
        onChange={(content) => onChange(content)}
        className='h-28 '
      />
    </div>
  );
};

export default TextEditor