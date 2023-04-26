


const AboutSection = () => {
    return (

<div className='about-section'>

    <div className='col'>
        <h1><div className = "blue-word">Africa &nbsp;</div> to Silicon Valley</h1>
        <p>A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>
        <div className='button'>Meet our Team</div>
        <p>A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>
    </div>

    <div className= "col img-col">
        <div className = "container img1">
        <img src = "@/public/images/Rectangle 1 (2).png" alt = "img1"/>
        <div className = "overlayed-word"> The education process Name </div>

    </div>

    <div className='container img2'>
        <img src = "@/public/images/Rectangle 2 (2).png" alt = "img2" />
        <div className = "overlayerd-word">Development phase</div>
    </div>

    <div className = "container img3">
        <img src = "@/public/images/Rectangle 3 (2).png" alt = "img3"/>
        <div className = "overlayed-word">20% percent growth</div>
    </div>

    </div>
</div>
    
)
}

export default AboutSection