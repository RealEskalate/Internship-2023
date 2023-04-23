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
    className="btn rounded-full md"

      style={{
         backgroundColor: "#F5F5F5",
         width : width,
         fontFamily: 'Montserrat',
         fontSize:'20px',
         
      }}
    >
    {child}
    </button>
  )
}

export default TagComponent
