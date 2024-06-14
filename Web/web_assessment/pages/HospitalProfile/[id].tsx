import Image from "next/image";

const HospitalProfile = () => {
    return ( 
        <div className="profile bg-white p-12">
        {/*Profile photo*/}
        <section>
            <Image className = "profile-pic top-3/4 left-1/2 right-1/2 inline object-cover self-center w-40 h-40 mr-2 rounded-full border-4 border-primary" 
            src = ""
            alt = "profile-pic"
            width = {1117} height = {359}/>
        </section>

        {/*Description*/}
        <div className="Description ">
        <section>
            <h1 className="text-5xl text-bold p-4">St.Paulose Hospital</h1>
            <h1 className="text-1xl grid grid-col-2	 bg-green-300 p-4">available</h1>
        </section>
        </div>

            {/*About*/}
        <section>
            <h1 className="font-poppins font-bold p-4">About</h1>
            <p className="font-poppins">Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam, pariatur veniam alias doloremque dignissimos possimus sunt ab, nulla soluta optio quos architecto ipsam quae! Accusantium dicta optio ipsam illum laudantium!</p>
        </section> 

        { /*Services*/}
        <section>
        <h1 className = "education font-popinns font-bold">Services</h1>
        <div className="flex flex-row gap-y-1">
            <ul>Timrmmur</ul>
        </div>
        </section>

        {/*Contact Info */}
        <section>
            <h1 className="font-bold p-4">Contact Info</h1>
            <div className = "contact text-lg inline mx-5">
                <h1 className="font-bold">Phone Number:</h1>
            </div>
            <p>+25195698700</p>
        </section>

        <section>
            <h1>Contact Info</h1>
            <div className = "contact text-lg inline mx-5">
                <h1 className="font-bold">Email:</h1>
            </div>
            <p>faisnvol@stpault.com</p>
        </section> 
        </div>);
}
 
export default HospitalProfile;