import React from "react";


const Footer: React.FC = () => {
    return (
    <div className="footer grid grid-cols-2 bg-violet-400 border border-gray-400">
        <div className = "item center text-white"> 
            <h1 className="font-popins"> Hakim Hub</h1>
        </div>

        <div className = "contact grid grid-cols-3 grid-row-2 text-white">
        <div><h1 className = "text-semibold">Contact</h1></div>
        </div>
        
    </div>
    )
}