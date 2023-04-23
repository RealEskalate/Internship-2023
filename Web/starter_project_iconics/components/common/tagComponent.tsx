import React from "react"

interface props {
    onClick: ()=>void,
    child:string,
    width?: string
}
const TagComponent: React.FC<props> = ({child, onClick, width}) => {
  return (
    <button 
    onClick={onClick}
    className="btn rounded-full md text-lg font-montserrat bg-slate-200"

      style={{
         width : width,
      }}
    >
    {child}
    </button>
  )
}

export default TagComponent
