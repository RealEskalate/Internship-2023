import Image from "next/image";

const Navigation = () => {
    return ( 
        <div className="flex justify-between border-shadow bg-white px-20 pb-10">
            <div className="flex gap-2">
                <Image className = "logo" 
                src = "/navbar/logo.png" alt = "logo" width = {100} height = {60}/>
            </div>
            <div className="nav font-poppins grid grid-cols-3">
                <h1 className="p-2">Home</h1>
                <h2 className="p-2">Hospital</h2>
                <h1 className="p-2">Doctor</h1>
            </div>
            <div className="flex items-center gap-2">
                <Image className = "user"
                src = "/navbar/avatar.png" alt = "avatar" width = {60} height = {60}/>
                <h1>Log out</h1>
            </div>
        </div>
     );
}
 
export default Navigation;