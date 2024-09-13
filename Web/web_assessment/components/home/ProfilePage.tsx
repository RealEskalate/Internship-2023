import React from "react";
import Image from "next/image"

interface Props {
    photo: string,
    name: string,
    field: string,
    description: string,
    about: string,
    education: string,
    contact: string,
    contactInfo: string,

}
const DoctorsProfile: React.FC<Props> = ({photo, name, description, about, education, contact, field, contactInfo }) => {
    return (
    <div className="profile max-w-sm mx-auto bg-white shadow-lg rounded-lg overflow-hidden p-12 pr-44">
        <div className="img1 bg-gray-400 h-64 w-full flex items-center justify-center">
            <img className="h-32 w-32 rounded-full absolute"> src = {photo} alt = {name}</img>
            <Image className="h-full w-full object-cover" src = {"/profile/image-1"}  alt = {"name"} width = {"1268"} height = {"288"} ></Image>
        </div>

        <div className="description grid grid-cols-2">
        <div>
            <h1 className="text-2xl font-poppins font-bold"> {name} </h1>
            <h1 className="font-poppins font-light"> {field}</h1>
        </div>
        <div>
            <h1 className="text-2xl font-poppins">{description}</h1>
        </div>
        </div>

        <div className= "about">
        <h1 className="about-doctor font-bold"> About</h1>
        <p className = "text-5xl font-poppins">
            {about}
        </p>
        </div>

        <div>
        <h2 className="text-gray-900 font-semibold">Education</h2>
            <ul className="list-disc list-inside">
                  {education}  
            </ul>
          </div>
          <div className="text-xs">
            <h2 className="text-gray-900 font-semibold">Contact Info</h2>
            <p className="text-gray-600">{contact}</p>
          </div>
        
    </div>
    )

}

export default DoctorsProfile