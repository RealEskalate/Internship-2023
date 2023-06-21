import React from 'react'
import SiFacebook from "react-icons/si"
import {RiFacebookCircleFill} from "react-icons/ri"
import {FaLinkedinIn} from "react-icons/fa"
import {BsTwitter} from "react-icons/bs"
import {GrInstagram} from "react-icons/gr"

function Footer() {
  return (
    <div className = "bg-primary text-white pr-24  bottom-0   w-full">
        <div className = " flex justify-between p-10">
        <div>
            <p className = "text-3xl font-bold">HakimHub</p>
        </div>
        <div className = "flex gap-8">
            <div>
                <h1 className = "font-bold">Get Connected</h1>
                <p className = "py-2"> > For Physicians</p>
                <p> > For Hospitals</p>
            </div>
            <div>
                <h1 className = "font-bold">Actions</h1>
                <p  className = "py-2"> > Find a doctor</p>
                <p> > Find a hospital</p>
            </div>
            <div>
                <h1  className = "font-bold">Company</h1>
                <p className = "py-2"> > About us</p>
                <p className = "pb-2"> > carrer</p>
                <p> > join our team</p>
            </div>

        </div>
        
    </div>
    <div className = "border-t-2 flex justify-between p-4">
        <div className = " flex gap-10" >
            <p>Privacy Policy</p>
            <p>Term of use</p>
        </div>
        <div className = "flex justify-evenly gap-9">
            <RiFacebookCircleFill></RiFacebookCircleFill>
            <FaLinkedinIn></FaLinkedinIn>
            <GrInstagram></GrInstagram>
            <BsTwitter></BsTwitter>

        </div>
    </div>
    </div>
  )
}

export default Footer