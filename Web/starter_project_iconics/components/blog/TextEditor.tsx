import dynamic from 'next/dynamic'
import { useState } from 'react'
import 'react-quill/dist/quill.snow.css'
const ReactQuill = dynamic(() => import('react-quill'), { ssr: false })

const TextEditor: React.FC = () => {
  const [content, setContent] = useState('')

  const handleChange = (value: string) => {
    setContent(value)
  }

  const modules = {
    toolbar: [
      ['bold', 'italic', 'underline'],
      [{ list: 'ordered' }, { list: 'bullet' }],
      ['link'],
      ['video', 'image', 'file'],
    ],
  }
  return (
    <div>
      <ReactQuill
        value={content}
        onChange={handleChange}
        modules={modules}
        className="mt-12 mb-8 h-48 pb-12"
        placeholder="Lorem ipsum........"
      />
    </div>
  )
}

export default TextEditor
