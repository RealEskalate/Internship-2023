import Image from "next/image";
import { HospitalResponse } from "@/type/HospitslList";


function HospitalCard ({coverPhoto, institutionName, address, phoneNumbers, emails, availability}:any) {
    return (  
        <div className = "card  grid grid-cols-3 col-span-3 font-poppins border border-gray-300 item-center overflow-hidden shadow-md">
            <div className="profile-img object-cover">
            <Image src = {coverPhoto} alt = "profile"
                   width = {332} height = {232}/>
            </div>
            <div className="info ">
                <p className="font-light text-blue-500">{address[0].region}</p>
                <h1 className="font-bold"> {institutionName}</h1>
            
                <p className="px-3 py-1 rounded-2xl">{phoneNumbers}</p>
                <p className="font-light">{emails}</p>
            </div>
            <div className="available flex flex-auto bg-green-300">
                <p>{availability[0].twentyFourHours}</p>
            </div>
        </div>
    );
}

export default HospitalCard;