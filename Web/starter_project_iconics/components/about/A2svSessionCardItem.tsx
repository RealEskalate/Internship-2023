import React from "react";

interface props {
  logo: string,
  title: string,
  description: string
}

function CardItem({logo, title, description}:props) {
    return (
    <div className="cards logo w-[350px] font-poppins flex flex-col border border-gray-300 rounded-3xl overflow-hidden shadow-md bg-white h-543 m-2 font-bold">         
    <div className="card_writter flex items-center mb-6 mt-4 p-1">
          <img
            className="card_logo w-10 h-10 object-cover rounded-full mr-2 width{400} height{400}"
            src={logo}
            alt='' />
           </div>
          <div className="card_title flex flex-col items-start">
            <span className="card_title m-0   text-gray-600 p-4">
              <h1>
                {title} 
              </h1> 
            </span>
          </div>
       
        <p className="card_description mt-3 mb-3 font-poppins font-light p-4">
          {description}
        </p>
        </div>
    )
}

export default CardItem