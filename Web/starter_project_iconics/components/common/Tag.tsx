
interface TagProps {
    onClick: ()=>void,
    child:string,
    width?: string
}
// 
//  Tag Component
//   
//  A component that displays a tag with the given text and calls the provided function 
//  when clicked. The tag can have an optional width specified.
//  
//   @param {string} children - The text to be displayed in the tag.
//   @param {function} onClick - The function to be called when the tag is clicked.
//   @param {string} [width] - Optional width for the tag.
//  
const Tag: React.FC<TagProps> = ({child, onClick, width}) => {
  return (
    <button 
    onClick={onClick}
    className="rounded-full font-montserrat bg-gray-100 text-gray-800 px-2 border-gray-400 m-1"

      style={{
         width : width,
      }}
    >
    {child}
    </button>
  )
}

export default Tag
